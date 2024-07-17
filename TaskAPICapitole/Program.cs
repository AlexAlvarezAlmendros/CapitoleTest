using Application.Funcionalities;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Settings;
using Microsoft.Extensions.Options;
namespace TaskAPICapitole
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));
			builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<MongoDbSettings>>().Value);

			builder.Services.AddScoped<IRepository, Repository>();
			builder.Services.AddScoped<ITaskService,TaskService>();

			builder.Services.AddControllers();

			// Add services to the container.
			builder.Services.AddAuthorization();

			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAllOrigins",
					builder =>
					{
						builder.AllowAnyOrigin()
							   .AllowAnyMethod()
							   .AllowAnyHeader();
					});
			});

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

            app.UseAuthorization();
			app.UseCors("AllowAllOrigins");
			app.MapControllers();
			app.Run();
        }
    }
}
