using DangleterreV2.Configuration;
using DangleterreV2.Handlers;
using DangleterreV2.Persistence.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using AutoMapper;
using DangleterreV2.Mapping;
using DangleterreV2.Persistence.Models;
using DangleterreV2.RequestModels;

namespace DangleterreV2
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        
        public Startup(IConfiguration config)
        {
            _configuration = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            
            // Add Configurations
            services.Configure<PersistenceConfiguration>(_configuration.GetSection(nameof(PersistenceConfiguration)));
            
            // Register MongoDB database
            services.AddSingleton<IMongoClient>(ctx => new MongoClient(ctx.GetService<IOptions<PersistenceConfiguration>>().Value.MongoClusterConnectionString));
            
            // Register handlers
			services.AddScoped<INCustomerHandler, NCustomerHandler>();
			services.AddScoped<IVipCustomerHandler, VipCustomerHandler>();
			services.AddScoped<IRoomHandler, RoomHandler>();
			services.AddScoped<ISuiteHandler, SuiteHandler>();
			services.AddScoped<ISpaHandler, SpaHandler>();
			services.AddScoped<IRoomScheduleHandler, RoomScheduleHandler>();
			services.AddScoped<IRoomBookHandler, RoomBookHandler>();

            // Register repositories
            services.AddScoped<INCustomerRepository, NCustomerRepository>();
            services.AddScoped<IVipCustomerRepository, VipCustomerRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ISuiteRepository, SuiteRepository>();
            services.AddScoped<ISpaRepository, SpaRepository>();
			services.AddScoped<IRoomScheduleRepository, RoomScheduleRepository>();
			services.AddScoped<IRoomBookRepository, RoomBookRepository>();

			//Register Mapper
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfile());
			});
			
			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);
			
            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });
        
        	//Add swagger
        	services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
//Swaggerrr
        	app.UseSwagger();
        	//Enable middleware to serve ui
        	app.UseSwaggerUI(c =>
        	{
        	    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Booker app");
     		});        	
        	
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
