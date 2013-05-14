using System;
using TestStack.BDDfy.Configuration;
using TestStack.BDDfy.Processors.HtmlReporter;

namespace BDDfySamples.CustomFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigureBDDfy();
            new TestRunner().Run();

            Console.ReadLine();
        }

        private static void ConfigureBDDfy()
        {
            Configurator.Scanners.DefaultMethodNameStepScanner.Disable();
            Configurator.Scanners.Add(() => new ContextSpecificationStepScanner());

            Configurator.Scanners.StoryMetaDataScanner = () => new StoryMetaDataScanner();

            Configurator.BatchProcessors.HtmlReport.Disable();
            Configurator.BatchProcessors.Add(new HtmlReporter(new CustomHtmlReportConfiguration()));
        }
    }
}
