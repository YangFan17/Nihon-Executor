using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace HC.POSCloud.EntityFrameworkCore
{
    public static class POSCloudDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<POSCloudDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<POSCloudDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}
