using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TellRachel.Domain.Entities;
using TellRachel.Models.Medicine;
using TellRachel.Models.Note;
using TellRachel.Models.Symptom;
using TellRachel.Models.Temperature;
using TellRachel.Data.Repositories;
using TellRachel.Data;
using TellRachel.Shared;

namespace TellRachel
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddJsonFormatters();

            services.AddCors();

            var connectionString = Configuration["connectionStrings:tellRachelDB"];
            services.AddDbContext<TellRachelContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("TellRachel")));
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<ISymptomRepository, SymptomRepository>();
            services.AddScoped<ITemperatureRepository, TemperatureRepository>();

            services.AddScoped<IUnitConverter, UnitConverter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // TODO make spa url configurable
            const string spaUrl = "http://localhost:4200";

            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowCredentials();
                builder.WithOrigins(spaUrl);
            });

            AutoMapper.Mapper.Initialize(configuration =>
            {
                configuration.CreateMap<Note, NoteModel>();
                configuration.CreateMap<Note, NoteWithDetailsModel>();
                configuration.CreateMap<NoteCreationModel, Note>();
                configuration.CreateMap<Symptom, SymptomModel>();
                configuration.CreateMap<SymptomCreationModel, Symptom>();
                configuration.CreateMap<Medicine, MedicineModel>();
                configuration.CreateMap<TemperatureCreationModel, Temperature>();
                configuration.CreateMap<Temperature, TemperatureModel>();
            });
            app.UseMvc();
        }
    }
}
