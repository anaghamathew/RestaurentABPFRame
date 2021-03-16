using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RestaurentProject.Configuration;
using RestaurentProject.Web;

namespace RestaurentProject.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class RestaurentProjectDbContextFactory : IDesignTimeDbContextFactory<RestaurentProjectDbContext>
    {
        public RestaurentProjectDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<RestaurentProjectDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            RestaurentProjectDbContextConfigurer.Configure(builder, configuration.GetConnectionString(RestaurentProjectConsts.ConnectionStringName));

            return new RestaurentProjectDbContext(builder.Options);
        }
    }
}
