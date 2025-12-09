using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetDotnetM1Sopra20252026.Models;
using System.Security.Claims;

namespace ProjetDotnetM1Sopra20252026.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("seller")]
        [Authorize(Roles = "Seller")]
        public IActionResult SellerOnly()
        {
            return Ok("Ok, you're a seller");
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Administrator")]
        public IActionResult AdminOnly()
        {
            return Ok("Ok, you're an administrator");
        }

        [HttpGet("authenticated")]
        [Authorize]
        public IActionResult AuthenticatedOnly()
        {
            return Ok("Ok, you're authenticated (seller or administrator)");
        }

        [HttpGet("everyone")]
        [AllowAnonymous]
        public IActionResult Everyone()
        {
            return Ok("No need to be proud, everyone can access this page.");
        }


        private UserModel GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity != null && identity.IsAuthenticated)
            {
                var userClaims = identity.Claims;

                return new UserModel
                {
                    Username = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.NameIdentifier)?.Value,
                    EmailAddress = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Email)?.Value,
                    Role = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Role)?.Value,
                    Surname = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.Surname)?.Value,
                    GivenName = userClaims.FirstOrDefault(o => o.Type == ClaimTypes.GivenName)?.Value,
                };
            }
            return null;
        }
    }
}
