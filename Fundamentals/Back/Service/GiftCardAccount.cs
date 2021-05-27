using System;

//礼品卡帐户：
//每月可在每月最后一天补充指定数量一次。
namespace Fundamentals.Back.Service
{
    internal class GiftCardAccount : BankAccount
    {
        private decimal _monthlyDeposit = 0m;
        internal GiftCardAccount(string name, decimal initialBalance, decimal monthlyDeposit) : base(name, initialBalance)
        {
            _monthlyDeposit = monthlyDeposit;
        }

        public override void PerformMonthEndTransactions()
        {
            if (_monthlyDeposit!=0)
            {
                MakeDeposit(_monthlyDeposit,DateTime.Now, "增加每月存款");
            }
        }
    }
}
