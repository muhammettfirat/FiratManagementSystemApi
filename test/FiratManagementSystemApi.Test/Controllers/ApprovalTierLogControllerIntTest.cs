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
    public class ApprovalTierLogsControllerIntTest
    {
        public ApprovalTierLogsControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _approvalTierLogRepository = _factory.GetRequiredService<IApprovalTierLogRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            _mapper = config.CreateMapper();

            InitTest();
        }

        private static readonly UNKNOWN_TYPE DefaultRelatedId = ;
        private static readonly UNKNOWN_TYPE UpdatedRelatedId = ;

        private const string DefaultRelatedFileType = "AAAAAAAAAA";
        private const string UpdatedRelatedFileType = "BBBBBBBBBB";

        private static readonly DateTime DefaultAuditDate = DateTime.UnixEpoch;
        private static readonly DateTime UpdatedAuditDate = DateTime.UtcNow;

        private static readonly UNKNOWN_TYPE DefaultApprovalPersonnelId = ;
        private static readonly UNKNOWN_TYPE UpdatedApprovalPersonnelId = ;

        private const string DefaultApprovalStatus = "AAAAAAAAAA";
        private const string UpdatedApprovalStatus = "BBBBBBBBBB";

        private const string DefaultApprovalTierName = "AAAAAAAAAA";
        private const string UpdatedApprovalTierName = "BBBBBBBBBB";

        private static readonly DateTime DefaultOperationDate = DateTime.UnixEpoch;
        private static readonly DateTime UpdatedOperationDate = DateTime.UtcNow;

        private readonly AppWebApplicationFactory<TestStartup> _factory;
        private readonly HttpClient _client;
        private readonly IApprovalTierLogRepository _approvalTierLogRepository;

        private ApprovalTierLog _approvalTierLog;

        private readonly IMapper _mapper;

        private ApprovalTierLog CreateEntity()
        {
            return new ApprovalTierLog
            {
                RelatedId = DefaultRelatedId,
                RelatedFileType = DefaultRelatedFileType,
                AuditDate = DefaultAuditDate,
                ApprovalPersonnelId = DefaultApprovalPersonnelId,
                ApprovalStatus = DefaultApprovalStatus,
                ApprovalTierName = DefaultApprovalTierName,
                OperationDate = DefaultOperationDate,
            };
        }

        private void InitTest()
        {
            _approvalTierLog = CreateEntity();
        }

        [Fact]
        public async Task CreateApprovalTierLog()
        {
            var databaseSizeBeforeCreate = await _approvalTierLogRepository.CountAsync();

            // Create the ApprovalTierLog
            ApprovalTierLogDto _approvalTierLogDto = _mapper.Map<ApprovalTierLogDto>(_approvalTierLog);
            var response = await _client.PostAsync("/api/approval-tier-logs", TestUtil.ToJsonContent(_approvalTierLogDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the ApprovalTierLog in the database
            var approvalTierLogList = await _approvalTierLogRepository.GetAllAsync();
            approvalTierLogList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testApprovalTierLog = approvalTierLogList.Last();
            testApprovalTierLog.RelatedId.Should().Be(DefaultRelatedId);
            testApprovalTierLog.RelatedFileType.Should().Be(DefaultRelatedFileType);
            testApprovalTierLog.AuditDate.Should().Be(DefaultAuditDate);
            testApprovalTierLog.ApprovalPersonnelId.Should().Be(DefaultApprovalPersonnelId);
            testApprovalTierLog.ApprovalStatus.Should().Be(DefaultApprovalStatus);
            testApprovalTierLog.ApprovalTierName.Should().Be(DefaultApprovalTierName);
            testApprovalTierLog.OperationDate.Should().Be(DefaultOperationDate);
        }

        [Fact]
        public async Task CreateApprovalTierLogWithExistingId()
        {
            var databaseSizeBeforeCreate = await _approvalTierLogRepository.CountAsync();
            // Create the ApprovalTierLog with an existing ID
            _approvalTierLog.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            ApprovalTierLogDto _approvalTierLogDto = _mapper.Map<ApprovalTierLogDto>(_approvalTierLog);
            var response = await _client.PostAsync("/api/approval-tier-logs", TestUtil.ToJsonContent(_approvalTierLogDto));

            // Validate the ApprovalTierLog in the database
            var approvalTierLogList = await _approvalTierLogRepository.GetAllAsync();
            approvalTierLogList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task GetAllApprovalTierLogs()
        {
            // Initialize the database
            await _approvalTierLogRepository.CreateOrUpdateAsync(_approvalTierLog);
            await _approvalTierLogRepository.SaveChangesAsync();

            // Get all the approvalTierLogList
            var response = await _client.GetAsync("/api/approval-tier-logs?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_approvalTierLog.Id);
            json.SelectTokens("$.[*].relatedId").Should().Contain(DefaultRelatedId);
            json.SelectTokens("$.[*].relatedFileType").Should().Contain(DefaultRelatedFileType);
            json.SelectTokens("$.[*].auditDate").Should().Contain(DefaultAuditDate);
            json.SelectTokens("$.[*].approvalPersonnelId").Should().Contain(DefaultApprovalPersonnelId);
            json.SelectTokens("$.[*].approvalStatus").Should().Contain(DefaultApprovalStatus);
            json.SelectTokens("$.[*].approvalTierName").Should().Contain(DefaultApprovalTierName);
            json.SelectTokens("$.[*].operationDate").Should().Contain(DefaultOperationDate);
        }

        [Fact]
        public async Task GetApprovalTierLog()
        {
            // Initialize the database
            await _approvalTierLogRepository.CreateOrUpdateAsync(_approvalTierLog);
            await _approvalTierLogRepository.SaveChangesAsync();

            // Get the approvalTierLog
            var response = await _client.GetAsync($"/api/approval-tier-logs/{_approvalTierLog.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_approvalTierLog.Id);
            json.SelectTokens("$.relatedId").Should().Contain(DefaultRelatedId);
            json.SelectTokens("$.relatedFileType").Should().Contain(DefaultRelatedFileType);
            json.SelectTokens("$.auditDate").Should().Contain(DefaultAuditDate);
            json.SelectTokens("$.approvalPersonnelId").Should().Contain(DefaultApprovalPersonnelId);
            json.SelectTokens("$.approvalStatus").Should().Contain(DefaultApprovalStatus);
            json.SelectTokens("$.approvalTierName").Should().Contain(DefaultApprovalTierName);
            json.SelectTokens("$.operationDate").Should().Contain(DefaultOperationDate);
        }

        [Fact]
        public async Task GetNonExistingApprovalTierLog()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/approval-tier-logs/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateApprovalTierLog()
        {
            // Initialize the database
            await _approvalTierLogRepository.CreateOrUpdateAsync(_approvalTierLog);
            await _approvalTierLogRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _approvalTierLogRepository.CountAsync();

            // Update the approvalTierLog
            var updatedApprovalTierLog = await _approvalTierLogRepository.QueryHelper().GetOneAsync(it => it.Id == _approvalTierLog.Id);
            // Disconnect from session so that the updates on updatedApprovalTierLog are not directly saved in db
            //TODO detach
            updatedApprovalTierLog.RelatedId = UpdatedRelatedId;
            updatedApprovalTierLog.RelatedFileType = UpdatedRelatedFileType;
            updatedApprovalTierLog.AuditDate = UpdatedAuditDate;
            updatedApprovalTierLog.ApprovalPersonnelId = UpdatedApprovalPersonnelId;
            updatedApprovalTierLog.ApprovalStatus = UpdatedApprovalStatus;
            updatedApprovalTierLog.ApprovalTierName = UpdatedApprovalTierName;
            updatedApprovalTierLog.OperationDate = UpdatedOperationDate;

            ApprovalTierLogDto updatedApprovalTierLogDto = _mapper.Map<ApprovalTierLogDto>(updatedApprovalTierLog);
            var response = await _client.PutAsync($"/api/approval-tier-logs/{_approvalTierLog.Id}", TestUtil.ToJsonContent(updatedApprovalTierLogDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the ApprovalTierLog in the database
            var approvalTierLogList = await _approvalTierLogRepository.GetAllAsync();
            approvalTierLogList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testApprovalTierLog = approvalTierLogList.Last();
            testApprovalTierLog.RelatedId.Should().Be(UpdatedRelatedId);
            testApprovalTierLog.RelatedFileType.Should().Be(UpdatedRelatedFileType);
            testApprovalTierLog.AuditDate.Should().BeCloseTo(UpdatedAuditDate, 1.Milliseconds());
            testApprovalTierLog.ApprovalPersonnelId.Should().Be(UpdatedApprovalPersonnelId);
            testApprovalTierLog.ApprovalStatus.Should().Be(UpdatedApprovalStatus);
            testApprovalTierLog.ApprovalTierName.Should().Be(UpdatedApprovalTierName);
            testApprovalTierLog.OperationDate.Should().BeCloseTo(UpdatedOperationDate, 1.Milliseconds());
        }

        [Fact]
        public async Task UpdateNonExistingApprovalTierLog()
        {
            var databaseSizeBeforeUpdate = await _approvalTierLogRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            ApprovalTierLogDto _approvalTierLogDto = _mapper.Map<ApprovalTierLogDto>(_approvalTierLog);
            var response = await _client.PutAsync("/api/approval-tier-logs/1", TestUtil.ToJsonContent(_approvalTierLogDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the ApprovalTierLog in the database
            var approvalTierLogList = await _approvalTierLogRepository.GetAllAsync();
            approvalTierLogList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteApprovalTierLog()
        {
            // Initialize the database
            await _approvalTierLogRepository.CreateOrUpdateAsync(_approvalTierLog);
            await _approvalTierLogRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _approvalTierLogRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/approval-tier-logs/{_approvalTierLog.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var approvalTierLogList = await _approvalTierLogRepository.GetAllAsync();
            approvalTierLogList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(ApprovalTierLog));
            var approvalTierLog1 = new ApprovalTierLog
            {
                Id = 1L
            };
            var approvalTierLog2 = new ApprovalTierLog
            {
                Id = approvalTierLog1.Id
            };
            approvalTierLog1.Should().Be(approvalTierLog2);
            approvalTierLog2.Id = 2L;
            approvalTierLog1.Should().NotBe(approvalTierLog2);
            approvalTierLog1.Id = 0;
            approvalTierLog1.Should().NotBe(approvalTierLog2);
        }
    }
}
