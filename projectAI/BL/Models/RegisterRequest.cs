namespace BL.Models
{
    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool Gender { get; set; } // true = Male, false = Female
        public int? AgeGroup { get; set; }
        public byte[]? ProfilePicture { get; set; } = null;

    }

}
