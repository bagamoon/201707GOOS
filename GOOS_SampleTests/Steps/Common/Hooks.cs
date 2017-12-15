using FluentAutomation;
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

        [BeforeFeature()]
        [Scope(Tag = "web")]
        public static void SetBrowser()
        {
            SeleniumWebDriver.Bootstrap(SeleniumWebDriver.Browser.Chrome);
        }

        [BeforeScenario]
        public void BeforeScenario()
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

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
