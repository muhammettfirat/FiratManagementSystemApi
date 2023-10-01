using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace FiratManagementSystemApi;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(FiratManagementSystemApiHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class FiratManagementSystemApiConsoleApiClientModule : AbpModule
{

}
