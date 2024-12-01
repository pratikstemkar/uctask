using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using UcTask.Data;

namespace UcTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<TaskContext>((options) =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("conString")));

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ;

            var app = builder.Build();

            app.UseRouting();

            app.UseCors((policyBuilder) =>
            policyBuilder.WithOrigins("*")
                         .WithHeaders("*")
                         .WithMethods("*"));

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
