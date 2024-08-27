using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAuth.Application.Feature.RefreshToken
{
    public class RefreshTokenReponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }
}
