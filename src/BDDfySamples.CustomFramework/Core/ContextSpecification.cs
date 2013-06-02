using TestStack.BDDfy;

namespace BDDfySamples.CustomFramework.Core
{
    public abstract class ContextSpecification
    {
        protected virtual void EstablishContext() { }
        protected virtual void BecauseOf() { }

        public abstract UserStory Story { get; }

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