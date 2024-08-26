using EcommerceAPI.SharedLibrary.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAuth.Application.Feature.Exception
{
    public class RefreshTokenShouldNotBeExpiredException : BaseException
    {
        public RefreshTokenShouldNotBeExpiredException() : base("Thời gian đăng nhập của bạn đã hết!Bạn cần đăng nhập lại") { }
    }
}
