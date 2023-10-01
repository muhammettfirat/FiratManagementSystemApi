using FiratManagementSystemApi.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FiratManagementSystemApi;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(FiratManagementSystemApiEntityFrameworkCoreTestModule)
    )]
public class FiratManagementSystemApiDomainTestModule : AbpModule
{

}
