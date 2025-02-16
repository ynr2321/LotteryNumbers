using LotteryNumbers.Interfaces;
using LotteryNumbers.Services;
using System.Diagnostics;

namespace LotteryNumbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            
            // Register the number generating service so the LotteryNumbersController constructor knows what to use
            builder.Services.AddScoped<INumberGenerator, NumberGenerator>();

            var app = builder.Build();


            //app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=LotteryNumbers}/{action=Index}/{id?}")
                .WithStaticAssets();



            // Get default port from config
            var defaultPort = builder.Configuration["DefaultPort"];
            var url = $"http://localhost:{defaultPort}";

            // Try to auto launch browser, suppress if fail
            try
            {
                Console.WriteLine($"\nAttempting to launch in browser at '{url}. Modify default port in appsettings.json.'\n");
                app.Lifetime.ApplicationStarted.Register(() =>
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = url,
                        UseShellExecute = true // Opens in the default browser
                    });
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nCould not auto-launch browser: {ex.Message} - go to '{url}' manually to view the app.\n");
                // Suppress
            }

            app.Run(url);
        }
    }
}
