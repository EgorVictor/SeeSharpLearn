using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fundamentals.Back.Service;

namespace Fundamentals.Back.Test
{
    internal class BankTest
    {
        internal static void MainTest()
        {
            var giftCard = new GiftCardAccount("张三", 100, 50);
            giftCard.MakeWithdrawal(20, DateTime.Now, "购买了一些咖啡");
            giftCard.MakeWithdrawal(50, DateTime.Now, "购买食品杂货");
            giftCard.PerformMonthEndTransactions();
            // can make additional deposits:
            giftCard.MakeDeposit(27.50m, DateTime.Now, "添加一些额外的消费");
            Console.WriteLine(giftCard.GetAccountHistory());

            var savings = new InterestEarningAccount("储蓄账户", 10000);
            savings.MakeDeposit(750, DateTime.Now, "存了一些零钱");
            savings.MakeDeposit(1250, DateTime.Now, "再存一笔零钱");
            savings.MakeWithdrawal(250, DateTime.Now, "需要支付每月的账单"); 
            savings.PerformMonthEndTransactions();
            Console.WriteLine(savings.GetAccountHistory());

            var lineOfCredit = new LineOfCreditAccount("张三", 0, 2000);
            // How much is too much to borrow?
            lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
            lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
            lineOfCredit.MakeWithdrawal(500m, DateTime.Now, "Emergency funds for repairs");
            lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
            lineOfCredit.PerformMonthEndTransactions();
            Console.WriteLine(lineOfCredit.GetAccountHistory());
        }
    }
}
