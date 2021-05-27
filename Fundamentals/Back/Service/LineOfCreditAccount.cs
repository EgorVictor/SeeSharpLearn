using System;

//信用额度
//可以有负余额，但绝对值不能大于信用额度。
//如果月末余额不为 0，则每个月都会产生利息费用。
//每次超过信用额度的提款都会产生费用。
namespace Fundamentals.Back.Service
{

    internal class LineOfCreditAccount : BankAccount
    {
        internal LineOfCreditAccount(string name, decimal initialBalance,decimal creditLimit) : base(name, initialBalance,-creditLimit)
        {
        }


        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                var interest = -Balance * 0.07m;
                MakeWithdrawal(interest, DateTime.Now, "负债每月利息");
            }
        }
    }
}
