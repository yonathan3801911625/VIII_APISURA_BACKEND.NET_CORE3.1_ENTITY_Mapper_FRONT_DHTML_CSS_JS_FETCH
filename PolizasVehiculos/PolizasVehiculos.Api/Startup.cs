using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PolizasVehiculos.Core.Interfaces;
using PolizasVehiculos.Core.Servicios;
using PolizasVehiculos.Infraestructura.Datos;
using PolizasVehiculos.Infraestructura.Filtros;
using PolizasVehiculos.Infraestructura.Repositorios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PolizasVehiculos.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private readonly string _policyName = "CorsPolicy"; //libreria cors
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //libreria cors
            services.AddCors(opt =>
            {
                opt.AddPolicy(name: _policyName, builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            //services.AddControllers();

            //Mapeos
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Excepciones Globales - Evitar referencias ciclicas
            services.AddControllers(options => 
            {
                options.Filters.Add<ExcepcionGlobalFiltro>();
            }).AddNewtonsoftJson(options => 
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            })
            .ConfigureApiBehaviorOptions(options => 
            {
                //options.SuppressModelStateInvalidFilter = true;
            });

            //Autenticacion JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Authentication:Issuer"],
                    ValidAudience = Configuration["Authentication:Audiencie"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]))
                };
            });

            //Validadores
            services.AddMvc(options =>
            {
                options.Filters.Add<FiltroValidacion>();

            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });

            //Inyeccion de dependencias
            //services.AddTransient<IPaisRepositorio,PaisRepositorio>();
            services.AddTransient<IPaisServicio, PaisServicio>();
            services.AddTransient<ISeguridadServicio, SeguridadServicio>();
            services.AddTransient<IProductoServicio, ProductoServicio>();
            services.AddTransient<IVehiculoServicio, VehiculoServicio>();
            services.AddTransient<IUsuarioServicio, UsuarioServicio>();
            services.AddTransient<IPolizaServicio, PolizaServicio>();
            services.AddScoped(typeof(IRepositorio<>), typeof(RepositorioBase<>));
            services.AddTransient<IUnidadDeTrabajo, UnidadDeTrabajo>();

            //Swagger
            services.AddSwaggerGen(doc =>
            {
                doc.SwaggerDoc("v1",new OpenApiInfo { Title = "Poliza API", Version = "v1", Description = "Web API Polizas Seguros"});

                var xmlArchivo = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                // Set the comments path for the Swagger JSON and UI.
                var xmlRuta = Path.Combine(AppContext.BaseDirectory, xmlArchivo);
                doc.IncludeXmlComments(xmlRuta);

                //Configuración de autorización por token.               
                doc.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Authorization by API key. Set tokent example(Bearer + token)",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Name = "Authorization"
                });

                doc.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id   = "Bearer"
                            }
                        },
                        new string[]{ }
                    }
                });
            });

            //Conexion BD
            services.AddDbContext<DBSegurosContext>(options =>
              options.UseSqlServer(Configuration.GetConnectionString("DBSeguros"))
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(options=>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json","Poliza API");
                options.RoutePrefix = string.Empty;
            });

            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(_policyName);//libreria cors
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
