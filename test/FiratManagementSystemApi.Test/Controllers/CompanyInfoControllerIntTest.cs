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
    public class CompanyInfosControllerIntTest
    {
        public CompanyInfosControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _companyInfoRepository = _factory.GetRequiredService<ICompanyInfoRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            _mapper = config.CreateMapper();

            InitTest();
        }

        private static readonly UNKNOWN_TYPE DefaultCustomerType = ;
        private static readonly UNKNOWN_TYPE UpdatedCustomerType = ;

        private static readonly UNKNOWN_TYPE DefaultCustomerCode = ;
        private static readonly UNKNOWN_TYPE UpdatedCustomerCode = ;

        private static readonly DateTime DefaultStartedWorkingDate = DateTime.UnixEpoch;
        private static readonly DateTime UpdatedStartedWorkingDate = DateTime.UtcNow;

        private static readonly DateTime DefaultAuditPeriodMonth = DateTime.UnixEpoch;
        private static readonly DateTime UpdatedAuditPeriodMonth = DateTime.UtcNow;

        private const string DefaultApprovalStatus = "AAAAAAAAAA";
        private const string UpdatedApprovalStatus = "BBBBBBBBBB";

        private readonly AppWebApplicationFactory<TestStartup> _factory;
        private readonly HttpClient _client;
        private readonly ICompanyInfoRepository _companyInfoRepository;

        private CompanyInfo _companyInfo;

        private readonly IMapper _mapper;

        private CompanyInfo CreateEntity()
        {
            return new CompanyInfo
            {
                CustomerType = DefaultCustomerType,
                CustomerCode = DefaultCustomerCode,
                StartedWorkingDate = DefaultStartedWorkingDate,
                AuditPeriodMonth = DefaultAuditPeriodMonth,
                ApprovalStatus = DefaultApprovalStatus,
            };
        }

        private void InitTest()
        {
            _companyInfo = CreateEntity();
        }

        [Fact]
        public async Task CreateCompanyInfo()
        {
            var databaseSizeBeforeCreate = await _companyInfoRepository.CountAsync();

            // Create the CompanyInfo
            CompanyInfoDto _companyInfoDto = _mapper.Map<CompanyInfoDto>(_companyInfo);
            var response = await _client.PostAsync("/api/company-infos", TestUtil.ToJsonContent(_companyInfoDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the CompanyInfo in the database
            var companyInfoList = await _companyInfoRepository.GetAllAsync();
            companyInfoList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testCompanyInfo = companyInfoList.Last();
            testCompanyInfo.CustomerType.Should().Be(DefaultCustomerType);
            testCompanyInfo.CustomerCode.Should().Be(DefaultCustomerCode);
            testCompanyInfo.StartedWorkingDate.Should().Be(DefaultStartedWorkingDate);
            testCompanyInfo.AuditPeriodMonth.Should().Be(DefaultAuditPeriodMonth);
            testCompanyInfo.ApprovalStatus.Should().Be(DefaultApprovalStatus);
        }

        [Fact]
        public async Task CreateCompanyInfoWithExistingId()
        {
            var databaseSizeBeforeCreate = await _companyInfoRepository.CountAsync();
            // Create the CompanyInfo with an existing ID
            _companyInfo.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            CompanyInfoDto _companyInfoDto = _mapper.Map<CompanyInfoDto>(_companyInfo);
            var response = await _client.PostAsync("/api/company-infos", TestUtil.ToJsonContent(_companyInfoDto));

            // Validate the CompanyInfo in the database
            var companyInfoList = await _companyInfoRepository.GetAllAsync();
            companyInfoList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task GetAllCompanyInfos()
        {
            // Initialize the database
            await _companyInfoRepository.CreateOrUpdateAsync(_companyInfo);
            await _companyInfoRepository.SaveChangesAsync();

            // Get all the companyInfoList
            var response = await _client.GetAsync("/api/company-infos?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_companyInfo.Id);
            json.SelectTokens("$.[*].customerType").Should().Contain(DefaultCustomerType);
            json.SelectTokens("$.[*].customerCode").Should().Contain(DefaultCustomerCode);
            json.SelectTokens("$.[*].startedWorkingDate").Should().Contain(DefaultStartedWorkingDate);
            json.SelectTokens("$.[*].auditPeriodMonth").Should().Contain(DefaultAuditPeriodMonth);
            json.SelectTokens("$.[*].approvalStatus").Should().Contain(DefaultApprovalStatus);
        }

        [Fact]
        public async Task GetCompanyInfo()
        {
            // Initialize the database
            await _companyInfoRepository.CreateOrUpdateAsync(_companyInfo);
            await _companyInfoRepository.SaveChangesAsync();

            // Get the companyInfo
            var response = await _client.GetAsync($"/api/company-infos/{_companyInfo.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_companyInfo.Id);
            json.SelectTokens("$.customerType").Should().Contain(DefaultCustomerType);
            json.SelectTokens("$.customerCode").Should().Contain(DefaultCustomerCode);
            json.SelectTokens("$.startedWorkingDate").Should().Contain(DefaultStartedWorkingDate);
            json.SelectTokens("$.auditPeriodMonth").Should().Contain(DefaultAuditPeriodMonth);
            json.SelectTokens("$.approvalStatus").Should().Contain(DefaultApprovalStatus);
        }

        [Fact]
        public async Task GetNonExistingCompanyInfo()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/company-infos/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateCompanyInfo()
        {
            // Initialize the database
            await _companyInfoRepository.CreateOrUpdateAsync(_companyInfo);
            await _companyInfoRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _companyInfoRepository.CountAsync();

            // Update the companyInfo
            var updatedCompanyInfo = await _companyInfoRepository.QueryHelper().GetOneAsync(it => it.Id == _companyInfo.Id);
            // Disconnect from session so that the updates on updatedCompanyInfo are not directly saved in db
            //TODO detach
            updatedCompanyInfo.CustomerType = UpdatedCustomerType;
            updatedCompanyInfo.CustomerCode = UpdatedCustomerCode;
            updatedCompanyInfo.StartedWorkingDate = UpdatedStartedWorkingDate;
            updatedCompanyInfo.AuditPeriodMonth = UpdatedAuditPeriodMonth;
            updatedCompanyInfo.ApprovalStatus = UpdatedApprovalStatus;

            CompanyInfoDto updatedCompanyInfoDto = _mapper.Map<CompanyInfoDto>(updatedCompanyInfo);
            var response = await _client.PutAsync($"/api/company-infos/{_companyInfo.Id}", TestUtil.ToJsonContent(updatedCompanyInfoDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the CompanyInfo in the database
            var companyInfoList = await _companyInfoRepository.GetAllAsync();
            companyInfoList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testCompanyInfo = companyInfoList.Last();
            testCompanyInfo.CustomerType.Should().Be(UpdatedCustomerType);
            testCompanyInfo.CustomerCode.Should().Be(UpdatedCustomerCode);
            testCompanyInfo.StartedWorkingDate.Should().BeCloseTo(UpdatedStartedWorkingDate, 1.Milliseconds());
            testCompanyInfo.AuditPeriodMonth.Should().BeCloseTo(UpdatedAuditPeriodMonth, 1.Milliseconds());
            testCompanyInfo.ApprovalStatus.Should().Be(UpdatedApprovalStatus);
        }

        [Fact]
        public async Task UpdateNonExistingCompanyInfo()
        {
            var databaseSizeBeforeUpdate = await _companyInfoRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            CompanyInfoDto _companyInfoDto = _mapper.Map<CompanyInfoDto>(_companyInfo);
            var response = await _client.PutAsync("/api/company-infos/1", TestUtil.ToJsonContent(_companyInfoDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the CompanyInfo in the database
            var companyInfoList = await _companyInfoRepository.GetAllAsync();
            companyInfoList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteCompanyInfo()
        {
            // Initialize the database
            await _companyInfoRepository.CreateOrUpdateAsync(_companyInfo);
            await _companyInfoRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _companyInfoRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/company-infos/{_companyInfo.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var companyInfoList = await _companyInfoRepository.GetAllAsync();
            companyInfoList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(CompanyInfo));
            var companyInfo1 = new CompanyInfo
            {
                Id = 1L
            };
            var companyInfo2 = new CompanyInfo
            {
                Id = companyInfo1.Id
            };
            companyInfo1.Should().Be(companyInfo2);
            companyInfo2.Id = 2L;
            companyInfo1.Should().NotBe(companyInfo2);
            companyInfo1.Id = 0;
            companyInfo1.Should().NotBe(companyInfo2);
        }
    }
}
