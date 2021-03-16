using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using RestaurentProject.Authorization.Roles;
using RestaurentProject.Authorization.Users;
using RestaurentProject.MultiTenancy;
using RestaurentProject.Categories;
using RestaurentProject.Foods;

namespace RestaurentProject.EntityFrameworkCore
{
    public class RestaurentProjectDbContext : AbpZeroDbContext<Tenant, Role, User, RestaurentProjectDbContext>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Foods { get; set; }
        /* Define a DbSet for each entity of the application */

        public RestaurentProjectDbContext(DbContextOptions<RestaurentProjectDbContext> options)
            : base(options)
        {

        }
       

    }
}
