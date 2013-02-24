using TestStack.BDDfy;

namespace BDDfySamples.CustomFramework
{
public abstract class ContextSpecification
{
    protected virtual void EstablishContext() { }
    protected virtual void BecauseOf() { }

    public abstract CustomStory Story { get; }

    public void Run()
    {
        this.BDDfy();
    }
}
}