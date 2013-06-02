using BDDfySamples.CustomFramework.Core;

namespace BDDfySamples.CustomFramework.Tests.Atm
{
    public class AtmWithdrawCashStory : UserStory
    {
        public AtmWithdrawCashStory()
        {
            Title = "Withdrawing cash from the ATM";
            AsA = "As an Account Holder";
            IWant = "I want to withdraw cash from an ATM";
            SoThat = "So that I can get money when the bank is closed";
        }
    }
}