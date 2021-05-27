using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals.Back
{
    internal class Transaction
    {
        internal decimal Amount { get; }
        internal DateTime Date { get; }
        internal string Notes { get; }

        public Transaction(decimal amount, DateTime date, string notes)
        {
            Amount = amount;
            Date = date;
            Notes = notes;
        }
    }
}
