using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingFront
{
    internal class FrontUtils
    {
        public static void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("##############################################################################");
            Console.WriteLine("#################### WELCOME TO THE ONLINE BANKING SYSTEM ####################");
            Console.WriteLine("##############################################################################");
            Console.ResetColor();
        }

        public static void InValidChoice()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("##############################################################################");
            Console.WriteLine("                            ENTER A VALID CHOICE!!                            ");
            Console.WriteLine("##############################################################################");
            Console.ResetColor();
        }

        public static void Greetings()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("##############################################################################");
            Console.WriteLine("                        THANK YOU FOR BANKING WITH US                         ");
            Console.WriteLine("##############################################################################");
            Console.ResetColor();
        }

        public static void AdminOptions()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Choose One of the options below to get started...");
            Console.ResetColor();
            WriteLine("\t 1. Deposit An Amount In A Bank Account");
            WriteLine("\t 2. Withdraw An Amount From A Bank Account");
            WriteLine("\t 3. Transfer An Amount From A Bank Account To Another Bank Account");
            WriteLine("\t 4. Get Account Details Of An Account");
            WriteLine("\t 5. Get Details Of All Accounts");
            WriteLine("\t 6. Get All Tranactions Of A Bank Account");
            WriteLine("\t 7. Delete An Account");
            WriteLine("\t 8. Log Out");
        }

        public static void LoggedInOptions()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Choose One of the options below to get started...");
            Console.ResetColor();
            WriteLine("\t 1. Deposit An Amount In My Bank Account");
            WriteLine("\t 2. Withdraw An Amount From My Bank Account");
            WriteLine("\t 3. Transfer An Amount From My Bank Account To Another Bank Account");
            WriteLine("\t 4. Get My Account Details");
            WriteLine("\t 5. Get All Tranactions Of My Bank Account");
            WriteLine("\t 6. Delete Account");
            WriteLine("\t 7. Log Out");
        }

        public static void LoggedOutOptions()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Choose One of the options below to get started...");
            Console.ResetColor();
            WriteLine("\t 1. Create A New Account");
            WriteLine("\t 2. Register A New User");
            WriteLine("\t 3. LogIn To Your Account");
            WriteLine("\t 4. LogIn As Admin");
            WriteLine("\t 5. Exit");
        }

        public static int UserInputInt(string message)
        {
            WriteLine(message, false);
            int res = ReadInt();
            return res;
        }

        public static string? UserInputString(string message)
        {
            WriteLine(message, false);
            string? res = ReadString();
            return res;
        }

        public static void RunLoop(DateTime startTime, string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(message);
            while (DateTime.UtcNow - startTime < TimeSpan.FromMilliseconds(120))
            {
                DateTime newStrtTime = DateTime.UtcNow;
                while (DateTime.UtcNow - startTime < TimeSpan.FromMilliseconds(200))
                {
                    string passingTime = "Passing Time";
                }
                Console.Write(".");
            }
            Console.ResetColor();
        }

        public static void StartLoop(string message)
        {
            for (int i = 0; i < 7; i++)
            {
                Console.Clear();
                DateTime startTime = DateTime.UtcNow;
                RunLoop(startTime, message);
            }
            Console.WriteLine();
        }

        public static void WriteLine(string message, bool line = true)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (line)
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.Write(message);
            }
            Console.ResetColor();
        }

        public static string? ReadString()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string? res = Console.ReadLine();
            Console.ResetColor();
            return res;
        }

        public static int ReadInt()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            int res = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();
            return res;
        }

    }
}
