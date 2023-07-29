using System.IO;
using System;
using FMBQ.Hub.Auth;
using FMBQ.Hub.Database;
using Markdig;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static System.Environment;
using Lib.AspNetCore.ServerSentEvents;

namespace FMBQ.Hub
{
    public class Application
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Application>().UseWebRoot("../../wwwroot");
            });

        public Application(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddServerSentEvents();

            services.AddSingleton<MarkdownPipeline>(new MarkdownPipelineBuilder()
                .UseAutoIdentifiers()
                .UseAutoLinks()
                .UseFootnotes()
                .UsePipeTables()
                .UseSmartyPants()
                .Build());

            services.AddSingleton<MarkdownTagHelper>();

            services.AddSingleton<IConnectionProvider, SqliteConnectionProvider>();
            services.AddSingleton<ApiTokenService>();
            services.AddSingleton<QuizService>();
            services.AddSingleton<SeasonService>();
            services.AddSingleton<TournamentService>();
            services.AddSingleton<UserService>();

            services.AddHostedService<DbStartup>();

            services.AddOpenApiDocument(document =>
            {
                document.Title = "FMBQ Hub API";
                document.Description = "FMBQ Hub API";
                document.Version = "v1";
                document.OperationProcessors.Add(new OpenApiOperationIdGenerator());
            });

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.SameSite = SameSiteMode.Strict;
            });

            Configuration["SqlitePath"] = Path.Combine(
                Environment.GetFolderPath(SpecialFolder.LocalApplicationData),
                "fmbq-hub",
                "data.db"
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHttpsRedirection();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseOpenApi();
            app.UseReDoc();

            app.MapServerSentEvents("/events");

            app.UseRouting();

            app.UseCookiePolicy();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
                endpoints.MapFallbackToController("Get", "Frontend");
            });
        }
    }
}
