using EcommerceAuth.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceAuth.Infrastructure.Interface
{
    public interface ITokenServices
    {
        Task<JwtSecurityToken> CreateToken(User user, IList<string> roles);//Mục đích của phương thức này là tạo ra một mã thông báo bảo mật JWT
        string GenerateRefreshToken();//Mục đích của phương thức này là tạo ra một mã thông báo làm mới (refresh token)
        ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);//Mục đích của phương thức này là lấy ra thông tin xác thực (principal) từ một mã thông báo đã hết hạn
    }
}
