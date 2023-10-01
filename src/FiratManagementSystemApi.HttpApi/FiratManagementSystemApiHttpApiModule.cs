using Localization.Resources.AbpUi;
using FiratManagementSystemApi.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace FiratManagementSystemApi;

[DependsOn(
    typeof(FiratManagementSystemApiApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class FiratManagementSystemApiHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(FiratManagementSystemApiHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<FiratManagementSystemApiResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
