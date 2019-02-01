using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SE.Catalog.Repository
{
    public static class DbRepositoryService
    {
        public static void AddRepository<TContext>(this IServiceCollection services, IConfiguration configuration) where TContext : DbContext
        {
            services.AddDbContextPool<TContext>(o =>
                o.UseSqlServer(
                    configuration["Settings:SqlServer:DefaultConnection"],
                    b =>
                    {
                        b.MigrationsAssembly(configuration["Settings:SqlServer:MigrationAssembly"]);
                        b.CommandTimeout(60);
                        b.EnableRetryOnFailure(2);
                    }));
        }

      


        public static void AddRepository(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<CatalogContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CatalogContext")));
        }


    }
}
