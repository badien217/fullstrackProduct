using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAuth.Application.Feature.Login
{
    public class LoginReponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
        public string IdClient { get; set; }
        public IList<string> Role { get; set; }
    }
}
