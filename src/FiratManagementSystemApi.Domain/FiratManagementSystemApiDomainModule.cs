using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace FiratManagementSystemApi;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(FiratManagementSystemApiDomainSharedModule)
)]
public class FiratManagementSystemApiDomainModule : AbpModule
{

}
