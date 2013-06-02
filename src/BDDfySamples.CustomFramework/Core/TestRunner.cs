using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BDDfySamples.CustomFramework.Processors;
using TestStack.BDDfy.Configuration;
using TestStack.BDDfy.Processors;

namespace BDDfySamples.CustomFramework.Core
{
    public class TestRunner
    {
        public void Run(int batchSize = 0)
        {
            if (batchSize == 0)
            {
                RunTestsSequentially();
            }
            else
            {
                RunTestsInParallel(batchSize);
            }
            RunBatchProcessors();
        }

        private void RunTestsInParallel(int batchSize)
        {
            Configurator.Processors.ConsoleReport.Disable();
            Configurator.BatchProcessors.Add(new BatchConsoleReporter());

            List<ContextSpecification> theSpecs = GetSpecs();
            var batch = theSpecs.Batch(batchSize);

            Parallel.ForEach(batch, specs => specs.Each(spec => SafeRunSpec(spec)));
        }

        private void RunTestsSequentially()
        {
            //new WhenAccountHasInsufficientFunds().Run();
            //new WhenCardHasBeenDisabled().BDDfy();
            //new WhenAccountHasSufficientFunds().BDDfy();

            GetSpecs().Each(spec => SafeRunSpec(spec));
        }

        private void SafeRunSpec(ContextSpecification spec)
        {
            try
            {
                spec.Run();
            }
            catch (Exception)
            {
            }
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