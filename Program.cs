using BankingSupport;

namespace BankingFront
{
    class Program
    {
        static readonly BankRepository newBank = new BankRepository();
        static int accountNumber = Utilities.SelectMaxAccNumber();

        public static void LoggedIn() {

            Console.Clear(); // Clearing the console

            // Empty Variables to store temporary data
            int amt;
            bool success;
            SBAccount? result;
            List<SBTransaction>? transactionsList;
            bool loginLoop = true;

            while (loginLoop)
            {
                FrontUtils.LoggedInOptions(); // Displays Options For Online Banking

                int choice = FrontUtils.UserInputInt("Your Choice? "); // Gets user's choice from options above

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        FrontUtils.WriteLine("Provide the following details for depositing an amount: ");
                        amt = FrontUtils.UserInputInt("\t Enter the amount to be deposited: ");
                        success = newBank.DepositAmount(BankRepository.loggedInUser.AccountNumber, amt);

                        if (success)
                        {
                            FrontUtils.StartLoop("Carrying out your transaction..");
                            FrontUtils.WriteLine($"\t {amt} successfully deposited to account number {BankRepository.loggedInUser.AccountNumber}");
                        }
                        Console.WriteLine("");
                        break;
                    case 2:
                        Console.Clear();
                        FrontUtils.WriteLine("Provide the following details for withdrawing an amount: ");
                        amt = FrontUtils.UserInputInt("\t Enter the amount to be withdrawn: ");
                        success = newBank.WithdrawAmount(BankRepository.loggedInUser.AccountNumber, amt);
                        if (success)
                        {
                            FrontUtils.StartLoop("Carrying out your transaction...");
                            FrontUtils.WriteLine($"\t {amt} successfully withdrawn from account number {BankRepository.loggedInUser.AccountNumber}");
                        }
                        Console.WriteLine("");
                        break;
                    case 3:
                        Console.Clear();
                        FrontUtils.WriteLine("Provide the following details for transferring an amount: ");
                        int toAcc = FrontUtils.UserInputInt("\t  Enter the account number of the beneficiary: ");
                        amt = FrontUtils.UserInputInt("\t  Enter the amount to be transferred: ");
                        success = newBank.TransferAmount(BankRepository.loggedInUser.AccountNumber, toAcc, amt);
                        if (success)
                        {
                            FrontUtils.StartLoop("Carrying out your transaction...");
                            FrontUtils.WriteLine($"\t Successfully transferred the amount {amt} from account number {BankRepository.loggedInUser.AccountNumber} to account number {toAcc}");
                        }
                        Console.WriteLine("");
                        break;
                    case 4:
                        Console.Clear();
                        result = newBank.GetAccountDetails(BankRepository.loggedInUser.AccountNumber);
                        if (result != null)
                        {
                            FrontUtils.StartLoop("Getting your account details...");
                            FrontUtils.WriteLine(result.ToString());
                        }
                        Console.WriteLine("");
                        break;
                    case 5:
                        Console.Clear();
                        transactionsList = newBank.GetTransactions(BankRepository.loggedInUser.AccountNumber);
                        if (transactionsList != null)
                        {
                            FrontUtils.StartLoop("Getting all your transaction details");
                            FrontUtils.WriteLine($"Here are all the transaction details of all the transactions made from the account number {BankRepository.loggedInUser.AccountNumber}: ");
                            foreach (SBTransaction transaction in transactionsList)
                            {
                                Console.WriteLine();
                                FrontUtils.WriteLine(transaction.ToString());
                            }
                        }
                        Console.WriteLine("");
                        break;
                    case 6:
                        success = newBank.DeleteAccount(BankRepository.loggedInUser.AccountNumber);
                        if (success)
                        {
                            FrontUtils.StartLoop("Deleting your account...");
                            FrontUtils.WriteLine($"Account and User with account number {BankRepository.loggedInUser.AccountNumber} deleted successfully!");
                            loginLoop = false;
                        }
                        Console.Clear();
                        break;
                    case 7:
                        success = newBank.LogoutUser();
                        if (success)
                        {
                            FrontUtils.StartLoop("Logging You Out...");
                            FrontUtils.WriteLine("Logged Out Successfully");
                        }
                        loginLoop = false;
                        break;
                    default:
                        FrontUtils.InValidChoice();
                        break;
                }
            }
        }

