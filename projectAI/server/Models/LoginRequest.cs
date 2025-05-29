namespace server.Models
{
    //public class LoginRequest
    //{
    //    public string Username { get; set; }
    //    public int IdentityNumber { get; set; }
    //}
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

}
