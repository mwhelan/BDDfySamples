using System.Collections.Generic;
using System.Linq;
using TestStack.BDDfy.Core;
using TestStack.BDDfy.Processors;

namespace BDDfySamples.CustomFramework.Processors
{
    public class BatchConsoleReporter : IBatchProcessor
    {
        public void Process(IEnumerable<Story> stories)
        {
            var reporter = new ConsoleReporter();
            stories
                .ToList()
                .ForEach(story => reporter.Process(story));
        }
    }
}