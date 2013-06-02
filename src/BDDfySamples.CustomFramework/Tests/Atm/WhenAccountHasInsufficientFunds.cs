using BDDfySamples.CustomFramework.Core;

namespace BDDfySamples.CustomFramework.Tests.Atm
{
    public class WhenAccountHasInsufficientFunds : ContextSpecification
    {
        private Card _card;
        private Atm _atm;

        public WhenAccountHasInsufficientFunds()
        {
            ScenarioTitle = "When account funds are less than zero";
        }

        protected override void EstablishContext()
        {
            _card = new Card(true, 10);
            _atm = new Atm(100);
        }

        protected override void BecauseOf()
        {
            _atm.RequestMoney(_card, 20);
        }

        public override UserStory Story
        {
            get { return new AtmWithdrawCashStory(); }
        }

        void ItShouldNotDispenseAnyMoney()
        {
            Assert.AreEqual(0, _atm.DispenseValue);
        }

        void AndItShouldSayThereAreInsufficientFunds()
        {
            Assert.AreEqual(DisplayMessage.InsufficientFunds, _atm.Message);
        }

        void AndItShouldHaveTheSameAccountBalance()
        {
            Assert.AreEqual(10, _card.AccountBalance);
        }

        void AndItShouldReturnTheCard()
        {
            Assert.IsFalse(_atm.CardIsRetained);
        }
    }
}
