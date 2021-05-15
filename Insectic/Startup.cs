using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Insectic.InsecticData;
using Insectic.Models;
using Microsoft.EntityFrameworkCore;

namespace Insectic
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
            services.AddControllersWithViews();
            services.AddHttpClient();
            services.AddScoped<ITicketRepository, TicketApiRepository>();
            services.AddScoped<INoteRepository, NoteApiRepository>();

            //for custom Identity

            services.AddIdentity<IdentityUserModel, UserRole>(option => option.User.RequireUniqueEmail = true).AddEntityFrameworkStores<IdentityAppContext>();

            services.AddDbContext<IdentityAppContext>(cfg =>
                cfg.UseSqlServer(Configuration.GetConnectionString("InsecticContextConnection")));

            services.AddRazorPages();

            //forces the user to log in 
            //services.AddAuthorization(opt =>
            //{
            //    opt.FallbackPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
            //});


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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Dashboard}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
