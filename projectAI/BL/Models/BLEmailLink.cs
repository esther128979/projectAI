using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BLEmailLink
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Link { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }
    }

}
