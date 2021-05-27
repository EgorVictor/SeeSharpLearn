using System;

//生息账户.将获得月末余额 2% 的贷记
namespace Fundamentals.Back.Service
{

    internal class InterestEarningAccount : BankAccount
    {
        internal InterestEarningAccount(string name, decimal initialBalance) : base(name, initialBalance)
        {
        }

        public override void PerformMonthEndTransactions()
        {
            if (Balance > 500)
            {
                var interest = Balance * 0.02m;
                MakeDeposit(interest, DateTime.Now, "利息收入");
            }
        }
    }
}
