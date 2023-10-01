
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
    public class DocumentTypesControllerIntTest
    {
        public DocumentTypesControllerIntTest()
        {
            _factory = new AppWebApplicationFactory<TestStartup>().WithMockUser();
            _client = _factory.CreateClient();

            _documentTypeRepository = _factory.GetRequiredService<IDocumentTypeRepository>();

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
        private readonly IDocumentTypeRepository _documentTypeRepository;

        private DocumentType _documentType;

        private readonly IMapper _mapper;

        private DocumentType CreateEntity()
        {
            return new DocumentType
            {
                Code = DefaultCode,
                Definition = DefaultDefinition,
            };
        }

        private void InitTest()
        {
            _documentType = CreateEntity();
        }

        [Fact]
        public async Task CreateDocumentType()
        {
            var databaseSizeBeforeCreate = await _documentTypeRepository.CountAsync();

            // Create the DocumentType
            DocumentTypeDto _documentTypeDto = _mapper.Map<DocumentTypeDto>(_documentType);
            var response = await _client.PostAsync("/api/document-types", TestUtil.ToJsonContent(_documentTypeDto));
            response.StatusCode.Should().Be(HttpStatusCode.Created);

            // Validate the DocumentType in the database
            var documentTypeList = await _documentTypeRepository.GetAllAsync();
            documentTypeList.Count().Should().Be(databaseSizeBeforeCreate + 1);
            var testDocumentType = documentTypeList.Last();
            testDocumentType.Code.Should().Be(DefaultCode);
            testDocumentType.Definition.Should().Be(DefaultDefinition);
        }

        [Fact]
        public async Task CreateDocumentTypeWithExistingId()
        {
            var databaseSizeBeforeCreate = await _documentTypeRepository.CountAsync();
            // Create the DocumentType with an existing ID
            _documentType.Id = 1L;

            // An entity with an existing ID cannot be created, so this API call must fail
            DocumentTypeDto _documentTypeDto = _mapper.Map<DocumentTypeDto>(_documentType);
            var response = await _client.PostAsync("/api/document-types", TestUtil.ToJsonContent(_documentTypeDto));

            // Validate the DocumentType in the database
            var documentTypeList = await _documentTypeRepository.GetAllAsync();
            documentTypeList.Count().Should().Be(databaseSizeBeforeCreate);
        }

        [Fact]
        public async Task CheckCodeIsRequired()
        {
            var databaseSizeBeforeTest = await _documentTypeRepository.CountAsync();

            // Set the field to null
            _documentType.Code = null;

            // Create the DocumentType, which fails.
            DocumentTypeDto _documentTypeDto = _mapper.Map<DocumentTypeDto>(_documentType);
            var response = await _client.PostAsync("/api/document-types", TestUtil.ToJsonContent(_documentTypeDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var documentTypeList = await _documentTypeRepository.GetAllAsync();
            documentTypeList.Count().Should().Be(databaseSizeBeforeTest);
        }

        [Fact]
        public async Task CheckDefinitionIsRequired()
        {
            var databaseSizeBeforeTest = await _documentTypeRepository.CountAsync();

            // Set the field to null
            _documentType.Definition = null;

            // Create the DocumentType, which fails.
            DocumentTypeDto _documentTypeDto = _mapper.Map<DocumentTypeDto>(_documentType);
            var response = await _client.PostAsync("/api/document-types", TestUtil.ToJsonContent(_documentTypeDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var documentTypeList = await _documentTypeRepository.GetAllAsync();
            documentTypeList.Count().Should().Be(databaseSizeBeforeTest);
        }

        [Fact]
        public async Task GetAllDocumentTypes()
        {
            // Initialize the database
            await _documentTypeRepository.CreateOrUpdateAsync(_documentType);
            await _documentTypeRepository.SaveChangesAsync();

            // Get all the documentTypeList
            var response = await _client.GetAsync("/api/document-types?sort=id,desc");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.[*].id").Should().Contain(_documentType.Id);
            json.SelectTokens("$.[*].code").Should().Contain(DefaultCode);
            json.SelectTokens("$.[*].definition").Should().Contain(DefaultDefinition);
        }

        [Fact]
        public async Task GetDocumentType()
        {
            // Initialize the database
            await _documentTypeRepository.CreateOrUpdateAsync(_documentType);
            await _documentTypeRepository.SaveChangesAsync();

            // Get the documentType
            var response = await _client.GetAsync($"/api/document-types/{_documentType.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = JToken.Parse(await response.Content.ReadAsStringAsync());
            json.SelectTokens("$.id").Should().Contain(_documentType.Id);
            json.SelectTokens("$.code").Should().Contain(DefaultCode);
            json.SelectTokens("$.definition").Should().Contain(DefaultDefinition);
        }

        [Fact]
        public async Task GetNonExistingDocumentType()
        {
            var maxValue = long.MaxValue;
            var response = await _client.GetAsync("/api/document-types/" + maxValue);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task UpdateDocumentType()
        {
            // Initialize the database
            await _documentTypeRepository.CreateOrUpdateAsync(_documentType);
            await _documentTypeRepository.SaveChangesAsync();
            var databaseSizeBeforeUpdate = await _documentTypeRepository.CountAsync();

            // Update the documentType
            var updatedDocumentType = await _documentTypeRepository.QueryHelper().GetOneAsync(it => it.Id == _documentType.Id);
            // Disconnect from session so that the updates on updatedDocumentType are not directly saved in db
            //TODO detach
            updatedDocumentType.Code = UpdatedCode;
            updatedDocumentType.Definition = UpdatedDefinition;

            DocumentTypeDto updatedDocumentTypeDto = _mapper.Map<DocumentTypeDto>(updatedDocumentType);
            var response = await _client.PutAsync($"/api/document-types/{_documentType.Id}", TestUtil.ToJsonContent(updatedDocumentTypeDto));
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            // Validate the DocumentType in the database
            var documentTypeList = await _documentTypeRepository.GetAllAsync();
            documentTypeList.Count().Should().Be(databaseSizeBeforeUpdate);
            var testDocumentType = documentTypeList.Last();
            testDocumentType.Code.Should().Be(UpdatedCode);
            testDocumentType.Definition.Should().Be(UpdatedDefinition);
        }

        [Fact]
        public async Task UpdateNonExistingDocumentType()
        {
            var databaseSizeBeforeUpdate = await _documentTypeRepository.CountAsync();

            // If the entity doesn't have an ID, it will throw BadRequestAlertException
            DocumentTypeDto _documentTypeDto = _mapper.Map<DocumentTypeDto>(_documentType);
            var response = await _client.PutAsync("/api/document-types/1", TestUtil.ToJsonContent(_documentTypeDto));
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            // Validate the DocumentType in the database
            var documentTypeList = await _documentTypeRepository.GetAllAsync();
            documentTypeList.Count().Should().Be(databaseSizeBeforeUpdate);
        }

        [Fact]
        public async Task DeleteDocumentType()
        {
            // Initialize the database
            await _documentTypeRepository.CreateOrUpdateAsync(_documentType);
            await _documentTypeRepository.SaveChangesAsync();
            var databaseSizeBeforeDelete = await _documentTypeRepository.CountAsync();

            var response = await _client.DeleteAsync($"/api/document-types/{_documentType.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            // Validate the database is empty
            var documentTypeList = await _documentTypeRepository.GetAllAsync();
            documentTypeList.Count().Should().Be(databaseSizeBeforeDelete - 1);
        }

        [Fact]
        public void EqualsVerifier()
        {
            TestUtil.EqualsVerifier(typeof(DocumentType));
            var documentType1 = new DocumentType
            {
                Id = 1L
            };
            var documentType2 = new DocumentType
            {
                Id = documentType1.Id
            };
            documentType1.Should().Be(documentType2);
            documentType2.Id = 2L;
            documentType1.Should().NotBe(documentType2);
            documentType1.Id = 0;
            documentType1.Should().NotBe(documentType2);
        }
    }
}
