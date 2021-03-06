using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolingSystem.Managers.ApiManagers;
using SchoolingSystem.Managers.IDManagers;
using SchoolingSystem.Managers.Mappers;
using SchoolingSystem.Managers.Storages.Accounts;
using SchoolingSystem.Services.ApiServices;
using SchoolingSystem.Services.Foundations.Accounts;
using SchoolingSystem.Services.Mappers.Etudiants;
using SchoolingSystem.Services.Processors;

namespace SchoolingSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages(options =>
            {
                options.RootDirectory = "/Views/Pages";
            });
            services.AddServerSideBlazor();
            services.AddScoped<IApiManager, ApiManager>();
            services.AddScoped<IEtudiantService, EtudiantService>();
            services.AddScoped<IStorageMapper, StorageMapper>();
            services.AddScoped<IEtudiantMapper, EtudiantMapper>();
            services.AddScoped<IIDGenerator, IDGenerator>();
            services.AddScoped<IAccountStore, AccountStore>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IRegistrationService, RegistrationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}