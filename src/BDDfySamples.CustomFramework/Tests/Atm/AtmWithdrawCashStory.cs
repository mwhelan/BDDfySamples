using TestStack.BDDfy.Core;

namespace BDDfySamples.CustomFramework.Tests.Atm
{
    public class AtmWithdrawCashStory : CustomStory
    {
        public AtmWithdrawCashStory()
            : base(
                "As an Account Holder",
                "I want to withdraw cash from an ATM",
                "So that I can get money when the bank is closed",
                "Withdrawing cash from the ATM")
        {
        }
    }
}