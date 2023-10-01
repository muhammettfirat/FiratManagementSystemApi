using FiratManagementSystemApi.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace FiratManagementSystemApi;

public abstract class FiratManagementSystemApiController : AbpControllerBase
{
    protected FiratManagementSystemApiController()
    {
        LocalizationResource = typeof(FiratManagementSystemApiResource);
    }
}
