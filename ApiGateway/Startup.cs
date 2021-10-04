using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway
{
    public class Startup
    {
        readonly string AllowSpecifiOrigin = "_AllowSpecifiOrigin";
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
                options.AddPolicy(name: AllowSpecifiOrigin,
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44379");
                    });
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiGateway", Version = "v1" });
            });
            services.AddAuthentication(configOptions =>
            {
                configOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                configOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer("providerKey", jwtBearerOptions =>
            {
                jwtBearerOptions.RequireHttpsMetadata = false; //This should be set to true in production environment
                jwtBearerOptions.SaveToken = true;//Save token in authentication properties
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters //Set parameters used to validate the token
                {
                    ValidateIssuerSigningKey = true, //Validate security key used for signing the token
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("This is just a test key")), //Set issuer signing key
                    ValidateIssuer = false, //Don't validate issuer
                    ValidateAudience = false
                };
            });
            services.AddOcelot();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiGateway v1"));
            }

            app.UseRouting();
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type");

                await next();
            });
            app.UseCors(AllowSpecifiOrigin);//Make sure this is after UseRouting & before UseAuthorization        

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Use ocelot
           app.UseOcelot().Wait();
        }
    }
}
