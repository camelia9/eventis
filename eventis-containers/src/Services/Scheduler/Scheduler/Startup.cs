using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Scheduler
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
            services.AddHangfire(x => x.UseMemoryStorage());
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            
            app.UseHangfireDashboard();

            Jobs job = new Jobs();
            RecurringJob.AddOrUpdate(() => job.UpdateEvents(), Cron.Daily);
            RecurringJob.AddOrUpdate(() => job.SendEmailsForToday(), Cron.Daily(7, 0));
            //RecurringJob.AddOrUpdate(() => job.SendWelcomeEmail(), Cron.Daily);
            app.UseHangfireServer();

            app.UseMvc();
        }
    }
}
