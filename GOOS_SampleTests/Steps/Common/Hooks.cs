using Autofac;
using Autofac.Integration.Mvc;
using FluentAutomation;
using GOOS_Sample.Controllers;
using GOOS_Sample.Interface;
using GOOS_Sample.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace GOOS_SampleTests.Steps.Common
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeTestRun]
        public static void RegisterContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(BudgetController).Assembly);
            builder.RegisterType<BudgetService>().As<IBudgetService>();
            Container = builder.Build();            
        }

        public static IContainer Container { get; set; }

        [BeforeFeature()]
        [Scope(Tag = "web")]
        public static void BeforeFeature()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
        }

        [AfterFeature()]
        public static void AfterFeature()
        {
            
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            CleanTableByTags();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            CleanTableByTags();
        }

        private static void CleanTableByTags()
        {
            var tags = ScenarioContext.Current.ScenarioInfo.Tags
                .Where(x => x.StartsWith("Clean"))
                .Select(x => x.Replace("Clean", ""));
            if (!tags.Any())
            {
                return;
            }
            using (var dbcontext = new GOOSEntitiesForTest())
            {
                foreach (var tag in tags)
                {
                    dbcontext.Database.ExecuteSqlCommand($"TRUNCATE TABLE [{tag}]");
                }
                dbcontext.SaveChangesAsync();
            }
        }
    }
}
