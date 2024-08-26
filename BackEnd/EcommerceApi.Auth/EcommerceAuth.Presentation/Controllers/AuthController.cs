using MediatR;
using Microsoft.AspNetCore.Mvc;
using EcommerceAuth.Application.Feature.Login;
using EcommerceAuth.Application.Feature.Register;
using EcommerceAuth.Application.Feature.RegisterAdmin;
using EcommerceAuth.Application.Feature.Revoke;
using EcommerceAuth.Application.Feature.RevokeAll;
using EcommerceAuth.Application.Feature.RefreshToken;
using EcommerceAuth.Application.Feature.GetProfiles;

namespace EcommerceAuth.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;
        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AuthRegister(RegisterClientRequest requeste)
        {
            await mediator.Send(requeste);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        public async Task<IActionResult> AuthRegisterAdmin(RegisterAdminRequest requeste)
        {
            await mediator.Send(requeste);
            return StatusCode(StatusCodes.Status201Created);
        }
        [HttpPost]
        public async Task<IActionResult> login(LoginRequest requeste)
        {
            var reponser = await mediator.Send(requeste);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }
        [HttpPost]
        public async Task<IActionResult> refrestoken(RefreshTokenRequest requeste)
        {
            var reponser = await mediator.Send(requeste);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }
        [HttpPost]
        public async Task<IActionResult> getid(GetProfileRequest requeste)
        {
            var reponser = await mediator.Send(requeste);
            return StatusCode(StatusCodes.Status200OK, reponser);
        }
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            if (!Request.Headers.TryGetValue("Authorization", out var headerValues))
            {
                return Unauthorized();
            }

            var token = headerValues.FirstOrDefault()?.Split(' ').LastOrDefault(); // Extract token from Bearer format
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(new { message = "Thành công" });
        }
        //[HttpPost]
        //public async Task<IActionResult> Revoke(RevokeRequest request)
        //{
        //    await mediator.Send(request);
        //    return StatusCode(StatusCodes.Status200OK);
        //}

        //[HttpPost]
        //public async Task<IActionResult> RevokeAll()
        //{
        //    await mediator.Send(new RevokeAllRequest());
        //    return StatusCode(StatusCodes.Status200OK);
        //}
    }
}