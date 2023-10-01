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
    public class StockInfosControllerIntTest
    {
        public StockInfosControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _stockInfoRepository = _factory.GetRequiredService<IStockInfoRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            _mapper = config.CreateMapper();

            InitTest();
        }

        private static readonly UNKNOWN_TYPE DefaultRelatedTierID = ;
        private static readonly UNKNOWN_TYPE UpdatedRelatedTierID = ;

        private const string DefaultRelatedFile = "AAAAAAAAAA";
        private const string UpdatedRelatedFile = "BBBBBBBBBB";

        private const string DefaultManufacturingLocationAddress = "AAAAAAAAAA";
        private const string UpdatedManufacturingLocationAddress = "BBBBBBBBBB";

        private const string DefaultManufacturersAddress = "AAAAAAAAAA";
        private const string UpdatedManufacturersAddress = "BBBBBBBBBB";

        private const string DefaultEvaluationDescription = "AAAAAAAAAA";
        private const string UpdatedEvaluationDescription = "BBBBBBBBBB";

        private static readonly DateTime DefaultEvaluationDate = DateTime.UnixEpoch;
        private static readonly DateTime UpdatedEvaluationDate = DateTime.UtcNow;

        private static readonly int? DefaultAuditEvaluationResult = 1;
        private static readonly int? UpdatedAuditEvaluationResult = 2;

        private const string DefaultAuditResultMissing = "AAAAAAAAAA";
        private const string UpdatedAuditResultMissing = "BBBBBBBBBB";

        private const string DefaultExpectedDocument = "AAAAAAAAAA";
        private const string UpdatedExpectedDocument = "BBBBBBBBBB";

        private const string DefaultDecisionTaken = "AAAAAAAAAA";
        private const string UpdatedDecisionTaken = "BBBBBBBBBB";

        private const string DefaultApprovalStatus = "AAAAAAAAAA";
        private const string UpdatedApprovalStatus = "BBBBBBBBBB";

        private readonly AppWebApplicationFactory<TestStartup> _factory;
        private readonly HttpClient _client;
        private readonly IStockInfoRepository _stockInfoRepository;

        private StockInfo _stockInfo;

        private readonly IMapper _mapper;

        private StockInfo CreateEntity()
        {
            return new StockInfo
            {
                RelatedTierID = DefaultRelatedTierID,
                RelatedFile = DefaultRelatedFile,
                ManufacturingLocationAddress = DefaultManufacturingLocationAddress,
                ManufacturersAddress = DefaultManufacturersAddress,
                EvaluationDescription = DefaultEvaluationDescription,
                EvaluationDate = DefaultEvaluationDate,
                AuditEvaluationResult = DefaultAuditEvaluationResult,
                AuditResultMissing = DefaultAuditResultMissing,
                ExpectedDocument = DefaultExpectedDocument,
                DecisionTaken = DefaultDecisionTaken,
                ApprovalStatus = DefaultApprovalStatus,
            };
        }

        private void InitTest()
        {
            _stockInfo = CreateEntity();
        }

        [Fact]
        public async Task CreateStockInfo()
        {
            var databaseSizeBeforeCreate = await _stockInfoRepository.CountAsync();

            // Create the StockInfo
            StockInfoDto _stockInfoDto = _mapper.Map<StockInfoDto>(_stockInfo);
            var response = await _client.PostAsync("/api/stock-infos", TestUtil.ToJsonContent(_stockInfoDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the StockInfo in the database
            var stockInfoList = await _stockInfoRepository.GetAllAsync();
            stockInfoList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testStockInfo = stockInfoList.Last();
            testStockInfo.RelatedTierID.Should().Be(DefaultRelatedTierID);
            testStockInfo.RelatedFile.Should().Be(DefaultRelatedFile);
            testStockInfo.ManufacturingLocationAddress.Should().Be(DefaultManufacturingLocationAddress);
            testStockInfo.ManufacturersAddress.Should().Be(DefaultManufacturersAddress);
            testStockInfo.EvaluationDescription.Should().Be(DefaultEvaluationDescription);
            testStockInfo.EvaluationDate.Should().Be(DefaultEvaluationDate);
            testStockInfo.AuditEvaluationResult.Should().Be(DefaultAuditEvaluationResult);
            testStockInfo.AuditResultMissing.Should().Be(DefaultAuditResultMissing);
            testStockInfo.ExpectedDocument.Should().Be(DefaultExpectedDocument);
            testStockInfo.DecisionTaken.Should().Be(DefaultDecisionTaken);
            testStockInfo.ApprovalStatus.Should().Be(DefaultApprovalStatus);
        }

        [Fact]
        public async Task CreateStockInfoWithExistingId()
        {
            var databaseSizeBeforeCreate = await _stockInfoRepository.CountAsync();
            // Create the StockInfo with an existing ID
            _stockInfo.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            StockInfoDto _stockInfoDto = _mapper.Map<StockInfoDto>(_stockInfo);
            var response = await _client.PostAsync("/api/stock-infos", TestUtil.ToJsonContent(_stockInfoDto));

            // Validate the StockInfo in the database
            var stockInfoList = await _stockInfoRepository.GetAllAsync();
            stockInfoList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task GetAllStockInfos()
        {
            // Initialize the database
            await _stockInfoRepository.CreateOrUpdateAsync(_stockInfo);
            await _stockInfoRepository.SaveChangesAsync();

            // Get all the stockInfoList
            var response = await _client.GetAsync("/api/stock-infos?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_stockInfo.Id);
            json.SelectTokens("$.[*].relatedTierId").Should().Contain(DefaultRelatedTierID);
            json.SelectTokens("$.[*].relatedFile").Should().Contain(DefaultRelatedFile);
            json.SelectTokens("$.[*].manufacturingLocationAddress").Should().Contain(DefaultManufacturingLocationAddress);
            json.SelectTokens("$.[*].manufacturersAddress").Should().Contain(DefaultManufacturersAddress);
            json.SelectTokens("$.[*].evaluationDescription").Should().Contain(DefaultEvaluationDescription);
            json.SelectTokens("$.[*].evaluationDate").Should().Contain(DefaultEvaluationDate);
            json.SelectTokens("$.[*].auditEvaluationResult").Should().Contain(DefaultAuditEvaluationResult);
            json.SelectTokens("$.[*].auditResultMissing").Should().Contain(DefaultAuditResultMissing);
            json.SelectTokens("$.[*].expectedDocument").Should().Contain(DefaultExpectedDocument);
            json.SelectTokens("$.[*].decisionTaken").Should().Contain(DefaultDecisionTaken);
            json.SelectTokens("$.[*].approvalStatus").Should().Contain(DefaultApprovalStatus);
        }

        [Fact]
        public async Task GetStockInfo()
        {
            // Initialize the database
            await _stockInfoRepository.CreateOrUpdateAsync(_stockInfo);
            await _stockInfoRepository.SaveChangesAsync();

            // Get the stockInfo
            var response = await _client.GetAsync($"/api/stock-infos/{_stockInfo.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_stockInfo.Id);
            json.SelectTokens("$.relatedTierId").Should().Contain(DefaultRelatedTierID);
            json.SelectTokens("$.relatedFile").Should().Contain(DefaultRelatedFile);
            json.SelectTokens("$.manufacturingLocationAddress").Should().Contain(DefaultManufacturingLocationAddress);
            json.SelectTokens("$.manufacturersAddress").Should().Contain(DefaultManufacturersAddress);
            json.SelectTokens("$.evaluationDescription").Should().Contain(DefaultEvaluationDescription);
            json.SelectTokens("$.evaluationDate").Should().Contain(DefaultEvaluationDate);
            json.SelectTokens("$.auditEvaluationResult").Should().Contain(DefaultAuditEvaluationResult);
            json.SelectTokens("$.auditResultMissing").Should().Contain(DefaultAuditResultMissing);
            json.SelectTokens("$.expectedDocument").Should().Contain(DefaultExpectedDocument);
            json.SelectTokens("$.decisionTaken").Should().Contain(DefaultDecisionTaken);
            json.SelectTokens("$.approvalStatus").Should().Contain(DefaultApprovalStatus);
        }

        [Fact]
        public async Task GetNonExistingStockInfo()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/stock-infos/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateStockInfo()
        {
            // Initialize the database
            await _stockInfoRepository.CreateOrUpdateAsync(_stockInfo);
            await _stockInfoRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _stockInfoRepository.CountAsync();

            // Update the stockInfo
            var updatedStockInfo = await _stockInfoRepository.QueryHelper().GetOneAsync(it => it.Id == _stockInfo.Id);
            // Disconnect from session so that the updates on updatedStockInfo are not directly saved in db
            //TODO detach
            updatedStockInfo.RelatedTierID = UpdatedRelatedTierID;
            updatedStockInfo.RelatedFile = UpdatedRelatedFile;
            updatedStockInfo.ManufacturingLocationAddress = UpdatedManufacturingLocationAddress;
            updatedStockInfo.ManufacturersAddress = UpdatedManufacturersAddress;
            updatedStockInfo.EvaluationDescription = UpdatedEvaluationDescription;
            updatedStockInfo.EvaluationDate = UpdatedEvaluationDate;
            updatedStockInfo.AuditEvaluationResult = UpdatedAuditEvaluationResult;
            updatedStockInfo.AuditResultMissing = UpdatedAuditResultMissing;
            updatedStockInfo.ExpectedDocument = UpdatedExpectedDocument;
            updatedStockInfo.DecisionTaken = UpdatedDecisionTaken;
            updatedStockInfo.ApprovalStatus = UpdatedApprovalStatus;

            StockInfoDto updatedStockInfoDto = _mapper.Map<StockInfoDto>(updatedStockInfo);
            var response = await _client.PutAsync($"/api/stock-infos/{_stockInfo.Id}", TestUtil.ToJsonContent(updatedStockInfoDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the StockInfo in the database
            var stockInfoList = await _stockInfoRepository.GetAllAsync();
            stockInfoList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testStockInfo = stockInfoList.Last();
            testStockInfo.RelatedTierID.Should().Be(UpdatedRelatedTierID);
            testStockInfo.RelatedFile.Should().Be(UpdatedRelatedFile);
            testStockInfo.ManufacturingLocationAddress.Should().Be(UpdatedManufacturingLocationAddress);
            testStockInfo.ManufacturersAddress.Should().Be(UpdatedManufacturersAddress);
            testStockInfo.EvaluationDescription.Should().Be(UpdatedEvaluationDescription);
            testStockInfo.EvaluationDate.Should().BeCloseTo(UpdatedEvaluationDate, 1.Milliseconds());
            testStockInfo.AuditEvaluationResult.Should().Be(UpdatedAuditEvaluationResult);
            testStockInfo.AuditResultMissing.Should().Be(UpdatedAuditResultMissing);
            testStockInfo.ExpectedDocument.Should().Be(UpdatedExpectedDocument);
            testStockInfo.DecisionTaken.Should().Be(UpdatedDecisionTaken);
            testStockInfo.ApprovalStatus.Should().Be(UpdatedApprovalStatus);
        }

        [Fact]
        public async Task UpdateNonExistingStockInfo()
        {
            var databaseSizeBeforeUpdate = await _stockInfoRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            StockInfoDto _stockInfoDto = _mapper.Map<StockInfoDto>(_stockInfo);
            var response = await _client.PutAsync("/api/stock-infos/1", TestUtil.ToJsonContent(_stockInfoDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the StockInfo in the database
            var stockInfoList = await _stockInfoRepository.GetAllAsync();
            stockInfoList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteStockInfo()
        {
            // Initialize the database
            await _stockInfoRepository.CreateOrUpdateAsync(_stockInfo);
            await _stockInfoRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _stockInfoRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/stock-infos/{_stockInfo.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var stockInfoList = await _stockInfoRepository.GetAllAsync();
            stockInfoList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(StockInfo));
            var stockInfo1 = new StockInfo
            {
                Id = 1L
            };
            var stockInfo2 = new StockInfo
            {
                Id = stockInfo1.Id
            };
            stockInfo1.Should().Be(stockInfo2);
            stockInfo2.Id = 2L;
            stockInfo1.Should().NotBe(stockInfo2);
            stockInfo1.Id = 0;
            stockInfo1.Should().NotBe(stockInfo2);
        }
    }
}
