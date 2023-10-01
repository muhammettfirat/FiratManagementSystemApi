using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace FiratManagementSystemApi;

[DependsOn(
    typeof(FiratManagementSystemApiApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class FiratManagementSystemApiHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(FiratManagementSystemApiApplicationContractsModule).Assembly,
            FiratManagementSystemApiRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<FiratManagementSystemApiHttpApiClientModule>();
        });

    }
}
