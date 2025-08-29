namespace task_1
{
    using System;
    using System.Collections.Generic;

    public class Account
    {
        private string name;
        private double balance;

        public Account(string name = "Unnamed Account", double balance = 0.0)
        {
            this.name = name;
            this.balance = balance;
        }

        public virtual bool Deposit(double amount)
        {
            if (amount < 0)
                return false;
            balance += amount;
            return true;
        }

        public virtual bool Withdraw(double amount)
        {
            if (balance - amount >= 0)
            {
                balance -= amount;
                return true;
            }
            return false;
        }

        public double GetBalance() => balance;

        public override string ToString()
        {
            return $"[Account: {name}, Balance: {balance}]";
        }
    }

    // 1. SavingsAccount
    public class SavingsAccount : Account
    {
        private double interestRate;

        public SavingsAccount(string name = "Unnamed Savings Account", double balance = 0.0, double interestRate = 0.0)
            : base(name, balance)
        {
            this.interestRate = interestRate;
        }

        public override bool Deposit(double amount)
        {
            if (base.Deposit(amount))
            {
                // Add interest
                double interest = amount * (interestRate / 100);
                return base.Deposit(interest);
            }
            return false;
        }

        public override string ToString()
        {
            return $"[SavingsAccount: {base.ToString()}, Interest Rate: {interestRate}%]";
        }
    }

    // 2. CheckingAccount
    public class CheckingAccount : Account
    {
        private static double withdrawalFee = 1.5;

        public CheckingAccount(string name = "Unnamed Checking Account", double balance = 0.0)
            : base(name, balance) { }

        public override bool Withdraw(double amount)
        {
            // Withdrawal with fee
            return base.Withdraw(amount + withdrawalFee);
        }

        public override string ToString()
        {
            return $"[CheckingAccount: {base.ToString()}, Withdrawal Fee: {withdrawalFee}]";
        }
    }

    // 3. TrustAccount
    public class TrustAccount : SavingsAccount
    {
        private int withdrawalCount = 0;
        private const int MaxWithdrawals = 3;

        public TrustAccount(string name = "Unnamed Trust Account", double balance = 0.0, double interestRate = 0.0)
            : base(name, balance, interestRate) { }

        public override bool Deposit(double amount)
        {
            // Bonus for large deposits
            if (amount >= 5000)
            {
                return base.Deposit(amount + 50);
            }
            return base.Deposit(amount);
        }

        public override bool Withdraw(double amount)
        {
            double balance = GetBalance();

            if (withdrawalCount >= MaxWithdrawals || amount > balance * 0.20)
                return false;

            if (base.Withdraw(amount))
            {
                withdrawalCount++;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"[TrustAccount: {base.ToString()}, Withdrawals: {withdrawalCount}/{MaxWithdrawals}]";
        }
    }

    // === Utility class ===
    public static class AccountUtil
    {
        // Utility helper functions for Account class

        public static void Display(List<Account> accounts)
        {
            Console.WriteLine("\n=== Accounts ==========================================");
            foreach (var acc in accounts)
            {
                Console.WriteLine(acc);
            }
        }

        public static void Deposit(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc}");
            }
        }

        public static void Withdraw(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
            }
        }

        // Helper functions for Savings Account class

        // Helper functions for Checking Account class

        // Helper functions for Trust account class
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Base Accounts
            var accounts = new List<Account>
            {
                new Account(),
                new Account("Larry"),
                new Account("Moe", 2000),
                new Account("Curly", 5000)
            };
            AccountUtil.Display(accounts);
            AccountUtil.Deposit(accounts, 1000);
            AccountUtil.Withdraw(accounts, 2000);

            // Savings Accounts
            var savAccounts = new List<Account>
            {
                new SavingsAccount(),
                new SavingsAccount("Superman"),
                new SavingsAccount("Batman", 2000),
                new SavingsAccount("Wonderwoman", 5000, 5.0)
            };
            AccountUtil.Display(savAccounts);
            AccountUtil.Deposit(savAccounts, 1000);
            AccountUtil.Withdraw(savAccounts, 2000);

            // Checking Accounts
            var checAccounts = new List<Account>
            {
                new CheckingAccount(),
                new CheckingAccount("Larry2"),
                new CheckingAccount("Moe2", 2000),
                new CheckingAccount("Curly2", 5000)
            };
            AccountUtil.Display(checAccounts);
            AccountUtil.Deposit(checAccounts, 1000);
            AccountUtil.Withdraw(checAccounts, 2000);

            // Trust Accounts
            var trustAccounts = new List<Account>
            {
                new TrustAccount(),
                new TrustAccount("Superman2"),
                new TrustAccount("Batman2", 2000),
                new TrustAccount("Wonderwoman2", 10000, 5.0)
            };
            AccountUtil.Display(trustAccounts);
            AccountUtil.Deposit(trustAccounts, 6000);   // should add bonus
            AccountUtil.Withdraw(trustAccounts, 2000); 
            AccountUtil.Withdraw(trustAccounts, 3000);  
            AccountUtil.Withdraw(trustAccounts, 500);   
            AccountUtil.Withdraw(trustAccounts, 500);   

            Console.WriteLine("\n=== Program Finished ===");
        }
    }
}
