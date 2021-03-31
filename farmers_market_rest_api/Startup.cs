using farmers_market_rest_api.Domain.IRepository.Area;
using farmers_market_rest_api.Domain.IRepository.Shop;
using farmers_market_rest_api.Domain.IRepository.User;
using farmers_market_rest_api.Domain.IService.Shop;
using farmers_market_rest_api.Domain.IService.User;
using farmers_market_rest_api.Domain.Models.User;
using farmers_market_rest_api.Persistence.Context;
using farmers_market_rest_api.Persistence.Repositories.Area;
using farmers_market_rest_api.Persistence.Repositories.Shop;
using farmers_market_rest_api.Persistence.Repositories.User;
using farmers_market_rest_api.Persistence.Utils.UnitOfWork;
using farmers_market_rest_api.Service.Shop;
using farmers_market_rest_api.Service.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace farmers_market_rest_api
{
    public class Startup
    {
        private readonly IHostingEnvironment _environment;
        public Startup(IHostingEnvironment env, IConfiguration configuration)
        {
            _environment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            var sqlConnectionString = Configuration.GetConnectionString("farmers_market");
            services.AddDbContext<AppDbContext>(options => options.UseMySql(sqlConnectionString));

            services.AddIdentity<ApplicationUser, ApplicationRole>(
                  option =>
                  {
                      option.Password.RequireDigit = false;
                      option.Password.RequiredLength = 6;
                      option.Password.RequireNonAlphanumeric = false;
                      option.Password.RequireUppercase = false;
                      option.Password.RequireLowercase = false;
                  }
              ).AddEntityFrameworkStores<AppDbContext>()
              .AddDefaultTokenProviders();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder
                    .WithOrigins("http://localhost:3000", "http://localhost:3001")
                    .AllowAnyHeader().AllowCredentials()
                    .AllowAnyMethod();
            }));


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<IDivisionRepository, DivisionRepository>();
            services.AddScoped<IDistrictRepository, DistrictRepository>();
            services.AddScoped<IUpozilaRepository, UpozilaRepository>();
            services.AddScoped<IUnionOrWardRepository, UnionOrWardRepository>();
            services.AddScoped<IMarketRepository, MarketRepository>();


            services.AddScoped<IInstrumentRepository, InstrumentRepository>();
            services.AddScoped<IInstrumentService, InstrumentService>();
            services.AddScoped<IInstrumentCategoryRepository, InstrumentCategoryRepository>();


            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();



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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseCors("ApiCorsPolicy");
            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
