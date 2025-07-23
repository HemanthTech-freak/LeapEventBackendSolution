using LeapEvent.API.Middleware;
using LeapEvent.Application.Interfaces;
using LeapEvent.Application.Services;
using LeapEvent.Infrastructure;
using LeapEvent.Infrastructure.Interfaces;
using LeapEvent.Infrastructure.Utilities;
using LeapEvent.Persistence.Repositories;
using Microsoft.OpenApi.Models;

namespace LeapEvent.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            //Configure CORS policy to allow all origins, methods, and headers
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            var connectionStr = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddSingleton<INHibernateSessionFactory>(_ =>
                new NHibernateSessionFactory(connectionStr));
            // Dependency Injection for ISessionFactory
            builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<INHibernateSessionFactory>().SessionFactory);

            // Dependency Injection for NHibernate session
            builder.Services.AddScoped(sp =>
                sp.GetRequiredService<INHibernateSessionFactory>().SessionFactory.OpenSession());

            //Dependency Injection for Repositories and Services
            builder.Services.AddScoped<IEventRepository, EventRepository>();
            builder.Services.AddScoped<IEventService, EventService>();
            builder.Services.AddScoped<ITicketRepository, TicketRepository>();
            builder.Services.AddScoped<ITicketService, TicketService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "LeapEvent API",
                    Version = "v1"
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            app.UseCors("AllowAll"); //Cors policy to allow all origins, methods, and headers
            app.UseAuthorization();
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseSwagger(); 
            app.UseSwaggerUI(); 

            app.MapControllers();

            // Seed the database if needed
            var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "skillsAssessmentEvents.db");
            var seedScript = Path.Combine(Directory.GetCurrentDirectory(), "Database", "seed.sql");

            DbSeeder.SeedIfNeeded(dbPath, seedScript);

            app.Run();
        }
    }
}
            
