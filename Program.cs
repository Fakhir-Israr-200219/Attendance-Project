using Attendance_Project.Core.Interface;
using Attendance_Project.data;
using Attendance_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Attendance_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //var provider = builder.Services.BuildServiceProvider();
            //var Config = provider.GetRequiredService<IConfiguration>();
            //builder.Services.AddDbContext<AttendanceProContext>(item => item.UseSqlServer(Config.GetConnectionString("dbcs")));
            builder.Services.AddDbContext<AttendanceProContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
