using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace FiratManagementSystemApi.Blazor.WebAssembly;

[DependsOn(
    typeof(FiratManagementSystemApiBlazorModule),
    typeof(FiratManagementSystemApiHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
    )]
public class FiratManagementSystemApiBlazorWebAssemblyModule : AbpModule
{

}
