using TestStack.BDDfy;

namespace BDDfySamples.CustomFramework
{
    public abstract class ContextSpecification
    {
        protected virtual void EstablishContext() { }
        protected virtual void BecauseOf() { }

        public abstract CustomStory Story { get; }

        public virtual string ScenarioTitle { get; set; }

        public void Run()
        {
            if (string.IsNullOrEmpty(ScenarioTitle))
            {
                this.BDDfy();
            }
            else
            {
                this.BDDfy(ScenarioTitle);
            }
        }
    }
}