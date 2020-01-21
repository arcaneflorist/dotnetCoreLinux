using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using console.services;
using System;
using db;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure; 
using System.Linq;

namespace console
{
    class Program
    {

        public static IServiceCollection _serviceProvider = null;

        private static void ConfigureServices(IServiceCollection services)
        {
                    services.AddEntityFrameworkMySql(); 
                    services.AddDbContextPool<MyContext>( // replace "YourDbContext" with the class name of your DbContext
                    options => options.UseMySql("server=localhost;database=xerotest;user=root;password=galaxie500;", // replace with your Connection String
                        mySqlOptions =>
                        {
                            mySqlOptions.ServerVersion(new Version(5, 7, 23), ServerType.MySql); // replace with your Server Version and Type
                        }
                ));
        }

        public static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IBaseService, BaseService>()
                .AddSingleton<IExampleService, ExampleService>()
                .BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>()
                .AddConsole(LogLevel.Debug);

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            
            logger.LogDebug("Starting application");

            //do the actual work here
            var bar = serviceProvider.GetService<IExampleService>();
            bar.DoSomeRealWork();

            // var serviceCollection = new ServiceCollection();
            
            // ConfigureServices(serviceCollection);

            try
            {
                using(var context = new MyContext())
                {
                    // Creates the database if not exists
                    logger.LogInformation(context.ProcessableOrders.ToList().FirstOrDefault().OrderId);
                }
            }
            catch (System.Exception e)
            {
                logger.LogError(e.Message);                
                logger.LogError(e.Source);                
                logger.LogError(e.StackTrace);                
            }

            logger.LogDebug("All done!");
        }
    }
}