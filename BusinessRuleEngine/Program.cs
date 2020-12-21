using BusinessRulesEngine;
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
                var ruleEngine = servicesProvider.GetRequiredService<RuleEngine>();
                ruleEngine.AddRule();
                var ids = new List<int> { 1, 2, 3, 4, 5, 6 };
                foreach (var id in ids)
                {
                    var rule = ruleEngine.Rules[id];
                    ruleEngine.Perform(rule);
                }
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
                .AddTransient<RuleEngine>()
               .AddTransient<Rule>()
               .BuildServiceProvider();
        }
    }
}
