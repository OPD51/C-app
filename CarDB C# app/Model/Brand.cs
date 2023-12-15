using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDB.Model
{
    internal class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime FoundingDate { get; set; }

        public string OriginLocation { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
