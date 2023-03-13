using System;
using System.Collections.Generic;

namespace Project___The_Bank;


    class Program
    {
        
        static void Main(string[] args)
        {

        /* ----- Creating new clients as individual objects of client's info ----- */
        
        Clients client1 = new Clients("Suhagan", "866547");
        client1.AccountHolders.Add(new AccountsInfo(client1.ClientsID, 20000, AccountType.HomeSavings, "8665", CurrencyType.SEK));
        client1.AccountHolders.Add(new AccountsInfo(client1.ClientsID, 15000, AccountType.CurrentAccount, "6654", CurrencyType.SEK));

        Clients client2 = new Clients("Ashfaqul", "135694");
        client2.AccountHolders.Add(new AccountsInfo(client2.ClientsID, 40000, AccountType.SavingsAccount, "5694", CurrencyType.SEK));
        client2.AccountHolders.Add(new AccountsInfo(client2.ClientsID, 1000, AccountType.CurrentAccount, "3569", CurrencyType.SEK));

        Clients client3 = new Clients("Alex", "123456");
        client3.AccountHolders.Add(new AccountsInfo(client3.ClientsID, 5000, AccountType.JointAccount, "2345", CurrencyType.SEK));
        client3.AccountHolders.Add(new AccountsInfo(client3.ClientsID, 28000, AccountType.FundAccount, "1234", CurrencyType.SEK));
        client3.AccountHolders.Add(new AccountsInfo(client3.ClientsID, 22000, AccountType.CurrentAccount, "1234", CurrencyType.SEK));

        Clients client4 = new Clients("Simon", "654778");
        client4.AccountHolders.Add(new AccountsInfo(client4.ClientsID, 20000, AccountType.CurrentAccount, "4778", CurrencyType.SEK));
        client4.AccountHolders.Add(new AccountsInfo(client4.ClientsID, 50000, AccountType.ISK, "5477", CurrencyType.SEK));

        Clients client5 = new Clients("Suhagan", "126549");
        client5.AccountHolders.Add(new AccountsInfo(client5.ClientsID, 67000, AccountType.SavingsAccount, "6549", CurrencyType.SEK));
        client5.AccountHolders.Add(new AccountsInfo(client5.ClientsID, 29000, AccountType.CurrentAccount, "2654", CurrencyType.SEK));


        Clients[] Client = new Clients[]{ client1, client2, client3, client4, client5 }; // <<--- Creating array of clients


        bool myBool = true; // <<----- Declaring a boolean variable to use as a condition for While loop

        while (myBool)
            {
                Console.Clear();

                // Writing a welcome message to the clients when the system starts.
                Console.WriteLine("**** Dear Clients, Welcome to The Bank [v1.0] ****\n");

            // Creating Client Login Menu

                Console.WriteLine("**** Please, select an option from the below: (Please choose numbers only!) ****\n");
                Console.WriteLine("\n\t <1> Client's Login");
                Console.WriteLine("\t <2> Exit");
                Console.Write("\n Enter your choice : ", "L");

                
                int caseChoice; // <<---- variable initiated to read and save client's choice

                // Using 'TryParse' to help the program not to crash down if users enter something else than a number.

                Int32.TryParse(Console.ReadLine(), out caseChoice); 
                switch (caseChoice)
                {
                    case 1:
                        Console.WriteLine("\n");
                        Console.WriteLine("\tPlease Enter the following details to login to your account.");

                        Console.WriteLine("\tUsername: ");
                        string UserName = Console.ReadLine();

                        Console.WriteLine("\tPassword: ");
                        string PassWord = Console.ReadLine();

                        var SearchItem = Array.Find(Client, item => item.ClientsName.ToLower() == UserName.ToLower() && item.ClientsPassword == PassWord); //Looking into the existing list of username and password, to find out and return, if exists in the list

                        if (SearchItem!=null)


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