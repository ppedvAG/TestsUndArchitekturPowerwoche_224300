using Microsoft.Extensions.DependencyInjection;
using ppedv.HighwayToHell.Data.EfCore;
using ppedv.HighwayToHell.Logic.OrderService;
using ppedv.HighwayToHell.Model.Contracts;
using ppedv.HighwayToHell.UI.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ppedv.HighwayToHell.UI.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();

            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the current <see cref="App"/> instance in use
        /// </summary>
        public new static App Current => (App)Application.Current;

        /// <summary>
        /// Gets the <see cref="IServiceProvider"/> instance to resolve application services.
        /// </summary>
        public IServiceProvider Services { get; }

        /// <summary>
        /// Configures the services for the application.
        /// </summary>
        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            string conString = "Server=(localdb)\\mssqllocaldb;Database=HightwayToHell_dev;Trusted_Connection=true;";
            services.AddScoped<IUnitOfWork, EfUnitOfWork>(x => new EfUnitOfWork(conString));
            services.AddSingleton<IOrderManager, OrderManager>();
            services.AddScoped<CustomerViewModel>();

            return services.BuildServiceProvider();
        }
    }
}
