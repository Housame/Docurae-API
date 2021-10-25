using DocuraeAPI.Models;
using DocuraeAPI.Models.Entities;
using DocuraeAPI.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DocuraeAPI.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Route("client/{clientId}/login/")]
    [Route("client/login/")]
    public class LoginController : Controller
    {
        private readonly ILoginRepository _repository;

        public LoginController(ILoginRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        //[Route("setnewuser")]
        public async Task<IActionResult> RegisterUser()
        {
            var e = 10;
            var b = e;
            Console.Write(e + b);
            await _repository.SetNewUserAsync();
            return Ok("hello world");


            //return Ok();
        }
        //private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly Microsoft.Extensions.Configuration.IConfiguration _config;
        //private readonly ApplicationDbContext _context;


        //public LoginController(SignInManager<ApplicationUser> signInManager,
        //                        UserManager<ApplicationUser> userManager,
        //                        RoleManager<IdentityRole> roleManager,
        //                        Microsoft.Extensions.Configuration.IConfiguration config,
        //                        ApplicationDbContext context)
        //{
        //    _signInManager = signInManager;
        //    _userManager = userManager;
        //    _roleManager = roleManager;
        //    _config = config;
        //    _context = context;
        //}

        //[HttpPost]
        //[Route("token")]
        //public async Task<IActionResult> CreateToken([FromBody] LogInDTO login)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {

        //            var userId = _context.AspNetUsers.FirstOrDefault(u => u.UserName == login.UserName)?.Id;
        //            var user = await _userManager.FindByIdAsync(userId);
        //            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
        //            if (result.Succeeded)
        //            {
        //                var claims = new List<Claim>
        //            {
        //                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
        //                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
        //            };
        //                var userClaims = await _userManager.GetClaimsAsync(user);
        //                var userRoles = await _userManager.GetRolesAsync(user);
        //                claims.AddRange(userClaims);
        //                foreach (var userRole in userRoles)
        //                {
        //                    claims.Add(new Claim(ClaimTypes.Role, userRole));
        //                    var role = await _roleManager.FindByNameAsync(userRole);
        //                    if (role != null)
        //                    {
        //                        var roleClaims = await _roleManager.GetClaimsAsync(role);
        //                        foreach (Claim roleClaim in roleClaims)
        //                        {
        //                            claims.Add(roleClaim);
        //                        }
        //                    }
        //                }
        //                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
        //                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //                var utcNow = DateTime.UtcNow;
        //                var token = new JwtSecurityToken(
        //                    _config["Tokens:Issuer"],
        //                    _config["Tokens:Audience"],
        //                    claims,
        //                    expires: utcNow.AddMinutes(20),
        //                    signingCredentials: creds);
        //                var results = new
        //                {
        //                    token = new JwtSecurityTokenHandler().WriteToken(token),
        //                    expiration = (int)(token.ValidTo - utcNow).TotalMilliseconds
        //                };
        //                return Created("", results);
        //            }

        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e);
        //            throw;
        //        }

        //    }

        //    return BadRequest();
        //}

        ////[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[HttpPost]
        //[Route("refresh")]
        //public async Task<IActionResult> RefreshToken([FromBody] RefreshDTO refresh)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var userId = _userManager.GetUserId(User);
        //        var userId2 = _context.AspNetUsers.FirstOrDefault(u => u.UserName == refresh.UserName)?.Id;

        //        if (userId != userId2) return BadRequest();

        //        var user = await _userManager.FindByIdAsync(userId);

        //        var claims = new List<Claim>
        //        {
        //            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
        //        };
        //        var userClaims = await _userManager.GetClaimsAsync(user);
        //        var userRoles = await _userManager.GetRolesAsync(user);
        //        claims.AddRange(userClaims);
        //        foreach (var userRole in userRoles)
        //        {
        //            claims.Add(new Claim(ClaimTypes.Role, userRole));
        //            var role = await _roleManager.FindByNameAsync(userRole);
        //            if (role != null)
        //            {
        //                var roleClaims = await _roleManager.GetClaimsAsync(role);
        //                foreach (var roleClaim in roleClaims)
        //                {
        //                    claims.Add(roleClaim);
        //                }
        //            }
        //        }
        //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
        //        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        //        var utcNow = DateTime.UtcNow;
        //        var token = new JwtSecurityToken(
        //            _config["Tokens:Issuer"],
        //            _config["Tokens:Audience"],
        //            claims,
        //            expires: utcNow.AddMinutes(20),
        //            signingCredentials: creds);
        //        var results = new
        //        {
        //            token = new JwtSecurityTokenHandler().WriteToken(token),
        //            expiration = (int)(token.ValidTo - utcNow).TotalMilliseconds
        //        };
        //        return Created("", results);
        //    }

        //    return BadRequest();
        //}


    }
}
