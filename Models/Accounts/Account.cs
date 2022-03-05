namespace SchoolingSystem.Models.Accounts
{
    public class Account
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public Profile Profile { get; set; }
        public string Password { get; set; }
        public AccountStatus Status { get; set; }
    }
}