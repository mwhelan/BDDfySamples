using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BDDfySamples.CustomFramework.Tests.Atm;
using TestStack.BDDfy;
using TestStack.BDDfy.Configuration;
using TestStack.BDDfy.Processors;

namespace BDDfySamples.CustomFramework
{
    public class TestRunner
    {
        public void Run()
        {
            RunTestsSequentially();
            RunBatchProcessors();
        }

        private void RunTestsSequentially()
        {
            //new WhenAccountHasInsufficientFunds().Run();
            //new WhenCardHasBeenDisabled().BDDfy();
            //new WhenAccountHasSufficientFunds().BDDfy();

            Specs().Each(spec => spec.Run());
        }

        private void RunBatchProcessors()
        {
            foreach (var batchProcessor in Configurator.BatchProcessors.GetProcessors())
            {
                batchProcessor.Process(StoryCache.Stories);
            }
        }

        private List<ContextSpecification> Specs()
        {
            return this.GetType()
                       .Assembly
                       .GetTypes()
                       .Where(type => type.IsSubclassOf(typeof(ContextSpecification)))
                       .Select(Activator.CreateInstance)
                       .Cast<ContextSpecification>()
                       .ToList();
        }
    }

    public class TestRunner2
    {
        public void Run(bool inParallel = false)
        {
            if (inParallel)
            {
                RunTestsInParallel();
            }
            else
            {
                RunTestsSequentially();
            }
            RunBatchProcessors();
        }

        private void RunTestsSequentially()
        {
            new WhenAccountHasInsufficientFunds().Run();
            new WhenCardHasBeenDisabled().BDDfy();
            new WhenAccountHasSufficientFunds().BDDfy();
        }

        private void RunTestsInParallel()
        {
            Configurator.Processors.ConsoleReport.Disable();
            Configurator.BatchProcessors.Add(new MyConsoleReporter());

            List<ContextSpecification> theSpecs = GetSpecs();
            var batch = theSpecs.Batch(2);

            Parallel.ForEach(batch, specs => specs.Each(spec => spec.Run()));
        }

        private void RunBatchProcessors()
        {
            foreach (var batchProcessor in Configurator.BatchProcessors.GetProcessors())
            {
                batchProcessor.Process(StoryCache.Stories);
            }
        }

        private List<ContextSpecification> GetSpecs()
        {
            return this.GetType()
                       .Assembly
                       .GetTypes()
                       .Where(type => type.IsSubclassOf(typeof(ContextSpecification)))
                       .Select(Activator.CreateInstance)
                       .Cast<ContextSpecification>()
                       .ToList();
        }
    }

}