
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
    public class TierAuthorizationsControllerIntTest
    {
        public TierAuthorizationsControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _tierAuthorizationRepository = _factory.GetRequiredService<ITierAuthorizationRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            _mapper = config.CreateMapper();

            InitTest();
        }

        private static readonly UNKNOWN_TYPE DefaultPersonnelId = ;
        private static readonly UNKNOWN_TYPE UpdatedPersonnelId = ;

        private const string DefaultPersonnelName = "AAAAAAAAAA";
        private const string UpdatedPersonnelName = "BBBBBBBBBB";

        private const string DefaultEmailInfo = "AAAAAAAAAA";
        private const string UpdatedEmailInfo = "BBBBBBBBBB";

        private readonly AppWebApplicationFactory<TestStartup> _factory;
        private readonly HttpClient _client;
        private readonly ITierAuthorizationRepository _tierAuthorizationRepository;

        private TierAuthorization _tierAuthorization;

        private readonly IMapper _mapper;

        private TierAuthorization CreateEntity()
        {
            return new TierAuthorization
            {
                PersonnelId = DefaultPersonnelId,
                PersonnelName = DefaultPersonnelName,
                EmailInfo = DefaultEmailInfo,
            };
        }

        private void InitTest()
        {
            _tierAuthorization = CreateEntity();
        }

        [Fact]
        public async Task CreateTierAuthorization()
        {
            var databaseSizeBeforeCreate = await _tierAuthorizationRepository.CountAsync();

            // Create the TierAuthorization
            TierAuthorizationDto _tierAuthorizationDto = _mapper.Map<TierAuthorizationDto>(_tierAuthorization);
            var response = await _client.PostAsync("/api/tier-authorizations", TestUtil.ToJsonContent(_tierAuthorizationDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the TierAuthorization in the database
            var tierAuthorizationList = await _tierAuthorizationRepository.GetAllAsync();
            tierAuthorizationList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testTierAuthorization = tierAuthorizationList.Last();
            testTierAuthorization.PersonnelId.Should().Be(DefaultPersonnelId);
            testTierAuthorization.PersonnelName.Should().Be(DefaultPersonnelName);
            testTierAuthorization.EmailInfo.Should().Be(DefaultEmailInfo);
        }

        [Fact]
        public async Task CreateTierAuthorizationWithExistingId()
        {
            var databaseSizeBeforeCreate = await _tierAuthorizationRepository.CountAsync();
            // Create the TierAuthorization with an existing ID
            _tierAuthorization.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            TierAuthorizationDto _tierAuthorizationDto = _mapper.Map<TierAuthorizationDto>(_tierAuthorization);
            var response = await _client.PostAsync("/api/tier-authorizations", TestUtil.ToJsonContent(_tierAuthorizationDto));

            // Validate the TierAuthorization in the database
            var tierAuthorizationList = await _tierAuthorizationRepository.GetAllAsync();
            tierAuthorizationList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task GetAllTierAuthorizations()
        {
            // Initialize the database
            await _tierAuthorizationRepository.CreateOrUpdateAsync(_tierAuthorization);
            await _tierAuthorizationRepository.SaveChangesAsync();

            // Get all the tierAuthorizationList
            var response = await _client.GetAsync("/api/tier-authorizations?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_tierAuthorization.Id);
            json.SelectTokens("$.[*].personnelId").Should().Contain(DefaultPersonnelId);
            json.SelectTokens("$.[*].personnelName").Should().Contain(DefaultPersonnelName);
            json.SelectTokens("$.[*].emailInfo").Should().Contain(DefaultEmailInfo);
        }

        [Fact]
        public async Task GetTierAuthorization()
        {
            // Initialize the database
            await _tierAuthorizationRepository.CreateOrUpdateAsync(_tierAuthorization);
            await _tierAuthorizationRepository.SaveChangesAsync();

            // Get the tierAuthorization
            var response = await _client.GetAsync($"/api/tier-authorizations/{_tierAuthorization.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_tierAuthorization.Id);
            json.SelectTokens("$.personnelId").Should().Contain(DefaultPersonnelId);
            json.SelectTokens("$.personnelName").Should().Contain(DefaultPersonnelName);
            json.SelectTokens("$.emailInfo").Should().Contain(DefaultEmailInfo);
        }

        [Fact]
        public async Task GetNonExistingTierAuthorization()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/tier-authorizations/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateTierAuthorization()
        {
            // Initialize the database
            await _tierAuthorizationRepository.CreateOrUpdateAsync(_tierAuthorization);
            await _tierAuthorizationRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _tierAuthorizationRepository.CountAsync();

            // Update the tierAuthorization
            var updatedTierAuthorization = await _tierAuthorizationRepository.QueryHelper().GetOneAsync(it => it.Id == _tierAuthorization.Id);
            // Disconnect from session so that the updates on updatedTierAuthorization are not directly saved in db
            //TODO detach
            updatedTierAuthorization.PersonnelId = UpdatedPersonnelId;
            updatedTierAuthorization.PersonnelName = UpdatedPersonnelName;
            updatedTierAuthorization.EmailInfo = UpdatedEmailInfo;

            TierAuthorizationDto updatedTierAuthorizationDto = _mapper.Map<TierAuthorizationDto>(updatedTierAuthorization);
            var response = await _client.PutAsync($"/api/tier-authorizations/{_tierAuthorization.Id}", TestUtil.ToJsonContent(updatedTierAuthorizationDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the TierAuthorization in the database
            var tierAuthorizationList = await _tierAuthorizationRepository.GetAllAsync();
            tierAuthorizationList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testTierAuthorization = tierAuthorizationList.Last();
            testTierAuthorization.PersonnelId.Should().Be(UpdatedPersonnelId);
            testTierAuthorization.PersonnelName.Should().Be(UpdatedPersonnelName);
            testTierAuthorization.EmailInfo.Should().Be(UpdatedEmailInfo);
        }

        [Fact]
        public async Task UpdateNonExistingTierAuthorization()
        {
            var databaseSizeBeforeUpdate = await _tierAuthorizationRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            TierAuthorizationDto _tierAuthorizationDto = _mapper.Map<TierAuthorizationDto>(_tierAuthorization);
            var response = await _client.PutAsync("/api/tier-authorizations/1", TestUtil.ToJsonContent(_tierAuthorizationDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the TierAuthorization in the database
            var tierAuthorizationList = await _tierAuthorizationRepository.GetAllAsync();
            tierAuthorizationList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteTierAuthorization()
        {
            // Initialize the database
            await _tierAuthorizationRepository.CreateOrUpdateAsync(_tierAuthorization);
            await _tierAuthorizationRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _tierAuthorizationRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/tier-authorizations/{_tierAuthorization.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var tierAuthorizationList = await _tierAuthorizationRepository.GetAllAsync();
            tierAuthorizationList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(TierAuthorization));
            var tierAuthorization1 = new TierAuthorization
            {
                Id = 1L
            };
            var tierAuthorization2 = new TierAuthorization
            {
                Id = tierAuthorization1.Id
            };
            tierAuthorization1.Should().Be(tierAuthorization2);
            tierAuthorization2.Id = 2L;
            tierAuthorization1.Should().NotBe(tierAuthorization2);
            tierAuthorization1.Id = 0;
            tierAuthorization1.Should().NotBe(tierAuthorization2);
        }
    }
}
