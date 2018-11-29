using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using HC.POSCloud.Configuration;
using HC.POSCloud.Web;

namespace HC.POSCloud.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class POSCloudDbContextFactory : IDesignTimeDbContextFactory<POSCloudDbContext>
    {
        public POSCloudDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<POSCloudDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            POSCloudDbContextConfigurer.Configure(builder, configuration.GetConnectionString(POSCloudConsts.ConnectionStringName));

            return new POSCloudDbContext(builder.Options);
        }
    }
}
