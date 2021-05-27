#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.Back
{
    internal class BankAccount
    {
        private static int accountNumberSeed = 1234567890;
        private readonly decimal minimumBalance;
        private List<Transaction> allTransactions = new();
        public BankAccount(string name, decimal initialBalance, decimal minimumBalance)
        {
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            this.Owner = name;
            this.minimumBalance = minimumBalance;
            if (initialBalance > 0)
                MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }

        internal BankAccount(string name, decimal initialBalance) : this(name, initialBalance, 0)
        {
            Number = accountNumberSeed.ToString();
            accountNumberSeed++;
            Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "初始化账户");
        }
        internal decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (Transaction item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        internal string Number { get; }
        internal string Owner { get; }
        public virtual void PerformMonthEndTransactions() { }

        internal string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("日期 \t\t\t 合计 \t\t 余额 \t\t 备注");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t\t{item.Amount}\t\t{balance}\t\t{item.Notes}");
            }

            return report.ToString();
        }
        internal void MakeDeposit(decimal amount, DateTime dateTime, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("存款的数目必须为正数");
            }

            var deposit = new Transaction(amount, dateTime, note);
            allTransactions.Add(deposit);
        }

        internal void MakeWithdrawal(decimal amount, DateTime dateTime, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "取款的数目必须为正数");
            }
            var overdraftTransaction = CheckWithdrawalLimit(Balance - amount < minimumBalance);
            var withdrawal = new Transaction(-amount, dateTime, note);
            allTransactions.Add(withdrawal);
            if (overdraftTransaction != null)
                allTransactions.Add(overdraftTransaction);
        }

        protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            else
            {
                return default;
            }
        }
    }
}
