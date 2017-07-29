using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TellRachel.Entities;
using TellRachel.Models;
using TellRachel.Repositories;

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
            var connectionString = @"Server=localhost;Database=TellRachel;Trusted_Connection=True;";
            services.AddDbContext<TellRachelContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<ITellRachelRepository, TellRachelRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            AutoMapper.Mapper.Initialize(configuration =>
            {
                configuration.CreateMap<HerNote, NoteModel>();
                configuration.CreateMap<HerNote, NoteWithRecordsModel>();
                configuration.CreateMap<HerRecord, RecordModel>();
                configuration.CreateMap<NoteCreationModel, HerNote>();
            });

            app.UseMvc();
        }
    }
}
