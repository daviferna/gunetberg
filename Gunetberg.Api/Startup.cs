using Gunetberg.Business;
using Gunetberg.Cloud;
using Gunetberg.Configuration;
using Gunetberg.Exceptions;
using Gunetberg.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Gunetberg.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddDbContext<Context>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Database"));
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var signingKey = new SymmetricSecurityKey(Encoding.Default.GetBytes("MG6zwQQsHys72LwmNUNHH3ZkS3w8WtL3KuugDpcfEDh8jVJZPjM5qQxTyruXZcTsERaUmz7GsH8xduwVew96ZTd5zWDYZ3AhJK5znpbt6vayHbkAtq6r6strmbJMDBGeLK4n6ARR7Y8fnnWkHYD6Y6NesEe67TdfRmCDzmkTV7mehZeAvt5BHfEw9r4SS4b69D2qMTz27CB4UmZ6rhwLxDXjTvWjGYfYFtgdXEb2pmAH54r4SfKuunkKW5q6uSP5"));
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey
                };
            });

            services.AddScoped<BlobStorage>(x=> new BlobStorage(Configuration.GetConnectionString("StorageAccount"), Configuration.GetConnectionString("ProfilePictureContainer")));
            services.AddScoped<AuthBusiness>();
            services.AddScoped<UserBusiness>();
            services.AddScoped<PostBusiness>();
            services.AddScoped<NotificationBusiness>();
            services.AddScoped<CommentaryBusiness>();
            services.AddScoped<ApplicationConfiguration>();
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

            app.UseCors(policy =>
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
            );

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

        }

    }
}
