using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InventoryApplication.ConcreteRepos;
using InventoryApplication.ContractRepos;
using InventoryApplication.DataCon;
using InventoryApplication.Entities;
using InventoryApplication.HelperModels.Cloudinary;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace InventoryApplication
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDbContext<DataContext>(x => x.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<DataContext>();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {

                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMvc();
            services.AddTransient<Seed>();
            services.Configure<CloudinarySettings>(Configuration.GetSection("CloudinarySettings"));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ILocation, LocationRepository>();
            services.AddScoped<IShopRepository, ShopRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddControllers(setupAction=> {
                setupAction.ReturnHttpNotAcceptable = true;
            }).AddXmlDataContractSerializerFormatters()
            .ConfigureApiBehaviorOptions(setupAction=> {
                setupAction.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Type="https://localhost:4000/modelvalidationproblem",
                        Title="One or more validation errors occured",
                        Status=StatusCodes.Status422UnprocessableEntity,
                        Instance=context.HttpContext.Request.Path
                    };
                    problemDetails.Extensions.Add("TraceID", context.HttpContext.TraceIdentifier);
                    return new UnprocessableEntityObjectResult(problemDetails) { 
                        ContentTypes = { "application/json" }
                    };
                };
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,Seed seeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(appbuilder=>{
                    appbuilder.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        await context.Response.WriteAsync("An Unexpedted Error Occured. Try Again Later");
                    });
                });
            }
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            seeder.SeedUser();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
