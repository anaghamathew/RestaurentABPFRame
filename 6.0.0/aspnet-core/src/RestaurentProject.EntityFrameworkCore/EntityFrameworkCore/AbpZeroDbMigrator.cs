using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Abp.MultiTenancy;
using Abp.Zero.EntityFrameworkCore;

namespace RestaurentProject.EntityFrameworkCore
{
    public class AbpZeroDbMigrator : AbpZeroDbMigrator<RestaurentProjectDbContext>
    {
        public AbpZeroDbMigrator(
            IUnitOfWorkManager unitOfWorkManager,
            IDbPerTenantConnectionStringResolver connectionStringResolver,
            IDbContextResolver dbContextResolver)
            : base(
                unitOfWorkManager,
                connectionStringResolver,
                dbContextResolver)
        {
        }
    }
}
