using FiratManagementSystemApi.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace FiratManagementSystemApi.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class FiratManagementSystemApiPageModel : AbpPageModel
{
    protected FiratManagementSystemApiPageModel()
    {
        LocalizationResourceType = typeof(FiratManagementSystemApiResource);
        ObjectMapperContext = typeof(FiratManagementSystemApiWebModule);
    }
}
