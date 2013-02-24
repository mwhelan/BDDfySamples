namespace BDDfySamples.CustomFramework.Tests.Atm
{
    public class WhenCardHasBeenDisabled : ContextSpecification
    {
        private Card _card;
        private Atm _atm;

        protected override void EstablishContext()
        {
            _card = new Card(false, 100);
            _atm = new Atm(100);
        }

        protected override void BecauseOf()
        {
            _atm.RequestMoney(_card, 20);
        }

        public override CustomStory Story
        {
            get { return new AtmWithdrawCashStory(); }
        }

        public void ItShouldRetainTheCard()
        {
            Assert.AreEqual(true, _atm.CardIsRetained);
        }

        void AndItShouldSayTheCardHasBeenRetained()
        {
            Assert.AreEqual(DisplayMessage.CardIsRetained, _atm.Message);
        }
    }
}