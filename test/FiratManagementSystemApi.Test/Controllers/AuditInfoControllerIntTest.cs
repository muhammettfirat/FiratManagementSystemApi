using System;

using AutoMapper;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using FluentAssertions.Extensions;
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
    public class AuditInfosControllerIntTest
    {
        public AuditInfosControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _auditInfoRepository = _factory.GetRequiredService<IAuditInfoRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            _mapper = config.CreateMapper();

            InitTest();
        }

        private static readonly DateTime DefaultAuditDate = DateTime.UnixEpoch;
        private static readonly DateTime UpdatedAuditDate = DateTime.UtcNow;

        private static readonly UNKNOWN_TYPE DefaultAuditPersonnel01 = ;
        private static readonly UNKNOWN_TYPE UpdatedAuditPersonnel01 = ;

        private static readonly UNKNOWN_TYPE DefaultAuditPersonnel02 = ;
        private static readonly UNKNOWN_TYPE UpdatedAuditPersonnel02 = ;

        private static readonly UNKNOWN_TYPE DefaultAuditPersonnel03 = ;
        private static readonly UNKNOWN_TYPE UpdatedAuditPersonnel03 = ;

        private static readonly UNKNOWN_TYPE DefaultAuditPersonnel04 = ;
        private static readonly UNKNOWN_TYPE UpdatedAuditPersonnel04 = ;

        private const string DefaultCompanyPersonnel01 = "AAAAAAAAAA";
        private const string UpdatedCompanyPersonnel01 = "BBBBBBBBBB";

        private const string DefaultCompanyPersonnel02 = "AAAAAAAAAA";
        private const string UpdatedCompanyPersonnel02 = "BBBBBBBBBB";

        private const string DefaultCompanyPersonnel03 = "AAAAAAAAAA";
        private const string UpdatedCompanyPersonnel03 = "BBBBBBBBBB";

        private const string DefaultCompanyPersonnel04 = "AAAAAAAAAA";
        private const string UpdatedCompanyPersonnel04 = "BBBBBBBBBB";

        private const string DefaultDescription = "AAAAAAAAAA";
        private const string UpdatedDescription = "BBBBBBBBBB";

        private const string DefaultDecisionTaken = "AAAAAAAAAA";
        private const string UpdatedDecisionTaken = "BBBBBBBBBB";

        private const string DefaultAuditResultMissing = "AAAAAAAAAA";
        private const string UpdatedAuditResultMissing = "BBBBBBBBBB";

        private static readonly int? DefaultAuditEvaluationResult = 1;
        private static readonly int? UpdatedAuditEvaluationResult = 2;

        private const string DefaultExpectedDocument = "AAAAAAAAAA";
        private const string UpdatedExpectedDocument = "BBBBBBBBBB";

        private static readonly int? DefaultScore = 1;
        private static readonly int? UpdatedScore = 2;

        private readonly AppWebApplicationFactory<TestStartup> _factory;
        private readonly HttpClient _client;
        private readonly IAuditInfoRepository _auditInfoRepository;

        private AuditInfo _auditInfo;

        private readonly IMapper _mapper;

        private AuditInfo CreateEntity()
        {
            return new AuditInfo
            {
                AuditDate = DefaultAuditDate,
                AuditPersonnel01 = DefaultAuditPersonnel01,
                AuditPersonnel02 = DefaultAuditPersonnel02,
                AuditPersonnel03 = DefaultAuditPersonnel03,
                AuditPersonnel04 = DefaultAuditPersonnel04,
                CompanyPersonnel01 = DefaultCompanyPersonnel01,
                CompanyPersonnel02 = DefaultCompanyPersonnel02,
                CompanyPersonnel03 = DefaultCompanyPersonnel03,
                CompanyPersonnel04 = DefaultCompanyPersonnel04,
                Description = DefaultDescription,
                DecisionTaken = DefaultDecisionTaken,
                AuditResultMissing = DefaultAuditResultMissing,
                AuditEvaluationResult = DefaultAuditEvaluationResult,
                ExpectedDocument = DefaultExpectedDocument,
                Score = DefaultScore,
            };
        }

        private void InitTest()
        {
            _auditInfo = CreateEntity();
        }

        [Fact]
        public async Task CreateAuditInfo()
        {
            var databaseSizeBeforeCreate = await _auditInfoRepository.CountAsync();

            // Create the AuditInfo
            AuditInfoDto _auditInfoDto = _mapper.Map<AuditInfoDto>(_auditInfo);
            var response = await _client.PostAsync("/api/audit-infos", TestUtil.ToJsonContent(_auditInfoDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the AuditInfo in the database
            var auditInfoList = await _auditInfoRepository.GetAllAsync();
            auditInfoList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testAuditInfo = auditInfoList.Last();
            testAuditInfo.AuditDate.Should().Be(DefaultAuditDate);
            testAuditInfo.AuditPersonnel01.Should().Be(DefaultAuditPersonnel01);
            testAuditInfo.AuditPersonnel02.Should().Be(DefaultAuditPersonnel02);
            testAuditInfo.AuditPersonnel03.Should().Be(DefaultAuditPersonnel03);
            testAuditInfo.AuditPersonnel04.Should().Be(DefaultAuditPersonnel04);
            testAuditInfo.CompanyPersonnel01.Should().Be(DefaultCompanyPersonnel01);
            testAuditInfo.CompanyPersonnel02.Should().Be(DefaultCompanyPersonnel02);
            testAuditInfo.CompanyPersonnel03.Should().Be(DefaultCompanyPersonnel03);
            testAuditInfo.CompanyPersonnel04.Should().Be(DefaultCompanyPersonnel04);
            testAuditInfo.Description.Should().Be(DefaultDescription);
            testAuditInfo.DecisionTaken.Should().Be(DefaultDecisionTaken);
            testAuditInfo.AuditResultMissing.Should().Be(DefaultAuditResultMissing);
            testAuditInfo.AuditEvaluationResult.Should().Be(DefaultAuditEvaluationResult);
            testAuditInfo.ExpectedDocument.Should().Be(DefaultExpectedDocument);
            testAuditInfo.Score.Should().Be(DefaultScore);
        }

        [Fact]
        public async Task CreateAuditInfoWithExistingId()
        {
            var databaseSizeBeforeCreate = await _auditInfoRepository.CountAsync();
            // Create the AuditInfo with an existing ID
            _auditInfo.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            AuditInfoDto _auditInfoDto = _mapper.Map<AuditInfoDto>(_auditInfo);
            var response = await _client.PostAsync("/api/audit-infos", TestUtil.ToJsonContent(_auditInfoDto));

            // Validate the AuditInfo in the database
            var auditInfoList = await _auditInfoRepository.GetAllAsync();
            auditInfoList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task GetAllAuditInfos()
        {
            // Initialize the database
            await _auditInfoRepository.CreateOrUpdateAsync(_auditInfo);
            await _auditInfoRepository.SaveChangesAsync();

            // Get all the auditInfoList
            var response = await _client.GetAsync("/api/audit-infos?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_auditInfo.Id);
            json.SelectTokens("$.[*].auditDate").Should().Contain(DefaultAuditDate);
            json.SelectTokens("$.[*].auditPersonnel01").Should().Contain(DefaultAuditPersonnel01);
            json.SelectTokens("$.[*].auditPersonnel02").Should().Contain(DefaultAuditPersonnel02);
            json.SelectTokens("$.[*].auditPersonnel03").Should().Contain(DefaultAuditPersonnel03);
            json.SelectTokens("$.[*].auditPersonnel04").Should().Contain(DefaultAuditPersonnel04);
            json.SelectTokens("$.[*].companyPersonnel01").Should().Contain(DefaultCompanyPersonnel01);
            json.SelectTokens("$.[*].companyPersonnel02").Should().Contain(DefaultCompanyPersonnel02);
            json.SelectTokens("$.[*].companyPersonnel03").Should().Contain(DefaultCompanyPersonnel03);
            json.SelectTokens("$.[*].companyPersonnel04").Should().Contain(DefaultCompanyPersonnel04);
            json.SelectTokens("$.[*].description").Should().Contain(DefaultDescription);
            json.SelectTokens("$.[*].decisionTaken").Should().Contain(DefaultDecisionTaken);
            json.SelectTokens("$.[*].auditResultMissing").Should().Contain(DefaultAuditResultMissing);
            json.SelectTokens("$.[*].auditEvaluationResult").Should().Contain(DefaultAuditEvaluationResult);
            json.SelectTokens("$.[*].expectedDocument").Should().Contain(DefaultExpectedDocument);
            json.SelectTokens("$.[*].score").Should().Contain(DefaultScore);
        }

        [Fact]
        public async Task GetAuditInfo()
        {
            // Initialize the database
            await _auditInfoRepository.CreateOrUpdateAsync(_auditInfo);
            await _auditInfoRepository.SaveChangesAsync();

            // Get the auditInfo
            var response = await _client.GetAsync($"/api/audit-infos/{_auditInfo.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_auditInfo.Id);
            json.SelectTokens("$.auditDate").Should().Contain(DefaultAuditDate);
            json.SelectTokens("$.auditPersonnel01").Should().Contain(DefaultAuditPersonnel01);
            json.SelectTokens("$.auditPersonnel02").Should().Contain(DefaultAuditPersonnel02);
            json.SelectTokens("$.auditPersonnel03").Should().Contain(DefaultAuditPersonnel03);
            json.SelectTokens("$.auditPersonnel04").Should().Contain(DefaultAuditPersonnel04);
            json.SelectTokens("$.companyPersonnel01").Should().Contain(DefaultCompanyPersonnel01);
            json.SelectTokens("$.companyPersonnel02").Should().Contain(DefaultCompanyPersonnel02);
            json.SelectTokens("$.companyPersonnel03").Should().Contain(DefaultCompanyPersonnel03);
            json.SelectTokens("$.companyPersonnel04").Should().Contain(DefaultCompanyPersonnel04);
            json.SelectTokens("$.description").Should().Contain(DefaultDescription);
            json.SelectTokens("$.decisionTaken").Should().Contain(DefaultDecisionTaken);
            json.SelectTokens("$.auditResultMissing").Should().Contain(DefaultAuditResultMissing);
            json.SelectTokens("$.auditEvaluationResult").Should().Contain(DefaultAuditEvaluationResult);
            json.SelectTokens("$.expectedDocument").Should().Contain(DefaultExpectedDocument);
            json.SelectTokens("$.score").Should().Contain(DefaultScore);
        }

        [Fact]
        public async Task GetNonExistingAuditInfo()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/audit-infos/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateAuditInfo()
        {
            // Initialize the database
            await _auditInfoRepository.CreateOrUpdateAsync(_auditInfo);
            await _auditInfoRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _auditInfoRepository.CountAsync();

            // Update the auditInfo
            var updatedAuditInfo = await _auditInfoRepository.QueryHelper().GetOneAsync(it => it.Id == _auditInfo.Id);
            // Disconnect from session so that the updates on updatedAuditInfo are not directly saved in db
            //TODO detach
            updatedAuditInfo.AuditDate = UpdatedAuditDate;
            updatedAuditInfo.AuditPersonnel01 = UpdatedAuditPersonnel01;
            updatedAuditInfo.AuditPersonnel02 = UpdatedAuditPersonnel02;
            updatedAuditInfo.AuditPersonnel03 = UpdatedAuditPersonnel03;
            updatedAuditInfo.AuditPersonnel04 = UpdatedAuditPersonnel04;
            updatedAuditInfo.CompanyPersonnel01 = UpdatedCompanyPersonnel01;
            updatedAuditInfo.CompanyPersonnel02 = UpdatedCompanyPersonnel02;
            updatedAuditInfo.CompanyPersonnel03 = UpdatedCompanyPersonnel03;
            updatedAuditInfo.CompanyPersonnel04 = UpdatedCompanyPersonnel04;
            updatedAuditInfo.Description = UpdatedDescription;
            updatedAuditInfo.DecisionTaken = UpdatedDecisionTaken;
            updatedAuditInfo.AuditResultMissing = UpdatedAuditResultMissing;
            updatedAuditInfo.AuditEvaluationResult = UpdatedAuditEvaluationResult;
            updatedAuditInfo.ExpectedDocument = UpdatedExpectedDocument;
            updatedAuditInfo.Score = UpdatedScore;

            AuditInfoDto updatedAuditInfoDto = _mapper.Map<AuditInfoDto>(updatedAuditInfo);
            var response = await _client.PutAsync($"/api/audit-infos/{_auditInfo.Id}", TestUtil.ToJsonContent(updatedAuditInfoDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the AuditInfo in the database
            var auditInfoList = await _auditInfoRepository.GetAllAsync();
            auditInfoList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testAuditInfo = auditInfoList.Last();
            testAuditInfo.AuditDate.Should().BeCloseTo(UpdatedAuditDate, 1.Milliseconds());
            testAuditInfo.AuditPersonnel01.Should().Be(UpdatedAuditPersonnel01);
            testAuditInfo.AuditPersonnel02.Should().Be(UpdatedAuditPersonnel02);
            testAuditInfo.AuditPersonnel03.Should().Be(UpdatedAuditPersonnel03);
            testAuditInfo.AuditPersonnel04.Should().Be(UpdatedAuditPersonnel04);
            testAuditInfo.CompanyPersonnel01.Should().Be(UpdatedCompanyPersonnel01);
            testAuditInfo.CompanyPersonnel02.Should().Be(UpdatedCompanyPersonnel02);
            testAuditInfo.CompanyPersonnel03.Should().Be(UpdatedCompanyPersonnel03);
            testAuditInfo.CompanyPersonnel04.Should().Be(UpdatedCompanyPersonnel04);
            testAuditInfo.Description.Should().Be(UpdatedDescription);
            testAuditInfo.DecisionTaken.Should().Be(UpdatedDecisionTaken);
            testAuditInfo.AuditResultMissing.Should().Be(UpdatedAuditResultMissing);
            testAuditInfo.AuditEvaluationResult.Should().Be(UpdatedAuditEvaluationResult);
            testAuditInfo.ExpectedDocument.Should().Be(UpdatedExpectedDocument);
            testAuditInfo.Score.Should().Be(UpdatedScore);
        }

        [Fact]
        public async Task UpdateNonExistingAuditInfo()
        {
            var databaseSizeBeforeUpdate = await _auditInfoRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            AuditInfoDto _auditInfoDto = _mapper.Map<AuditInfoDto>(_auditInfo);
            var response = await _client.PutAsync("/api/audit-infos/1", TestUtil.ToJsonContent(_auditInfoDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the AuditInfo in the database
            var auditInfoList = await _auditInfoRepository.GetAllAsync();
            auditInfoList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteAuditInfo()
        {
            // Initialize the database
            await _auditInfoRepository.CreateOrUpdateAsync(_auditInfo);
            await _auditInfoRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _auditInfoRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/audit-infos/{_auditInfo.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var auditInfoList = await _auditInfoRepository.GetAllAsync();
            auditInfoList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(AuditInfo));
            var auditInfo1 = new AuditInfo
            {
                Id = 1L
            };
            var auditInfo2 = new AuditInfo
            {
                Id = auditInfo1.Id
            };
            auditInfo1.Should().Be(auditInfo2);
            auditInfo2.Id = 2L;
            auditInfo1.Should().NotBe(auditInfo2);
            auditInfo1.Id = 0;
            auditInfo1.Should().NotBe(auditInfo2);
        }
    }
}
