using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Statistics.BLL;
using Statistics.DAL;
using Statistics.Database;
using Statistics.Hangfire;
using Statistics.Services;

namespace Statistics
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
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1.0";
                    document.Info.Title = "Statistics";
                };
            });

            services.AddControllers();
            services.AddMvc(options => options.Filters.Add<ExceptionHandlerFilter>());

            var connectionString = Configuration.GetConnectionString("Statistic");
            services.AddDbContext<StatisticContext>(x => x.UseSqlServer(connectionString));

            // hangfire background job
            services.AddHangfire(x => x.UseSqlServerStorage(connectionString));
            services.AddHangfireServer();

            // IoC
            services.AddHttpClient<IProductService, ProductService>();
            services.AddTransient<IStatisticLogic, StatisticLogic>();
            services.AddTransient<IStatisticDataManager, StatisticDataManager>();
            services.AddTransient<IStatisticJob, StatisticJob>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // hangfire
            app.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new HangfireDashboardAuthorizationFilter() }
            });
            app.UseHangfireServer();
            HangfireJobScheduler.ScheduleRecurringJob();
        }
    }
}
