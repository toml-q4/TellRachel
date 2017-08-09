using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TellRachel.Entities;
using TellRachel.Models.Medicine;
using TellRachel.Models.Note;
using TellRachel.Models.Symptom;
using TellRachel.Repositories.Note;

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
            services.AddDbContext<TellRachelContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<INoteRepository, NoteRepository>();
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
                configuration.CreateMap<NoteForCreation, Note>();
                configuration.CreateMap<Symptom, SymptomModel>();
                configuration.CreateMap<Medicine, MedicineModel>();
            });

            /* Executing this code produces an AutoMapperConfigurationException, 
             * with a descriptive message. AutoMapper checks to make sure that 
             * every single Destination type member has a corresponding type member on the source type.*/
            AutoMapper.Mapper.AssertConfigurationIsValid();

            app.UseMvc();
        }
    }
}
