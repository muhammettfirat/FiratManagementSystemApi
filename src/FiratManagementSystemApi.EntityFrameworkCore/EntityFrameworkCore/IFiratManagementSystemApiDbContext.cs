using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FiratManagementSystemApi.EntityFrameworkCore;

[ConnectionStringName(FiratManagementSystemApiDbProperties.ConnectionStringName)]
public interface IFiratManagementSystemApiDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
