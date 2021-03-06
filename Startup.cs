using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using LinqToDB;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SixConsultApi.Domain.Entities;
using SixConsultApi.Dto.ProfilerMapper;
using SixConsultApi.Dto.User;
using SixConsultApi.Dto.Validations;
using SixConsultApi.Helpers;
using SixConsultApi.Helpers.Interfaces;
using SixConsultApi.Infra.Data.Context;
using SixConsultApi.Infra.Data.Repository;
using SixConsultApi.Infra.Data.Repository.interfaces;
using SixConsultApi.Service;
using SixConsultApi.Service.Interfaces;

namespace SixConsultApi
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
            #region Validation
            services.AddMvc()
                .AddFluentValidation(fv => {
                    fv.RegisterValidatorsFromAssemblyContaining<Startup>();
                });
            services.AddMvc().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = c =>
                {
                var errors = string.Join(", ", c.ModelState.Values.Where(v => v.Errors.Count > 0)
                    .SelectMany(v => v.Errors)
                    .Select(v => v.ErrorMessage));

                return new BadRequestObjectResult(new
                    {
                        ErrorCode = 400,
                        Message = errors
                    });
                };
            });
            //Filter of Validation
            #endregion
            #region Db Conection
            services.AddDbContext<ContextDB>(options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            #endregion
            #region  Mapper
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ProfileMapper());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion
            services.AddControllers();
            #region Swagger Doc
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Six Consult Api",
                    Version = "v1",
                    Description = "DESAFIO DE DESENVOLVIMENTO SIX CONSULT "
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
            #endregion
            #region Jwt authentication
            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
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
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion

            // configure DI for application services
            #region Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            #endregion
            #region Services
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProfileService, ProfileService>();
            #endregion
            #region Helpers
            services.AddScoped<IHashService, HashService>();
            services.AddScoped<IJwtService, JwtService>();
            #endregion
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SixConsultApi v1");
                    c.RoutePrefix = string.Empty;
                });
            }
            //app.UseHttpsRedirection();
            app.UseCors("MyPolicy");

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
