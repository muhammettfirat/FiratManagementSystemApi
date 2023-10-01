using FiratManagementSystemApi.Localization;
using Volo.Abp.Application.Services;

namespace FiratManagementSystemApi;

public abstract class FiratManagementSystemApiAppService : ApplicationService
{
    protected FiratManagementSystemApiAppService()
    {
        LocalizationResource = typeof(FiratManagementSystemApiResource);
        ObjectMapperContext = typeof(FiratManagementSystemApiApplicationModule);
    }
}
