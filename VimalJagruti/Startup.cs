using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VimalJagruti.Domain.ViewModel.Common;
using VimalJagruti.Helper;
using VimalJagruti.Repo;
using VimalJagruti.Repo.IRepository;
using VimalJagruti.Repo.Repository;
using VimalJagruti.Services.IServices;
using VimalJagruti.Services.Services;
using VimalJagruti.Utils;

namespace VimalJagruti
{
    public class Startup
    {
        private readonly string cenv;
        public Startup(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment appEnv)
        {
            Configuration = configuration;
            cenv = appEnv.EnvironmentName;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddControllers(config =>
            {
                config.Filters.Add(new ModelStateValidatorAttribute());
            });

            var appSettingsSection = Configuration.GetSection("AppSettings:Secret");

            services.Configure<AppSettings>(d => d.Sercret = appSettingsSection.Value);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VimalJagruti", Version = "v1" });

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

                // Set the comments path for the Swagger JSON and UI.
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });

            // configure jwt authentication
            var key = Encoding.ASCII.GetBytes(appSettingsSection.Value);


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(a =>
                {
                    a.RequireHttpsMetadata = false;
                    a.SaveToken = true;
                    a.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                    a.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = contxt =>
                        {
                            var accesstoken = contxt.Request.Query["access_token"];
                            //If request is for our hub
                            var path = contxt.HttpContext.Request.Path;
                            if(!string.IsNullOrEmpty(accesstoken) && (path.StartsWithSegments("/hubs/chat")))
                            {
                                // Read the token out of the query string
                                contxt.Token = accesstoken;
                            }
                            return Task.CompletedTask;
                        }
                    };
                });


            ///Registering services
            services.AddDbContext<Context>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("VmJagrutiCS")));
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStoredProcedureRepo, StoredProcedureRepo>();
            //services.AddScoped<IStoredProcedureRepo, StoredProcedureRepo>();
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IVehicleServices, VehicleServices>();
            services.AddTransient<IJobCardService, JobCardService>();
            services.AddTransient<IInventoryService,InventoryService>();


            services.AddAuthorization(x =>
            {
                x.AddPolicy(Policies.Admin.ToString(), policyUser => policyUser.RequireClaim(ClaimTypes.Role, Roles.Admin.ToString()));
                x.AddPolicy(Policies.OwnerAndHigher.ToString(), policyUser => policyUser.RequireClaim(ClaimTypes.Role, Roles.Owner.ToString(), Roles.Admin.ToString()));
                x.AddPolicy(Policies.StaffAndHigher.ToString(), policyUser => policyUser.RequireClaim(ClaimTypes.Role, Roles.Staff.ToString(), Roles.Admin.ToString() , Roles.Owner.ToString()));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VimalJagruti v1"));
            }

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
