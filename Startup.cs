using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Microsoft.OpenApi.Models;
using sedes.Data;
using sedes.Models;
using sedes.Models.Sap;

namespace sedes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var mapconfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ZSeat, Seat>().ReverseMap();

            });
            // only during development, validate your mappings; remove it before release
            mapconfiguration.AssertConfigurationIsValid();
            // use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself
            var mapper = mapconfiguration.CreateMapper();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddOData(opt => opt.AddRouteComponents("odata", GetEdmModel()).EnableQueryFeatures());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "sedes", Version = "v1" });
            });

            services.AddDbContext<SedesContext>(options =>
                    options.UseSqlite(Configuration.GetConnectionString("SedesDbConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "sedes v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new();
            //builder.EntityType<Building>().HasKey(c => c.Id).HasMany<Room>(c => c.Rooms);
            //builder.EntityType<Room>().HasKey(c => c.Id).HasMany(c => c.Seats);
            //builder.EntityType<Seat>().HasKey(c => c.Id);
            builder.EntitySet<Building>("Building");
            builder.EntitySet<Room>("Room");
            builder.EntitySet<Seat>("Seat");


            return builder.GetEdmModel();
        }
    }

}
