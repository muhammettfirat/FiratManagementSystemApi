using Volo.Abp.Modularity;

namespace FiratManagementSystemApi;

[DependsOn(
    typeof(FiratManagementSystemApiApplicationModule),
    typeof(FiratManagementSystemApiDomainTestModule)
    )]
public class FiratManagementSystemApiApplicationTestModule : AbpModule
{

}
