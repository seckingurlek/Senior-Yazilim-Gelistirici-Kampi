using Persistence;
using Application;
using Core.CrossCuttingConcerns.Exceptions;
namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddApplicationServices();
          //  builder.Services.AddSecurityServices();
            builder.Services.AddPersistenceServices(builder.Configuration);
          //  builder.Services.AddInfrastructureServices();
         //   builder.Services.AddHttpContextAccessor();


          
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.ConfigureCustomExceptionMiddleware();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