        public static void LoggedOut(bool showWelcome = false) {

            if(!showWelcome) Console.Clear(); // Clear the console

            // Empty Variables to store temporary data
            int accno;
            string? customername, customeraddress, username;
            string password = "", confirmPass = "";
            bool success;
            SBAccount? newAccount;
            bool keepLooping = true;

            while (keepLooping)
            {
                FrontUtils.LoggedOutOptions(); // Displays Options For Online Banking

                int choice = FrontUtils.UserInputInt("Your choice? "); // Gets user's choice from options above

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        FrontUtils.WriteLine("Enter the following details to create a new account...");
                        customername = FrontUtils.UserInputString("\t  Enter account holder's name: ");
                        while (customername == "" || customername == null)
                        {
                            customername = FrontUtils.UserInputString("\t  Customer Name cannot be null! Enter a valid name: ");
                        }
                        customeraddress = FrontUtils.UserInputString("\t  Enter account holder's address: ");
                        while (customeraddress == "" || customeraddress == null)
                        {
                            customeraddress = FrontUtils.UserInputString("\t  Customer Address cannot be null! Enter a valid address: ");
                        }
                        newAccount = new SBAccount(accountNumber, customername, customeraddress, 0);
                        success = newBank.NewAccount(newAccount);
                        if (success)
                        {
                            FrontUtils.StartLoop("Getting your new account ready...");
                            FrontUtils.WriteLine("\t Congratulations!! You have successfully created a brand new account!");
                            FrontUtils.WriteLine("\t Details:");
                            FrontUtils.WriteLine($"\t\t Account Number: {accountNumber}");
                            FrontUtils.WriteLine($"\t\t Account Holder's Name: {customername}");
                            FrontUtils.WriteLine($"\t\t Account Holder's Address: {customeraddress}");
                            accountNumber++;
                        }
                        Console.WriteLine("");
                        break;
                    case 2:
                        Console.Clear();
                        FrontUtils.WriteLine("Enter following details to register a new user...");
                        accno = FrontUtils.UserInputInt("\t  Enter account number: ");
                        username = FrontUtils.UserInputString("\t  Enter username: ");
                        while (username == "" || username == null)
                        {
                            username = FrontUtils.UserInputString("\t  Username cannot be null! Enter a valid username: ");
                        }
                        FrontUtils.WriteLine("\t Enter password: ", false);
                        while (true)
                        {
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Enter)
                                break;
                            password += key.KeyChar;
                        }
                        while (password == "")
                        {
                            FrontUtils.WriteLine("\t Password cannot be null! Enter a valid password: ", false);
                            while (true)
                            {
                                var key = Console.ReadKey(true);
                                if (key.Key == ConsoleKey.Enter)
                                    break;
                                password += key.KeyChar;
                            }
                        }
                        FrontUtils.WriteLine("\t Confirm password: ", false);
                        while (true)
                        {
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Enter)
                                break;
                            confirmPass += key.KeyChar;
                        }
                        while (confirmPass != password)
                        {
                            confirmPass = "";
                            FrontUtils.WriteLine("\t Passwords do not match!! Confirm Password: ", false);
                            while (true)
                            {
                                var key = Console.ReadKey(true);
                                if (key.Key == ConsoleKey.Enter)
                                    break;
                                confirmPass += key.KeyChar;
                            }
                        }
                        success = newBank.RegisterNewUser(username, password, accno);
                        password = "";
                        confirmPass = "";
                        if(success)
                        {
                            FrontUtils.StartLoop("Registering you as a new user...");
                            FrontUtils.WriteLine($"New user with username {username} created for account number {accno}");
                            FrontUtils.WriteLine("Log in to your account using your account credentials...");
                        }
                        break;
                    case 3:
                        FrontUtils.WriteLine("Enter following details to login...");
                        username = FrontUtils.UserInputString("\t  Enter username: ");
                        while (username == "Admin")
                        {
                            username = FrontUtils.UserInputString("\t  Cannot log in to admin through this route! Enter a valid username: ");
                        }
                        FrontUtils.WriteLine("\t Enter password: ", false);
                        while (true)
                        {
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Enter)
                                break;
                            password += key.KeyChar;
                        }
                        success = newBank.LoginUser(username, password);
                        password = "";
                        if(success)
                        {
                            FrontUtils.StartLoop("Logging You In...");
                            FrontUtils.WriteLine("Logged In Successfully!");
                            LoggedIn();
                        }
                        break;
                    case 4:
                        FrontUtils.WriteLine("Enter following details to login...");
                        username = FrontUtils.UserInputString("\t  Enter username: ");
                        while (username != "Admin")
                        {
                            username = FrontUtils.UserInputString("\t  Cannot log in to user account through this route! Enter a valid username: ");
                        }
                        FrontUtils.WriteLine("\t Enter password: ", false);
                        while (true)
                        {
                            var key = Console.ReadKey(true);
                            if (key.Key == ConsoleKey.Enter)
                                break;
                            password += key.KeyChar;
                        }
                        success = newBank.LoginUser(username, password);
                        password = "";
                        if (success)
                        {
                            FrontUtils.StartLoop("Logging You In...");
                            FrontUtils.WriteLine("Logged In To Admin Successfully!");
                            Admin();
                        }
                        break;
                    case 5:
                        keepLooping = false;
                        FrontUtils.StartLoop("Exiting the application...");
                        Console.Clear();
                        break;
                    default:
                        FrontUtils.InValidChoice();
                        break;
                }
            }
        }

        public static void Admin()
        {

            Console.Clear(); // Clear the console

            // Empty Variables to store temporary data
            int accno, amt;
            bool success;
            SBAccount? result;
            List<SBAccount>? accountsList;
            List<SBTransaction>? transactionsList;
            bool adminLoop = true;

            while (adminLoop)
            {
                FrontUtils.AdminOptions(); // Displays Options For Online Banking

                int choice = FrontUtils.UserInputInt("Your choice? "); // Gets user's choice from options above

                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        FrontUtils.WriteLine("Provide the following details for depositing an amount: ");
                        accno = FrontUtils.UserInputInt("\t  Enter the account number of the beneficiary: ");
                        amt = FrontUtils.UserInputInt("\t  Enter the amount to be deposited: ");
                        success = newBank.DepositAmount(accno, amt);
                        if (success)
                        {
                            FrontUtils.StartLoop("Carrying out your transaction...");
                            FrontUtils.WriteLine($"\t {amt} successfully deposited to account number {accno}");
                        }
                        Console.WriteLine("");
                        break;
                    case 2:
                        Console.Clear();
                        FrontUtils.WriteLine("Provide the following details for withdrawing an amount: ");
                        accno = FrontUtils.UserInputInt("\t  Enter the account number to withdraw from: ");
                        amt = FrontUtils.UserInputInt("\t  Enter the amount to be withdrawn: ");
                        success = newBank.WithdrawAmount(accno, amt);
                        if (success)
                        {
                            FrontUtils.StartLoop("Carrying out your transaction...");
                            FrontUtils.WriteLine($"\t {amt} successfully withdrawn from account number {accno}");
                        }
                        Console.WriteLine("");
                        break;
                    case 3:
                        Console.Clear();
                        FrontUtils.WriteLine("Provide the following details for transferring an amount: ");
                        int fromAcc = FrontUtils.UserInputInt("\t  Enter the account number to withdraw from: ");
                        int toAcc = FrontUtils.UserInputInt("\t  Enter the account number of the beneficiary: ");
                        amt = FrontUtils.UserInputInt("\t  Enter the amount to be transferred: ");
                        success = newBank.TransferAmount(fromAcc, toAcc, amt);
                        if (success)
                        {
                            FrontUtils.StartLoop("Carrying out your transaction...");
                            FrontUtils.WriteLine($"\t Successfully transferred the amount {amt} from account number {fromAcc} to account number {toAcc}");
                        }
                        Console.WriteLine("");
                        break;
                    case 4:
                        Console.Clear();
                        FrontUtils.WriteLine("Provide the following details to get account details: ");
                        accno = FrontUtils.UserInputInt("\t  Enter the account number: ");
                        result = newBank.GetAccountDetails(accno);
                        if (result != null)
                        {
                            FrontUtils.StartLoop($"Getting account details for {accno}...");
                            FrontUtils.WriteLine(result.ToString());
                        }
                        Console.WriteLine("");
                        break;
                    case 5:
                        Console.Clear();
                        accountsList = newBank.GetAllAccounts();
                        if (accountsList != null)
                        {
                            FrontUtils.StartLoop("Getting account details for all accounts...");
                            FrontUtils.WriteLine("Here are all the account details of all the accounts: ");
                            foreach (SBAccount account in accountsList)
                            {
                                Console.WriteLine();
                                FrontUtils.WriteLine(account.ToString());
                            }
                        }
                        Console.WriteLine("");
                        break;
                    case 6:
                        Console.Clear();
                        FrontUtils.WriteLine("Provide the following details to get transaction details of an account: ");
                        accno = FrontUtils.UserInputInt("\t  Enter the account number: ");
                        transactionsList = newBank.GetTransactions(accno);
                        if (transactionsList != null)
                        {
                            FrontUtils.StartLoop($"Getting transaction details for {accno}...");
                            FrontUtils.WriteLine($"\t Here are all the transaction details of all the transactions made from the account number {accno}: ");
                            foreach (SBTransaction transaction in transactionsList)
                            {
                                Console.WriteLine();
                                FrontUtils.WriteLine(transaction.ToString());
                            }
                        }
                        Console.WriteLine("");
                        break;
                    case 7:
                        Console.Clear();
                        FrontUtils.WriteLine("Provide the following details to delete the account: ");
                        accno = FrontUtils.UserInputInt("\t  Enter the account number: ");
                        success = newBank.DeleteAccount(accno);
                        if (success)
                        {
                            FrontUtils.StartLoop($"Deleting the account for Account Number: {accno}...");
                            FrontUtils.WriteLine($"Account with account number {accno} deleted successfully!");
                        }
                        Console.WriteLine("");
                        break;
                    case 8:
                        success = newBank.LogoutUser();
                        if (success)
                        {
                            FrontUtils.StartLoop("Logging You Out....");
                            FrontUtils.WriteLine("Logged Out Successfully");
                        }
                        adminLoop = false;
                        break;
                    default:
                        FrontUtils.InValidChoice();
                        break;
                }
            }
        }

        public static void Main(string[] args)
        {
            

            FrontUtils.Welcome(); // Welcome Message

            LoggedOut(true);

            FrontUtils.Greetings();
        }
    }
}