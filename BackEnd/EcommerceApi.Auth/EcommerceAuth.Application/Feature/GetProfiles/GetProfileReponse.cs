using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAuth.Application.Feature.GetProfiles
{
    public class GetProfileReponse
    {
        public string Phone { get; set; }
        public string age { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public string avatar { get; set; }
    }
}
