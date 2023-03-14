using System;

namespace Project___The_Bank
{

	public class AccountsInfo
	{
        public string AccountNumber { get; }
        public AccountType AccountType { get; set; }
        public int UsersId { get; set; }
        public string PinCode { get; set; }
        public CurrencyType CurrencyType { get; set; }

       
        public double AccountBalance
        {
            get
            {
                // calculating balance from All types of transactions
                double accBalance = 0;
                foreach (var item in AllTransactions)
                {
                    accBalance += item.TransactionAmount;
                }

                return accBalance;
            }
        }

        private readonly List<TransactionHistory> AllTransactions = new List<TransactionHistory>();

        private static int InitialAccountNumber = 1234567890; // initialinzing bank account number with 10 digit




        public AccountsInfo(int usersId, double initialBalance, AccountType accType, string pinCode, CurrencyType currencyType)
        {
            AccountNumber = InitialAccountNumber.ToString();
            InitialAccountNumber++;

            UsersId = usersId;
            AccountType = accType;
            CurrencyType = currencyType;
            PinCode = pinCode;
            //AccountBalance = initialBalance;

            if (initialBalance >= 0)
                MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }

        public void MakeDeposit(double amount, DateTime date, string note)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Deposite amount cannot be negative.");
                Console.ReadKey();
            }
            else if (amount == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "No amount to deposite.");
                Console.ReadKey();
            }

            // adding a transaction history
            var deposit = new TransactionHistory(amount, date, note);
            AllTransactions.Add(deposit);
        }

        public void WithdrawMoney(double withdrawamount, DateTime date, string note)
        {

            if (withdrawamount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(withdrawamount), "Sorry! You cannot withdraw a negative amount.");
                //Console.ReadKey();
            }

            

            if (AccountBalance - withdrawamount < 0)
            {
                throw new InvalidOperationException("Sorry! Not sufficient funds for this withdrawal");
                //Console.ReadKey();
            }

            // adding a withdrawal as a new transaction
            var withdrawal = new TransactionHistory(-withdrawamount, date, note);
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
        SEK,
    }
}