namespace P3C8;

    public class AccountHolder(string name, int accountid)
    {
        public string Name { get; set; } = name;
        public int AccountId { get; set; } = accountid;

        public static void AccountHolderInfo()
        {
            AccountHolder accountHolder = new AccountHolder("John Doe", 123456);
            Console.WriteLine($"Nom : {accountHolder.Name} - Numéro de compte : {accountHolder.AccountId}");
        }
    }
    public class Account
    {
        public Account()
        {
        }
    }
