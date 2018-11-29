using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using HC.POSCloud.Authorization.Roles;
using HC.POSCloud.Authorization.Users;
using HC.POSCloud.MultiTenancy;

namespace HC.POSCloud.EntityFrameworkCore
{
    public class POSCloudDbContext : AbpZeroDbContext<Tenant, Role, User, POSCloudDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public POSCloudDbContext(DbContextOptions<POSCloudDbContext> options)
            : base(options)
        {
        }
    }
}
