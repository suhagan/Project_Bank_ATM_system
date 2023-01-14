using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;


namespace ProjectBank_ATM
{
    class Bank_ATM
    {
        public Bank_ATM()
        {
            Console.SetWindowSize(100, 25);
            Console.Title = "Project Bank ATM System[v1.0]";
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void Main(string[] args)
        {
            // Declaring a boolean variable to use as a condition for While loop
            bool myBool = true;

            // Creating while loop to control the whole ATM system
            while (myBool)
            {
                Console.Clear();

                // Writing a welcome message to the users when the system starts.
                Console.WriteLine("**** Welcome to Project Bank ATM System[v1.0] ****\n"); 

                // Creating Client Login Menu
                Console.WriteLine("\n\t <1> Client's Login");
                Console.WriteLine("\t <2> Exit");
                Console.Write("\n Enter your choice : ", "L");

                int caseChoice; // variable initiated read and save user choice
                Int32.TryParse(Console.ReadLine(), out caseChoice); //Using 'TryParse' to help the program not to crash down if users enter something else than a number.

                switch (caseChoice)
                {
                    case 1:
                        Console.WriteLine("\n");
                        Console.WriteLine("\tPlease Enter the following details to login to your account.");
                        Console.WriteLine("\tName: ");
                        Console.ReadLine();
                        Console.WriteLine("\nThanks you for using Bank ATM System!");
                        Console.WriteLine("Press any key to Exit!");

                        break;
                    case 2:
                        Console.WriteLine("\n");
                        Console.WriteLine("Thanks you for using Bank ATM System!");
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
}