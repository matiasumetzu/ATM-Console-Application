// See https://aka.ms/new-console-template for more information
public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public string getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(string newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }


    public static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposit?");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Your new balance is: " + currentUser.getBalance());
        }

        void withdrawals(cardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw?");
            double withdrawal = double.Parse(Console.ReadLine());
            // check if the user has enough money
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("You do not have enough money to withdraw that amount.");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You're good to go! " + "Your new balance is: " + currentUser.getBalance());
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Your current balance is: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4289737941259880", 1234, "John", "Griffith", 150.31));
        cardHolders.Add(new cardHolder("4783600287155214", 4321, "Ashley", "Jones", 321.13));
        cardHolders.Add(new cardHolder("4719018690448473 ", 9999, "Frida", "Dickerson", 105.59));
        cardHolders.Add(new cardHolder("4312641383680010   ", 2468, "Muneeb", "Harding", 851.84));
        cardHolders.Add(new cardHolder("4423723926134444 ", 4826, "Dawn", "Smith", 54.27));

        //Prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert your debit card: ");
        string debitCardNum = "";
        cardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check against our db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);

                if (currentUser != null)
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Card not recognized. Please try again.");
                }

            }

            catch
            {
                Console.WriteLine("Card not recognized. Please try again.");

            }
        }

        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                //check against our db

                if (currentUser.getPin() == userPin)
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Incorrect pin. Please try again.");
                }

            }

            catch
            {
                Console.WriteLine("Incorrect pin. Please try again.");
            }
        }


        Console.WriteLine("Welcome " + currentUser.getFirstName() + ":)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }

            catch
            {
                Console.WriteLine("Invalid option. Please try again.");
            }

            if (option == 1)
            {
                deposit(currentUser);
            }

            else if (option == 2)
            {
                withdrawals(currentUser);
            }

            else if (option == 3)
            {
                balance(currentUser);
            }

            else if (option == 4)
            {
                break;
            }

            else
            {
                option = 0;
            }

        }
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day!");

    }
}

