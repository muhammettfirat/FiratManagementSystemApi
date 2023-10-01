using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace FiratManagementSystemApi;

[Dependency(ReplaceServices = true)]
public class FiratManagementSystemApiBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "FiratManagementSystemApi";
}
