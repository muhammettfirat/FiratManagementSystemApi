using FiratManagementSystemApi.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FiratManagementSystemApi.Pages;

public abstract class FiratManagementSystemApiPageModel : AbpPageModel
{
    protected FiratManagementSystemApiPageModel()
    {
        LocalizationResourceType = typeof(FiratManagementSystemApiResource);
    }
}
