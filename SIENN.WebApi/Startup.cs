using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIENN.DbAccess.Context;
using SIENN.DbAccess.Entities;
using SIENN.DbAccess.Mapping;
using SIENN.DbAccess.UnitOfWork;
using SIENN.Services;
using SIENN.Services.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace SIENN.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "SIENN Recruitment API"
                });
            });

            services.AddDbContext<StoreDbContext>(options => 
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"),
                x => x.MigrationsAssembly("SIENN.DbAccess")));

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DomainProfile());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(ICategoryService<Category>), typeof(CategoryService));
            services.AddScoped(typeof(IProductService<Product>), typeof(ProductService));
            services.AddScoped(typeof(ITypeService<Type>), typeof(TypeService));
            services.AddScoped(typeof(IUnitService<Unit>), typeof(UnitService));

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SIENN Recruitment API v1");
            });

            app.UseMvc();
        }
    }
}
