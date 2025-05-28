using System;
using System.Collections.Generic;

namespace BL.Models
{
   
    public class BLUser
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int Role { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? IsActive { get; set; }

        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public bool Gender { get; set; }
        public int? AgeGroup { get; set; }
        public byte[]? ProfilePicture { get; set; }

        public List<BLEmailLink> EmailLinks { get; set; } = new();
        public List<BLOrder> Orders { get; set; } = new();
    }
}
