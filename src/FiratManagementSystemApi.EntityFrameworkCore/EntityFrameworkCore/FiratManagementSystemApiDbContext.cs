using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace FiratManagementSystemApi.EntityFrameworkCore;

[ConnectionStringName(FiratManagementSystemApiDbProperties.ConnectionStringName)]
public class FiratManagementSystemApiDbContext : AbpDbContext<FiratManagementSystemApiDbContext>, IFiratManagementSystemApiDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public FiratManagementSystemApiDbContext(DbContextOptions<FiratManagementSystemApiDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureFiratManagementSystemApi();
    }
}
