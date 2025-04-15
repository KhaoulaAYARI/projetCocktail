using Commun.Repositories;

namespace ASP_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //Ajout de nos services: Ceux de la BLL et ceux de la DAL
            builder.Services.AddScoped < IUserRepository < BLL_Khaoula.Entities.User>,BLL_Khaoula.Services.UserService>();
           builder.Services.AddScoped<IUserRepository<DAL_Khaoula.Entities.User>,DAL_Khaoula.Srvices.UserService>();

            builder.Services.AddScoped<ICocktailRepository<BLL_Khaoula.Entities.Cocktail>, BLL_Khaoula.Services.CocktailService>();
            builder.Services.AddScoped<ICocktailRepository<DAL_Khaoula.Entities.Cocktail>, DAL_Khaoula.Srvices.CocktailService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
