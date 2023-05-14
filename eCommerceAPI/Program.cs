using Core.Interfaces;
using eCommerceAPI.Middelware;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eCommerceAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // service configrations 
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped(typeof(IBaseEntityRepositry<>), typeof(BaseEntityRepositry<>));

            // tell the program to use the mapper to return the DTO files 
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //get connection to database 
            builder.Services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // telling the app to use our middelware 
            app.UseMiddleware<ExceptionMiddelware>();

            // handeling page notFound
            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();

            // to save static files in our code 
            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();

            // to update migrations and database automatically
            
            using var scope = app.Services.CreateScope();
            var Services = scope.ServiceProvider;
            var context = Services.GetRequiredService<StoreContext>();
            var Logger = Services.GetRequiredService<ILogger<Program>>();

            try
            {
                await context.Database.MigrateAsync();
                await StoreContextSeed.SeedAsync(context);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error occured while migrating process");
            }
            app.Run();
        }
    }
}