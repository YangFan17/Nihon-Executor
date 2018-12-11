using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using HC.POSCloud.Authorization.Roles;
using HC.POSCloud.Authorization.Users;
using HC.POSCloud.MultiTenancy;
using HC.POSCloud.Products;
using HC.POSCloud.ProductTags;
using HC.POSCloud.Retailers;
using HC.POSCloud.Members;

namespace HC.POSCloud.EntityFrameworkCore
{
    public class POSCloudDbContext : AbpZeroDbContext<Tenant, Role, User, POSCloudDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public POSCloudDbContext(DbContextOptions<POSCloudDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductTag> ProductTags { get; set; }
        public virtual DbSet<Retailer> Retailers { get; set; }
        public virtual DbSet<Member> Members { get; set; }
    }
}
