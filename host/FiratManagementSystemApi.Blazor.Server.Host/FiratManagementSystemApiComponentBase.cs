using FiratManagementSystemApi.Localization;
using Volo.Abp.AspNetCore.Components;

namespace FiratManagementSystemApi.Blazor.Server.Host;

public abstract class FiratManagementSystemApiComponentBase : AbpComponentBase
{
    protected FiratManagementSystemApiComponentBase()
    {
        LocalizationResource = typeof(FiratManagementSystemApiResource);
    }
}
