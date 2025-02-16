using LotteryNumbers.Interfaces;
using LotteryNumbers.Services;

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


            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=LotteryNumbers}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
