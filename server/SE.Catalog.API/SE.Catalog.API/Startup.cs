using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SE.Catalog.Contracts;
using SE.Catalog.Repository;
using Microsoft.AspNetCore.Http;

namespace SE.Catalog.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddRepository(Configuration);

            services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // services.AddDbContext<CatalogContext>(options =>
            //     options.UseSqlServer(Configuration.GetConnectionString("CatalogContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
          //  InitMigration(app, Configuration, (Action<CatalogContext, IConfiguration>)DbRepositoryService.Seed(null,Configuration));
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();
            app.UseMvc();
        }

       
    }
}
