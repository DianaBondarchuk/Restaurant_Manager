using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Restaurant_Manager.Services;
using Restaurant_Manager.ViewModel;
using Restaurant_Manager.ViewModels;
using System;
using System.Configuration;
using System.Windows;


namespace Restaurant_Manager
{
    public partial class App : Application
    {
        private IServiceProvider ServiceProvider { get; set; }

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<AppDbContext>(static options =>
                options.UseSqlServer(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));

            
            services.AddSingleton<IMenuItemService, MenuItemService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IRoleService, RoleService>();

            
            services.AddTransient<MenuViewModel>();
            services.AddTransient<LoginViewModel>();

            
            services.AddSingleton<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
