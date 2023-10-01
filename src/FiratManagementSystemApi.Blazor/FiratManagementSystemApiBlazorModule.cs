using Microsoft.Extensions.DependencyInjection;
using FiratManagementSystemApi.Blazor.Menus;
using Volo.Abp.AspNetCore.Components.Web.Theming;
using Volo.Abp.AspNetCore.Components.Web.Theming.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace FiratManagementSystemApi.Blazor;

[DependsOn(
    typeof(FiratManagementSystemApiApplicationContractsModule),
    typeof(AbpAspNetCoreComponentsWebThemingModule),
    typeof(AbpAutoMapperModule)
    )]
public class FiratManagementSystemApiBlazorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<FiratManagementSystemApiBlazorModule>();

        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<FiratManagementSystemApiBlazorAutoMapperProfile>(validate: true);
        });

        Configure<AbpNavigationOptions>(options =>
        {
            options.MenuContributors.Add(new FiratManagementSystemApiMenuContributor());
        });

        Configure<AbpRouterOptions>(options =>
        {
            options.AdditionalAssemblies.Add(typeof(FiratManagementSystemApiBlazorModule).Assembly);
        });
    }
}
