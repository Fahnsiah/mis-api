using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MISAPI.DataModel.DataAccess;
using MIS_API.Middleware;
using System;
using System.Linq;
using MISAPI.DAL.Helpers;
using MISAPI.DAL.Interfaces;
using MISAPI.DAL.Services;

namespace MIS_API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {
                options.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
            });

            services.AddControllersWithViews().AddNewtonsoftJson();

            services.AddDbContext<DataContext>();
            services.AddCors();
            services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.IgnoreNullValues = true);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MIS API", Version = "1.0" });
            });

            // configure strongly typed settings object
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            // configure DI for application services
            services.AddScoped<IAccountInterface, AccountService>();
            services.AddScoped<IEmailInterface, EmailService>();
            services.AddScoped<IRoleInterface, RoleService>();
            services.AddScoped<IRolePermissionInterface, RolePermissionService>();
            services.AddScoped<IArticleInterface, ArticleService>();
            services.AddScoped<ICurrencyInterface, CurrencyService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                    c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "MWETANA API version 1.0");
                });
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MWETANA API version 1.0"));
            }

            app.UseRouting();

            // global cors policy
            //app.UseCors(
            //    options => options.WithOrigins("http://example.com").AllowAnyMethod()
            //);

            app.UseCors(x => x.WithOrigins("http://localhost:3000")
                //.SetIsOriginAllowed(origin => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            //app.UseCors(x => x
            //  .AllowAnyOrigin()
            //  .AllowAnyMethod()
            //  .AllowAnyHeader()
            //  //.AllowCredentials()
            //  );

            app.UseHttpsRedirection();

            // global error handler
            app.UseMiddleware<ErrorHandlerMiddleware>();

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.UseEndpoints(x => x.MapControllers());

        }

        private static NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter()
        {

            var builder = new ServiceCollection()
                .AddLogging().AddMvc().AddNewtonsoftJson().Services.BuildServiceProvider();

            return builder
                .GetRequiredService<IOptions<MvcOptions>>()
                .Value
                .InputFormatters
                .OfType<NewtonsoftJsonPatchInputFormatter>()
                .First();
        }
    }
}
