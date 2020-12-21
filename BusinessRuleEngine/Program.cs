using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace BusinessRuleEngine
{
    class Program
    {
        public static IServiceProvider servicesProvider = null;
        static void Main(string[] args)
        {

            PerformUserAction();
            Console.Read();
        }

        private static void PerformUserAction()
        {
            try
            {
                var config = new ConfigurationBuilder()
                  .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                  .Build();

                servicesProvider = BuildDi(config);
               
               
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
            }

        }

        private static IServiceProvider BuildDi(IConfiguration config)
        {
            return new ServiceCollection()
               .BuildServiceProvider();
        }
    }
}
