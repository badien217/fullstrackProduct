using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAuth.Infrastructure.Token
{
    public class TokenSetting
    {
        public string Audience { get; set; }//xác định ai là người nhận hợp lệ của mã thông báo.
        public string Issuer { get; set; }//xác định nguồn gốc của mã thông báo.
        public string Secret { get; set; }//được sử dụng để ký và xác thực mã thông báo, đảm bảo rằng mã thông báo không bị giả mạo.
        public int TokenValidityInMunitues { get; set; }//xác định thời gian mã thông báo sẽ hợp lệ kể từ khi được phát hành.
    }
}
