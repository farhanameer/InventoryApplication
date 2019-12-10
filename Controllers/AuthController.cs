using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using InventoryApplication.ContractRepos;
using InventoryApplication.Entities;
using InventoryApplication.HelperModels.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace InventoryApplication.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILocation _location;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AuthController(IConfiguration config,UserManager<User> userManager, 
            SignInManager<User> signInManager,
            ILocation location,IMapper mapper,
            IHttpContextAccessor httpContextAccessor) 
        {
            _config = config;
            _userManager =userManager;
            _signInManager = signInManager;
            _location = location;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("login",Name ="login")]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var user = await _userManager.FindByNameAsync(login.userName);
            if (user==null)
            {
                return Unauthorized();
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user,login.Password,false);
            if (result.Succeeded)
            {
                return Ok(new { 
                    token=await GenerateTokens(user),
                    user=user
                });
            }
            return Unauthorized();
        }

        [HttpGet("userid")]
        [Authorize]
        public IActionResult UserID()
        {
            
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userName = User.FindFirstValue(ClaimTypes.Name);
                return Ok(new { 
                    id=userId,
                    nam=userName
                });
            
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(Register register)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity();
            }
            var location = _mapper.Map<Location>(register);
            if (await _location.AddLocation(location))
            {
                var user = _mapper.Map<User>(register);
                user.LocationID = location.LocationID;
                var result = await _userManager.CreateAsync(user, register.Password);
                
                if (result.Succeeded)
                {
                    return StatusCode(201);
                }
                var error = result.Errors.Select(x => x.Description);
                return Conflict(error);
            }
            return BadRequest();
        }

        private async  Task<string> GenerateTokens(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim(ClaimTypes.Name,user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role,role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = cred
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}