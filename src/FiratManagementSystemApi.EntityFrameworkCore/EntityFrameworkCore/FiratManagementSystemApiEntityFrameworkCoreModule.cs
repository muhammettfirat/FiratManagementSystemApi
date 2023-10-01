using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace FiratManagementSystemApi.EntityFrameworkCore;

[DependsOn(
    typeof(FiratManagementSystemApiDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class FiratManagementSystemApiEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<FiratManagementSystemApiDbContext>(options =>
        {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
        });
    }
}
