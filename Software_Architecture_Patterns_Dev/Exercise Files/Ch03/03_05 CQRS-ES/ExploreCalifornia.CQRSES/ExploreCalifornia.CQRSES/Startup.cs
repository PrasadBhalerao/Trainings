using Dapper;
using ExploreCalifornia.CQRSES.DataAccess;
using ExploreCalifornia.CQRSES.DataAccess.ReadModel;
using ExploreCalifornia.CQRSES.DataAccess.WriteModel;
using ExploreCalifornia.CQRSES.Domain.EventHandlers.ReadModelGenerators;
using ExploreCalifornia.CQRSES.Domain.WriteModel.Entities;
using ExploreCalifornia.CQRSES.Domain.WriteModel.EventHandlers;
using ExploreCalifornia.CQRSES.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExploreCalifornia.CQRSES
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
            services.AddRazorPages();
            services.AddTransient<IToursRepository, ToursRepository>();
            services.AddTransient<IEventSourcedRepository<Booking>, EventSourcedRepository<Booking>>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ITravelAgentService, TravelAgentService>();
            
            services.AddTransient<IEventHandler, BookingEmailer>();
            services.AddTransient<IEventHandler, TravelAgentNotifier>();
            services.AddTransient<IEventHandler, BookingOverviewItemGenerator>();

            services.AddTransient<IBookingOverviewItemRepository, BookingOverviewItemRepository>();

            SqlMapper.AddTypeHandler(new SqliteGuidTypeHandler());
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
