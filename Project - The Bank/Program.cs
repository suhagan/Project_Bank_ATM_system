using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

namespace Project___The_Bank;


    class Program
    {
        
        static void Main(string[] args)
        {

        /* ----- Creating new clients as individual objects of client's info ----- */
        
        Clients client1 = new Clients("Suhagan", "866547");
        client1.AccountHolders.Add(new AccountsInfo(client1.ClientsID, 20000, AccountType.HomeSavings, CurrencyType.SEK));
        client1.AccountHolders.Add(new AccountsInfo(client1.ClientsID, 15000, AccountType.CurrentAccount, CurrencyType.SEK));

        Clients client2 = new Clients("Ashfaqul", "135694");
        client2.AccountHolders.Add(new AccountsInfo(client2.ClientsID, 40000, AccountType.SavingsAccount, CurrencyType.SEK));
        client2.AccountHolders.Add(new AccountsInfo(client2.ClientsID, 1000, AccountType.CurrentAccount, CurrencyType.SEK));

        Clients client3 = new Clients("Alex", "123456");
        client3.AccountHolders.Add(new AccountsInfo(client3.ClientsID, 5000, AccountType.JointAccount, CurrencyType.SEK));
        client3.AccountHolders.Add(new AccountsInfo(client3.ClientsID, 28000, AccountType.FundAccount, CurrencyType.SEK));
        client3.AccountHolders.Add(new AccountsInfo(client3.ClientsID, 22000, AccountType.CurrentAccount, CurrencyType.SEK));

        Clients client4 = new Clients("Simon", "654778");
        client4.AccountHolders.Add(new AccountsInfo(client4.ClientsID, 20000, AccountType.CurrentAccount, CurrencyType.SEK));
        
        Clients client5 = new Clients("Missouri", "126549");
        client5.AccountHolders.Add(new AccountsInfo(client5.ClientsID, 67000, AccountType.SavingsAccount, CurrencyType.SEK));
        client5.AccountHolders.Add(new AccountsInfo(client5.ClientsID, 29000, AccountType.CurrentAccount, CurrencyType.SEK));


        Clients[] Client = new Clients[]{ client1, client2, client3, client4, client5 }; // <<--- Creating array of clients


        bool myBool = true; // <<----- Declaring a boolean variable to use as a condition for While loop

        while (myBool)
            {
                Console.Clear();

            loginMenu:
                // Writing a welcome message to the clients when the system starts.
                Console.WriteLine("\t**** Dear Clients, Welcome to The Bank [v1.0] ****\n");

            // Creating Client Login Menu

                Console.WriteLine("\n\t**** Please, select an option from the below: (Please choose numbers only!) ****\n");
                Console.WriteLine("\n\t <1> Client's Login");
                Console.WriteLine("\t <2> Exit");
                Console.Write("\n\tEnter your choice : ");

            int leftAttempts = 3;
            //string SearchItem;

            int caseChoice; // <<---- variable initiated to read and save client's choice

                // Using 'TryParse' to help the program not to crash down if users enter something else than a number.

                Int32.TryParse(Console.ReadLine(), out caseChoice); 
                switch (caseChoice)
                {
                    case 1:
                        newLogin:

                        Console.WriteLine("\n\tPlease Enter the following details to login to your account.");

                    
                        Console.WriteLine($"\tUsername: ");
                        string UserName = Console.ReadLine();

                        Console.WriteLine("\tPassword: ");
                        string PassWord = Console.ReadLine();

                        var SearchItem = Array.Find(Client, item => item.ClientsName.ToLower() == UserName.ToLower() && item.ClientsPassword == PassWord); //Looking into the existing list of username and password, to find out and return, if exists in the list

                        if (SearchItem!=null)
                        {
                            Console.WriteLine("\n\tLog in successfull! Welcome to your account.");

                            bool menu = true;

                            // Using a while loop to allow logged in clients to access this menu repeatedly according to their operations and need..
                            while (menu)
                            {
                                Console.WriteLine("\n\tChoose your desired operation: ");
                                Console.WriteLine("\n\t[1] See Accounts Information and Balances");
                                Console.WriteLine("\n\t[2] Transfer between Accounts");
                                Console.WriteLine("\n\t[3] Withdraw Amounts");
                                Console.WriteLine("\n\t[4] Log out");

                                Int32.TryParse(Console.ReadLine(), out int yourOption);

                                switch(yourOption)
                                {
                                case 1: /* ----- To Show accounts informations including balances for logged in user.----- */
                                    int count = SearchItem.AccountHolders.Count();
                                    if (count >= 1)
                                    {
                                        foreach (var item in SearchItem.AccountHolders)
                                        {
                                            Console.WriteLine($"\n\tAccount number: {item.AccountNumber} \n\tAccount type: {item.AccountType} \n\tAccount balance: {item.AccountBalance} {item.CurrencyType}");
                                            Console.ReadKey();
                                            count--;
                                        }
                                        

                                    }
                                    if (count == 0)
                                    {
                                        Console.WriteLine("\n\tPress Enter to return to the operations menu.");
                                        Console.ReadKey();
                                    }
                                    break;

                                case 2: /* ----- To allow clients to transfer amounts between accounts.----- */

                                    int count1 = SearchItem.AccountHolders.Count();
                                    if (count1 > 1) //Client must have more than one account to transfer in between
                                    {

                                        try //using try-catch to handle exceptions to prevent the program from crushing 
                                        {
                                           Console.WriteLine("Choose account number, you want to Transfer from:");
                                           for(int i = 0; i<SearchItem.AccountHolders.Count;i++)
                                           {
                                               Console.WriteLine($"Enter {i + 1} for Acc/No: {SearchItem.AccountHolders[i].AccountNumber}, Acc/Balance: {SearchItem.AccountHolders[i].AccountBalance} {SearchItem.AccountHolders[i].CurrencyType}");
                                           }
                                           Int32.TryParse(Console.ReadLine(), out int transferFrom);

                                           Console.WriteLine("Choose account number, you want to Transfer to:");
                                           for (int k = 0; k < SearchItem.AccountHolders.Count; k++)
                                           {
                                                Console.WriteLine($"Enter {k + 1} for Acc/No: {SearchItem.AccountHolders[k].AccountNumber}, Acc/Balance: {SearchItem.AccountHolders[k].AccountBalance} {SearchItem.AccountHolders[k].CurrencyType}");
                                           }
                                           Int32.TryParse(Console.ReadLine(), out int transferTo);

                                           Console.WriteLine($"Enter Amount to Transfer: ");
                                           Double.TryParse(Console.ReadLine(), out Double amount);

                                           if (amount>0)
                                           {
                                                Double depositAmount = amount;

                                                SearchItem.AccountHolders[transferFrom - 1].WithdrawMoney(amount, DateTime.Now, $"Transferred from account: Acc/No {SearchItem.AccountHolders[transferFrom - 1].AccountNumber}");
                                                SearchItem.AccountHolders[transferTo - 1].MakeDeposit(depositAmount, DateTime.Now, $"Deposited to account: Acc/No {SearchItem.AccountHolders[transferTo - 1].AccountNumber}");
                                                Console.WriteLine($"{amount} SEK has transferred from Acc/No: {SearchItem.AccountHolders[transferFrom - 1].AccountNumber} to Acc/No: {SearchItem.AccountHolders[transferTo - 1].AccountNumber}");

                                                Console.WriteLine($"Acc/No: {SearchItem.AccountHolders[transferFrom - 1].AccountNumber} \tAcc/Balance: {SearchItem.AccountHolders[transferFrom - 1].AccountBalance} {SearchItem.AccountHolders[transferFrom - 1].CurrencyType}");
                                                Console.WriteLine($"Acc/No: {SearchItem.AccountHolders[transferTo - 1].AccountNumber} \tAcc/Balance: {SearchItem.AccountHolders[transferTo - 1].AccountBalance} {SearchItem.AccountHolders[transferTo - 1].CurrencyType}");
                                                Console.WriteLine("Press Enter to return to the operations menu.");
                                                Console.ReadKey();
                                           }
                                        }

                                        catch(Exception ex)
                                        {
                                           Console.WriteLine($"Transfer failed! \n{ex}");
                                            Console.ReadKey();

                                        }
                                    }

                                    if (count1 == 1)
                                            {
                                                Console.WriteLine("\n\tYou do not have more than one account to transfer.");
                                                Console.WriteLine("\n\tPress Enter to return to the operations menu.");
                                                Console.ReadKey();
                                            }
                                    break;
                                   
                                case 3: // Withdrawal of amount
                                    {
                                        try //using try-catch to handle exceptions to prevent the program from crushing 
                                        {
                                            Console.WriteLine("Choose account number, you want to withdraw amount from:");
                                            for (int i = 0; i < SearchItem.AccountHolders.Count; i++)
                                            {
                                                Console.WriteLine($"Enter {i + 1} for Acc/No: {SearchItem.AccountHolders[i].AccountNumber}, Acc/Balance: {SearchItem.AccountHolders[i].AccountBalance} {SearchItem.AccountHolders[i].CurrencyType}");
                                            }
                                            Int32.TryParse(Console.ReadLine(), out int withdrawFrom);

                                            Console.WriteLine($"Enter Amount to withdraw: ");
                                            Double.TryParse(Console.ReadLine(), out Double amount);

                                            if (amount > 0)
                                            {
                                                
                                                SearchItem.AccountHolders[withdrawFrom - 1].WithdrawMoney(amount, DateTime.Now, $"Withdrawn from account: Acc/No {SearchItem.AccountHolders[withdrawFrom - 1].AccountNumber}");
                                                
                                                Console.WriteLine($"{amount} SEK has withdrawn from Acc/No: {SearchItem.AccountHolders[withdrawFrom - 1].AccountNumber}");

                                                Console.WriteLine($"Acc/No: {SearchItem.AccountHolders[withdrawFrom - 1].AccountNumber} \tAcc/Balance: {SearchItem.AccountHolders[withdrawFrom - 1].AccountBalance} {SearchItem.AccountHolders[withdrawFrom - 1].CurrencyType}");
                                                Console.WriteLine("Press Enter to return to the operations menu.");
                                                Console.ReadKey();
                                            }

                                            if (amount < 0)
                                            {
                                                Console.WriteLine("Withdraw amount cannot be negative.");
                                                Console.WriteLine("Press Enter to return to the operations menu.");
                                                Console.ReadKey();
                                            }

                                            if (amount == 0)
                                            {
                                                Console.WriteLine("No amount to withdraw.");
                                                Console.WriteLine("Press Enter to return to the operations menu.");
                                                Console.ReadKey();
                                            }
                                        }

                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"Withdrawal failed! \n{ex}");
                                            Console.ReadKey();
                                        }
                                    }
                                    break;

                                case 4:
                                    
                                    Console.WriteLine("You have successfully logged out!");
                                    menu = false;
                                    goto loginMenu;

                                }

                            }
                        }
                        else
                        {
                            bool tryAgain = true;

                            while (tryAgain)
                            {
                                Console.WriteLine("\n\tLog in unsuccessfull! Either username or password doesn't match.");
                                Console.WriteLine("\n\tPlease enter correct username and password to log in.");
                                Console.WriteLine($"\n\tRemember, you have only {leftAttempts-1} attempts left. Best of luck.");
                                Console.WriteLine("\n\tIf you fail all three (3) attempts, your account will be on authentication hold for 3 minutes. Thanks.");
                                leftAttempts--;

                                if (leftAttempts == 0)
                                {
                                    Console.WriteLine($"Too many wrong attempts! Please wait 3 minutes and try again, Authentication hold starts at {DateTime.Now}");
                                    // Will delay for 180 seconds
                                    Thread.Sleep(3 * 60 * 1000);
                                Console.WriteLine($"You can try log in now {DateTime.Now}");
                                Console.ReadKey();
                                    leftAttempts = 3;
                                }
                                
                                goto newLogin;
                            }
                        }

                    break;
                    case 2:
                        Console.WriteLine("\n");
                        Console.WriteLine("Thanks you for using our system!");
                        Console.WriteLine("Press any key to Exit!");
                        Console.ReadKey();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\n");
                        Console.WriteLine("Incorrect Option | Try Again!");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }


}