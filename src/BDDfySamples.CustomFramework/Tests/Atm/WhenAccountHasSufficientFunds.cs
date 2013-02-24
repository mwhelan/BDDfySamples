namespace BDDfySamples.CustomFramework.Tests.Atm
{
    public class WhenAccountHasSufficientFunds : ContextSpecification
    {
        private Card _card;
        private Atm _atm;

        protected override void EstablishContext()
        {
            _card = new Card(true, 100);
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

        public void ItShouldDispenseTheFunds()
        {
            Assert.AreEqual(20, _atm.DispenseValue);
        }

        public void AndItShouldReduceTheAccountBalanceByTheAmountOfTheWithdrawal()
        {
            Assert.AreEqual(80, _card.AccountBalance);
        }

        public void AndItShouldNotRetainTheCard()
        {
            Assert.AreEqual(false, _atm.CardIsRetained);
        }
    }
}
