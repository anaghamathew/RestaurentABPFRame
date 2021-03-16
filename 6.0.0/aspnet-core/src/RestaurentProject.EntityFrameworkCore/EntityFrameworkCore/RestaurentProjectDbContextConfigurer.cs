using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace RestaurentProject.EntityFrameworkCore
{
    public static class RestaurentProjectDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<RestaurentProjectDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<RestaurentProjectDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
