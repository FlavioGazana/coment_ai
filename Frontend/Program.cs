using Microsoft.Extensions.FileProviders;
namespace Frontend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            var frontPath = Path.Combine(Directory.GetCurrentDirectory(), "Front");

            app.UseDefaultFiles(new DefaultFilesOptions
            {
                FileProvider = new PhysicalFileProvider(frontPath),
                RequestPath = ""
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(frontPath),
                RequestPath = ""
            });
            app.Run();
        }
    }
}
