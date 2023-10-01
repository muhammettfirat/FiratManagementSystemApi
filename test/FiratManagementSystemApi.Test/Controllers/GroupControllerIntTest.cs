
using AutoMapper;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using FiratManagementSystemApi.Infrastructure.Data;
using FiratManagementSystemApi.Domain.Entities;
using FiratManagementSystemApi.Domain.Repositories.Interfaces;
using FiratManagementSystemApi.Dto;
using FiratManagementSystemApi.Configuration.AutoMapper;
using FiratManagementSystemApi.Test.Setup;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Xunit;

namespace FiratManagementSystemApi.Test.Controllers
{
    public class GroupsControllerIntTest
    {
        public GroupsControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _groupRepository = _factory.GetRequiredService<IGroupRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            _mapper = config.CreateMapper();

            InitTest();
        }

        private const string DefaultCode = "AAAAAAAAAA";
        private const string UpdatedCode = "BBBBBBBBBB";

        private const string DefaultDefinition = "AAAAAAAAAA";
        private const string UpdatedDefinition = "BBBBBBBBBB";

        private readonly AppWebApplicationFactory<TestStartup> _factory;
        private readonly HttpClient _client;
        private readonly IGroupRepository _groupRepository;

        private Group _group;

        private readonly IMapper _mapper;

        private Group CreateEntity()
        {
            return new Group
            {
                Code = DefaultCode,
                Definition = DefaultDefinition,
            };
        }

        private void InitTest()
        {
            _group = CreateEntity();
        }

        [Fact]
        public async Task CreateGroup()
        {
            var databaseSizeBeforeCreate = await _groupRepository.CountAsync();

            // Create the Group
            GroupDto _groupDto = _mapper.Map<GroupDto>(_group);
            var response = await _client.PostAsync("/api/groups", TestUtil.ToJsonContent(_groupDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the Group in the database
            var groupList = await _groupRepository.GetAllAsync();
            groupList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testGroup = groupList.Last();
            testGroup.Code.Should().Be(DefaultCode);
            testGroup.Definition.Should().Be(DefaultDefinition);
        }

        [Fact]
        public async Task CreateGroupWithExistingId()
        {
            var databaseSizeBeforeCreate = await _groupRepository.CountAsync();
            // Create the Group with an existing ID
            _group.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            GroupDto _groupDto = _mapper.Map<GroupDto>(_group);
            var response = await _client.PostAsync("/api/groups", TestUtil.ToJsonContent(_groupDto));

            // Validate the Group in the database
            var groupList = await _groupRepository.GetAllAsync();
            groupList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task GetAllGroups()
        {
            // Initialize the database
            await _groupRepository.CreateOrUpdateAsync(_group);
            await _groupRepository.SaveChangesAsync();

            // Get all the groupList
            var response = await _client.GetAsync("/api/groups?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_group.Id);
            json.SelectTokens("$.[*].code").Should().Contain(DefaultCode);
            json.SelectTokens("$.[*].definition").Should().Contain(DefaultDefinition);
        }

        [Fact]
        public async Task GetGroup()
        {
            // Initialize the database
            await _groupRepository.CreateOrUpdateAsync(_group);
            await _groupRepository.SaveChangesAsync();

            // Get the group
            var response = await _client.GetAsync($"/api/groups/{_group.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_group.Id);
            json.SelectTokens("$.code").Should().Contain(DefaultCode);
            json.SelectTokens("$.definition").Should().Contain(DefaultDefinition);
        }

        [Fact]
        public async Task GetNonExistingGroup()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/groups/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateGroup()
        {
            // Initialize the database
            await _groupRepository.CreateOrUpdateAsync(_group);
            await _groupRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _groupRepository.CountAsync();

            // Update the group
            var updatedGroup = await _groupRepository.QueryHelper().GetOneAsync(it => it.Id == _group.Id);
            // Disconnect from session so that the updates on updatedGroup are not directly saved in db
            //TODO detach
            updatedGroup.Code = UpdatedCode;
            updatedGroup.Definition = UpdatedDefinition;

            GroupDto updatedGroupDto = _mapper.Map<GroupDto>(updatedGroup);
            var response = await _client.PutAsync($"/api/groups/{_group.Id}", TestUtil.ToJsonContent(updatedGroupDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the Group in the database
            var groupList = await _groupRepository.GetAllAsync();
            groupList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testGroup = groupList.Last();
            testGroup.Code.Should().Be(UpdatedCode);
            testGroup.Definition.Should().Be(UpdatedDefinition);
        }

        [Fact]
        public async Task UpdateNonExistingGroup()
        {
            var databaseSizeBeforeUpdate = await _groupRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            GroupDto _groupDto = _mapper.Map<GroupDto>(_group);
            var response = await _client.PutAsync("/api/groups/1", TestUtil.ToJsonContent(_groupDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the Group in the database
            var groupList = await _groupRepository.GetAllAsync();
            groupList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteGroup()
        {
            // Initialize the database
            await _groupRepository.CreateOrUpdateAsync(_group);
            await _groupRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _groupRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/groups/{_group.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var groupList = await _groupRepository.GetAllAsync();
            groupList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(Group));
            var group1 = new Group
            {
                Id = 1L
            };
            var group2 = new Group
            {
                Id = group1.Id
            };
            group1.Should().Be(group2);
            group2.Id = 2L;
            group1.Should().NotBe(group2);
            group1.Id = 0;
            group1.Should().NotBe(group2);
        }
    }
}
