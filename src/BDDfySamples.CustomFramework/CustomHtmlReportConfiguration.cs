﻿using TestStack.BDDfy.Processors.HtmlReporter;

namespace BDDfySamples.CustomFramework
{
    public class CustomHtmlReportConfiguration : DefaultHtmlReportConfiguration
    {
        public override string ReportHeader
        {
            get
            {
                return "Context Specifier";
            }
        }

        public override string ReportDescription
        {
            get
            {
                return "A simple context specification framework for .Net developers";
            }
        }
    }
}