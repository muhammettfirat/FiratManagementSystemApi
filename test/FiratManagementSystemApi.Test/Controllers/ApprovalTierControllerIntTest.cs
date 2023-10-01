
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
    public class ApprovalTiersControllerIntTest
    {
        public ApprovalTiersControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _approvalTierRepository = _factory.GetRequiredService<IApprovalTierRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            _mapper = config.CreateMapper();

            InitTest();
        }

        private static readonly int? DefaultCode = 1;
        private static readonly int? UpdatedCode = 2;

        private const string DefaultDefinition = "AAAAAAAAAA";
        private const string UpdatedDefinition = "BBBBBBBBBB";

        private static readonly bool? DefaultFinalTiers = false;
        private static readonly bool? UpdatedFinalTiers = true;

        private readonly AppWebApplicationFactory<TestStartup> _factory;
        private readonly HttpClient _client;
        private readonly IApprovalTierRepository _approvalTierRepository;

        private ApprovalTier _approvalTier;

        private readonly IMapper _mapper;

        private ApprovalTier CreateEntity()
        {
            return new ApprovalTier
            {
                Code = DefaultCode,
                Definition = DefaultDefinition,
                FinalTiers = DefaultFinalTiers,
            };
        }

        private void InitTest()
        {
            _approvalTier = CreateEntity();
        }

        [Fact]
        public async Task CreateApprovalTier()
        {
            var databaseSizeBeforeCreate = await _approvalTierRepository.CountAsync();

            // Create the ApprovalTier
            ApprovalTierDto _approvalTierDto = _mapper.Map<ApprovalTierDto>(_approvalTier);
            var response = await _client.PostAsync("/api/approval-tiers", TestUtil.ToJsonContent(_approvalTierDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the ApprovalTier in the database
            var approvalTierList = await _approvalTierRepository.GetAllAsync();
            approvalTierList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testApprovalTier = approvalTierList.Last();
            testApprovalTier.Code.Should().Be(DefaultCode);
            testApprovalTier.Definition.Should().Be(DefaultDefinition);
            testApprovalTier.FinalTiers.Should().Be(DefaultFinalTiers);
        }

        [Fact]
        public async Task CreateApprovalTierWithExistingId()
        {
            var databaseSizeBeforeCreate = await _approvalTierRepository.CountAsync();
            // Create the ApprovalTier with an existing ID
            _approvalTier.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            ApprovalTierDto _approvalTierDto = _mapper.Map<ApprovalTierDto>(_approvalTier);
            var response = await _client.PostAsync("/api/approval-tiers", TestUtil.ToJsonContent(_approvalTierDto));

            // Validate the ApprovalTier in the database
            var approvalTierList = await _approvalTierRepository.GetAllAsync();
            approvalTierList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task CheckCodeIsRequired()
        {
            var databaseSizeBeforeTest = await _approvalTierRepository.CountAsync();

            // Set the field to null
            _approvalTier.Code = null;

            // Create the ApprovalTier, which fails.
            ApprovalTierDto _approvalTierDto = _mapper.Map<ApprovalTierDto>(_approvalTier);
            var response = await _client.PostAsync("/api/approval-tiers", TestUtil.ToJsonContent(_approvalTierDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var approvalTierList = await _approvalTierRepository.GetAllAsync();
            approvalTierList.Count().Should().Be(databaseSizeBeforeTest);
        }

        [Fact]
        public async Task CheckDefinitionIsRequired()
        {
            var databaseSizeBeforeTest = await _approvalTierRepository.CountAsync();

            // Set the field to null
            _approvalTier.Definition = null;

            // Create the ApprovalTier, which fails.
            ApprovalTierDto _approvalTierDto = _mapper.Map<ApprovalTierDto>(_approvalTier);
            var response = await _client.PostAsync("/api/approval-tiers", TestUtil.ToJsonContent(_approvalTierDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var approvalTierList = await _approvalTierRepository.GetAllAsync();
            approvalTierList.Count().Should().Be(databaseSizeBeforeTest);
        }

        [Fact]
        public async Task GetAllApprovalTiers()
        {
            // Initialize the database
            await _approvalTierRepository.CreateOrUpdateAsync(_approvalTier);
            await _approvalTierRepository.SaveChangesAsync();

            // Get all the approvalTierList
            var response = await _client.GetAsync("/api/approval-tiers?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_approvalTier.Id);
            json.SelectTokens("$.[*].code").Should().Contain(DefaultCode);
            json.SelectTokens("$.[*].definition").Should().Contain(DefaultDefinition);
            json.SelectTokens("$.[*].finalTiers").Should().Contain(DefaultFinalTiers);
        }

        [Fact]
        public async Task GetApprovalTier()
        {
            // Initialize the database
            await _approvalTierRepository.CreateOrUpdateAsync(_approvalTier);
            await _approvalTierRepository.SaveChangesAsync();

            // Get the approvalTier
            var response = await _client.GetAsync($"/api/approval-tiers/{_approvalTier.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_approvalTier.Id);
            json.SelectTokens("$.code").Should().Contain(DefaultCode);
            json.SelectTokens("$.definition").Should().Contain(DefaultDefinition);
            json.SelectTokens("$.finalTiers").Should().Contain(DefaultFinalTiers);
        }

        [Fact]
        public async Task GetNonExistingApprovalTier()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/approval-tiers/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateApprovalTier()
        {
            // Initialize the database
            await _approvalTierRepository.CreateOrUpdateAsync(_approvalTier);
            await _approvalTierRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _approvalTierRepository.CountAsync();

            // Update the approvalTier
            var updatedApprovalTier = await _approvalTierRepository.QueryHelper().GetOneAsync(it => it.Id == _approvalTier.Id);
            // Disconnect from session so that the updates on updatedApprovalTier are not directly saved in db
            //TODO detach
            updatedApprovalTier.Code = UpdatedCode;
            updatedApprovalTier.Definition = UpdatedDefinition;
            updatedApprovalTier.FinalTiers = UpdatedFinalTiers;

            ApprovalTierDto updatedApprovalTierDto = _mapper.Map<ApprovalTierDto>(updatedApprovalTier);
            var response = await _client.PutAsync($"/api/approval-tiers/{_approvalTier.Id}", TestUtil.ToJsonContent(updatedApprovalTierDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the ApprovalTier in the database
            var approvalTierList = await _approvalTierRepository.GetAllAsync();
            approvalTierList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testApprovalTier = approvalTierList.Last();
            testApprovalTier.Code.Should().Be(UpdatedCode);
            testApprovalTier.Definition.Should().Be(UpdatedDefinition);
            testApprovalTier.FinalTiers.Should().Be(UpdatedFinalTiers);
        }

        [Fact]
        public async Task UpdateNonExistingApprovalTier()
        {
            var databaseSizeBeforeUpdate = await _approvalTierRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            ApprovalTierDto _approvalTierDto = _mapper.Map<ApprovalTierDto>(_approvalTier);
            var response = await _client.PutAsync("/api/approval-tiers/1", TestUtil.ToJsonContent(_approvalTierDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the ApprovalTier in the database
            var approvalTierList = await _approvalTierRepository.GetAllAsync();
            approvalTierList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteApprovalTier()
        {
            // Initialize the database
            await _approvalTierRepository.CreateOrUpdateAsync(_approvalTier);
            await _approvalTierRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _approvalTierRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/approval-tiers/{_approvalTier.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var approvalTierList = await _approvalTierRepository.GetAllAsync();
            approvalTierList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(ApprovalTier));
            var approvalTier1 = new ApprovalTier
            {
                Id = 1L
            };
            var approvalTier2 = new ApprovalTier
            {
                Id = approvalTier1.Id
            };
            approvalTier1.Should().Be(approvalTier2);
            approvalTier2.Id = 2L;
            approvalTier1.Should().NotBe(approvalTier2);
            approvalTier1.Id = 0;
            approvalTier1.Should().NotBe(approvalTier2);
        }
    }
}
