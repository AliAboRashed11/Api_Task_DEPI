using ApiDayOne.Filters;
using ApiDayOne.MiddelWare;
using ApiDayOne.Models;
namespace ApiDayOne
{
    public class Program
    {
        public static void Main(string[] args) 
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<CompanyDBContext>();

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<ValidateLocationAttribute>();
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

            app.UseHttpsRedirection();
            app.UseMiddleware<SampelMiddelWare>();
            app.UseMiddleware<DataMiddelWare>();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
