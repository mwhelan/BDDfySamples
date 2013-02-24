using System;
using BDDfySamples.CustomFramework.Tests.Atm;
using TestStack.BDDfy;
using TestStack.BDDfy.Configuration;
using TestStack.BDDfy.Processors;
using TestStack.BDDfy.Processors.HtmlReporter;

namespace BDDfySamples.CustomFramework
{
class Program
{
    static void Main(string[] args)
    {
        ConfigureBDDfy();
        RunTestsSequentially();
        RunBatchProcessors();

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

    private static void RunTestsSequentially()
    {
        new WhenAccountHasInsufficientFunds().Run();
        new WhenCardHasBeenDisabled().BDDfy();
        new WhenAccountHasSufficientFunds().BDDfy();
    }

    private static void RunBatchProcessors()
    {
        foreach (var batchProcessor in Configurator.BatchProcessors.GetProcessors())
        {
            batchProcessor.Process(StoryCache.Stories);
        }
    }
}
}
