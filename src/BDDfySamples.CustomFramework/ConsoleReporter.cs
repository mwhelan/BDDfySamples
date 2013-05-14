﻿using System;
using System.Collections.Generic;
using System.Linq;
using TestStack.BDDfy.Configuration;
using TestStack.BDDfy.Core;
using TestStack.BDDfy.Processors;

namespace BDDfySamples.CustomFramework
{
    public class MyConsoleReporter : IBatchProcessor
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