using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reminders.Business.Abstraction;
using Reminders.Business.Services;
using Reminders.DAL;
using Reminders.DAL.Abstraction;
using Reminders.DAL.Repository;

namespace Reminders
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RemindersContext>(options =>
            {
                options.UseNpgsql(Configuration["ConnectionString"]);
            });
            services.AddTransient<IEventRepository, EventRepository>();
            services.AddTransient<IEventService, EventService>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
