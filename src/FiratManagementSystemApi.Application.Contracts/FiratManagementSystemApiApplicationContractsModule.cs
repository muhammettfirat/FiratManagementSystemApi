using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace FiratManagementSystemApi;

[DependsOn(
    typeof(FiratManagementSystemApiDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class FiratManagementSystemApiApplicationContractsModule : AbpModule
{

}
