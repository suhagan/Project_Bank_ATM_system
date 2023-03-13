using System;
using System.Transactions;


namespace Project___The_Bank
{

	public class AccountsInfo
	{
        public string AccountNumber { get; }
        public AccountType AccountType { get; set; }
        public int UsersId { get; set; }
        public string PinCode { get; set; }
        public CurrencyType CurrencyType { get; set; }

        private readonly List<Transaction> AllTransactions = new List<Transaction>();

        public double AccountBalance
        {
            get
            {
                // calculating balance from All types of transactions
                double accBalance = 0;
                foreach (var item in AllTransactions)
                {
                    accBalance += item.Amount;
                }

                return accBalance;
            }
        }

        private static int InitialAccountNumber = 1234567890; // initialinzing bank account number with 10 digit




        public AccountsInfo(int usersId, double initialBalance, AccountType accType, string pinCode, CurrencyType currencyType)
        {
            AccountNumber = InitialAccountNumber.ToString();
            InitialAccountNumber++;

            UsersId = usersId;
            AccountType = accType;
            CurrencyType = currencyType;
            PinCode = pinCode;
        }

        public void WithdrawMoney(double withdrawamount, DateTime date, string note)
        {

            if (withdrawamount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(withdrawamount), "You cannot withdraw a negative amount.");
            }

            if (withdrawamount == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(withdrawamount), "Your desired withdraw amount cannot be 0 (zero).");
            }

            if (AccountBalance - withdrawamount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }

            // adding a withdrawal as a new transaction
            var withdrawal = new TransactionHistory(-withdrawamount, date, time, msg);
            AllTransactions.Add(withdrawal);
        }
    }

    public enum AccountType
    {
        CurrentAccount,
        SavingsAccount,
        HomeSavings,
        JointAccount,
        ISK,
        FundAccount
    }

    public enum CurrencyType
    {
        SEK
    }
}