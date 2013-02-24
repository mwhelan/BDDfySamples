using System;
using TestStack.BDDfy.Core;
using TestStack.BDDfy.Scanners;

namespace BDDfySamples.CustomFramework
{
public class StoryMetaDataScanner : IStoryMetaDataScanner
{
    public StoryMetaData Scan(object testObject, Type explicitStoryType = null)
    {
        var specification = testObject as ContextSpecification;
        if (specification == null)
            return null;

        var story = specification.Story;

        return new StoryMetaData(story.GetType(), story.AsA, story.IWant, story.SoThat, story.Title);
    }
}
}