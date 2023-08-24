namespace ReservationsPrototype.Models
{
    public class SiteUser
    {
        private string password;

        public string UserName { get; set; }
        public string Password { get => password; set => password = value; }
    }
}
