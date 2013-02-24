namespace BDDfySamples.CustomFramework
{
    public abstract class CustomStory
    {
        public CustomStory(string asA, string iWant, string soThat, string storyTitle = null)
        {
            Title = storyTitle;

            AsA = asA;
            IWant = iWant;
            SoThat = soThat;
        }

        public string Title { get; private set; }
        public string AsA { get; private set; }
        public string IWant { get; private set; }
        public string SoThat { get; private set; }
    }
}