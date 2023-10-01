using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace FiratManagementSystemApi.Blazor.Server;

[DependsOn(
    typeof(AbpAspNetCoreComponentsServerThemingModule),
    typeof(FiratManagementSystemApiBlazorModule)
    )]
public class FiratManagementSystemApiBlazorServerModule : AbpModule
{

}
