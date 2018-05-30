namespace Login_Controller_Ver.Models
{
    public class Credentials
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public bool Authorized = false;
    }
}