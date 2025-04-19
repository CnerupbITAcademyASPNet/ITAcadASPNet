
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace WebApplication2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //builder.Services.AddDbContext<OnlineStoreContext>(options =>
            //{
            //    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            //    options.UseSqlServer(connectionString);
            //}); // DB Connection

            builder.Services.AddControllers()
                .AddJsonOptions(options => // Nested JSON objects support
                {
                    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    options.JsonSerializerOptions.WriteIndented = true;
                });

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            //using (var scope = app.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    var context = services.GetRequiredService<OnlineStoreContext>();
            //    DbInitializer.Initialize(context);
            //}

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
