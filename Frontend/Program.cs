using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.AspNetCore.SpaServices.Extensions;
namespace Frontend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "Frontend/dist";
            });

            var app = builder.Build();

            app.UseStaticFiles();

            app.UseSpaStaticFiles();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "Frontend";

                if (app.Environment.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:8080");
                }
            });

         
            app.Run();
        }
    }
}


//var frontPath = Path.Combine(Directory.GetCurrentDirectory(), "Front");


//app.UseDefaultFiles(new DefaultFilesOptions
//{
//    FileProvider = new PhysicalFileProvider(frontPath),
//    RequestPath = ""
//});

//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(frontPath),
//    RequestPath = ""
//});