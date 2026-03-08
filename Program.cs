
using Azure_AI_DocumentProcessor.Data;
using Azure_AI_DocumentProcessor.Services;
using Microsoft.EntityFrameworkCore;

namespace Azure_AI_DocumentProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DocAIDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("AzureDocAIConnection"));
            });

            builder.Services.AddScoped<DocumentAIService>();
            builder.Services.AddScoped<TranslatorService>();
            builder.Services.AddHttpClient();
            // Add services to the container.
            builder.Services.AddControllers();

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

            app.MapControllers();

            app.Run();
        }
    }
}
