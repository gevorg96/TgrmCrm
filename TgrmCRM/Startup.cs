using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TgrmCRM.Services;
using TgrmCRM.Services.Interfaces;
using TgrmCRM.Tgrm;

namespace TgrmCRM
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
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddDbContext<TgrmDbContext>();
            services.AddScoped<TgrmAuth>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAnswerService, AnswerService>();
            services.AddScoped<IContactPartnerService, ContactPartnerService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IContactsMessageService, ContactsMessagesService>();
            services.AddScoped<IMessageAnswerService, MessageAnswerService>();
            services.AddScoped<IPartnerService, PartnerService>();
            services.AddScoped<IThemeMessageService, ThemeMessageService>();

            var sp = services.BuildServiceProvider();
            var job = new RecieveUpdateJob(sp.GetRequiredService<IAccountService>(), sp.GetRequiredService<IAnswerService>(), sp.GetRequiredService<IMessageAnswerService>(), sp.GetRequiredService<IThemeMessageService>());
            job.CheckUpdates();
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
