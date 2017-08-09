using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
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
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddJsonFormatters();

            services.AddCors();

            var connectionString = @"Server=localhost;Database=TellRachel;Trusted_Connection=True;";
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
                configuration.CreateMap<NoteCreationModel, Note>();
                configuration.CreateMap<Symptom, SymptomModel>();
                configuration.CreateMap<Medicine, MedicineModel>();
            });

            app.UseMvc();
        }
    }
}
