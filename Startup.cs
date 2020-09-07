using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PortalAPI.Data;
using Newtonsoft.Json.Serialization;
using PortalAPI.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PortalAPI.IdentityModel;
using Microsoft.AspNetCore.Identity;

namespace PortalAPI
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


        services.AddCors(options =>
    {
            options.AddPolicy("EnableCORS", builder =>
            {
            builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });

             //identity   
            services.AddDbContext<ApplicationIdentitydbContext>(opt => opt.UseSqlServer
           (Configuration.GetConnectionString("PortalApiConnection")));  

           services.AddIdentity<IdentityUser,IdentityRole>(opt=>{

               opt.Password.RequireDigit=true;
               opt.Password.RequireLowercase=true;
               opt.Password.RequiredLength = 5;
           }).AddEntityFrameworkStores<ApplicationIdentitydbContext>().AddDefaultTokenProviders(); 

            services.AddDbContext<PortalApiContext>(opt => opt.UseSqlServer
           (Configuration.GetConnectionString("PortalApiConnection")));

            services.AddControllers().AddNewtonsoftJson(s=>{
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            //JWT Authentication

          
            services.AddAuthentication(a =>{

                a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>{

                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters {

                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["AuthSettings:Audience"],
                    ValidIssuer = Configuration["AuthSettings:Issuer"],
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["AuthSettings:Key"])),
                    ValidateIssuerSigningKey = true
                };
            });

        services.AddScoped<IUserRepository,SqlUserRepository>();


            //mapeart os DTOS
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //usando classe mock  
           // services.AddScoped<IColaboradorRepository,MockColaboradorRepository>();
            //usando conexao com sql server
           services.AddScoped<IColaboradorRepository,SqlColaboradorRepository>();

           
           services.AddSwaggerGen(options =>  
    {  
        options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo  
        {  
            Title = "Portal Service API",  
            Version = "v1",  
            Description = "API do sistema Portal",  
        });  
    });  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

             app.UseCors("EnableCORS");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

                 app.UseSwagger();  
                  app.UseSwaggerUI(options =>options.SwaggerEndpoint("/swagger/v2/swagger.json", "Portal API"));
        }
    }
}
