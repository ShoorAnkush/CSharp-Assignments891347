using System;

public class Account
{
    private string accountNumber;
    private double balance;
    private string type;

    // constructor for a checking account
    public Account(string accountNumber)
    {
        this.accountNumber = accountNumber;
        this.balance = 0.0;
        this.type = "Checking";
    }

    // Constructor for specifyng account type
    public Account(string accountNumber, string type)
    {
        this.accountNumber = accountNumber;
        this.balance = 0.0;
        this.type = type;
    }

    // Constructor for specifying intial balance
    public Account(string accountNumber, double balance)
    {
        this.accountNumber = accountNumber;
        this.balance = balance;
        this.type = "Checking";
    }

    // Constructor for specifying account type and initial balance
    public Account(string accountNumber, string type, double balance)
    {
        this.accountNumber = accountNumber;
        this.balance = balance;
        this.type = type;
    }

    // Method to deposit money into the account
    public void Deposit(double amount)
    {
        balance += amount;
        Console.WriteLine($"{amount} deposited into account {accountNumber}");
    }

    // Method to withdraw money from the account
    public void Withdraw(double amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"{amount} withdrawn from account {accountNumber}");
        }
        else
        {
            Console.WriteLine($"Insufficient funds in account {accountNumber}");
        }
    }

    // Getter method for account balance
    public double GetBalance()
    {
        return balance;
    }

    // Getter method for account number
    public string GetAccountNumber()
    {
        return accountNumber;
    }

    // New getter method for account type
    public new string GetType()
    {
        return type;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating a new account
        Account myAccount = new Account("619619", "Savings", 1500.0);

        // Deposit some money
        myAccount.Deposit(600.0);

        // Withdraw some money
        myAccount.Withdraw(300.0);

        // Display account details
        Console.WriteLine($"Account Number: {myAccount.GetAccountNumber()}");
        Console.WriteLine($"Account Type: {myAccount.GetType()}");
        Console.WriteLine($"Account Balance: {myAccount.GetBalance()}");
    }
}
