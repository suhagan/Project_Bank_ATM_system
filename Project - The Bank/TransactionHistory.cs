using System;

namespace Project___The_Bank
{
	public class TransactionHistory
	{
        public DateTime TransactionDate { get; }
        public double TransactionAmount { get; }
        public string TransactionMessage { get; }

        public TransactionHistory(double amount, DateTime date, string msg)
        {
            TransactionAmount = amount;
            TransactionDate = date;
            
            TransactionMessage = msg;
        }
    }
}

