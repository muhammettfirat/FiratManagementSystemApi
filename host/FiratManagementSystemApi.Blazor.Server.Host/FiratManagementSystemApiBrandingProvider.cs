using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace FiratManagementSystemApi.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class FiratManagementSystemApiBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "FiratManagementSystemApi";
}
