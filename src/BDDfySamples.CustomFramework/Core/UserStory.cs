namespace BDDfySamples.CustomFramework.Core
{
    public abstract class UserStory
    {
        public string Title { get; set; }
        public string AsA { get; set; }
        public string IWant { get; set; }
        public string SoThat { get; set; }
    }
}