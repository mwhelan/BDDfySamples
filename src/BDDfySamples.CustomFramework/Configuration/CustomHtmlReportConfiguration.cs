using TestStack.BDDfy.Processors.HtmlReporter;

namespace BDDfySamples.CustomFramework.Configuration
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

        public override string OutputFileName
        {
            get
            {
                return "ContextSpecifications.html";
            }
        }
    }
}