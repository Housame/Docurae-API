using DocuraeAPI.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocuraeAPI.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;
        public LoginRepository(
            ApplicationDbContext context,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            Microsoft.Extensions.Configuration.IConfiguration config)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _config = config;
        }
        //public string SetNewUserAsync()
        //{
        //    return ("bachla");
        //}
        public async Task SetNewUserAsync()
        {
            #region Create user
            var user = new ApplicationUser() { UserName = "Hannibal", Email = "housam.oueslati@hotmail.com " };
            var result = await _userManager.CreateAsync(user, "Ou22986879"); 
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            string errorData = "";
            foreach (var error in result.Errors)
            {
                errorData += error.Description + '\n';
            }
            var e = errorData;
            //await _userManager.SetEmailAsync(user, "housam.oueslati@hotmail.com");

            //await _userManager.SetPhoneNumberAsync(user, "0737781619");

            //string password = "Ou22986879";
            //await _userManager.AddPasswordAsync(user, password);

            //var result = await _userManager.CreateAsync(user);

            //await _userManager.AddToRoleAsync(user, "Client");

            //var confirm = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            #endregion        

            var userHashId = await _userManager.GetUserIdAsync(user);
            CreateUser(userHashId);
            //throw new NotImplementedException();
        }
        internal void CreateUser(string userHashId)
        {
            var userToCreate = new User
            {
                HashId = userHashId,
                FirstName = "Hannibal",
                LastName = "Barka",
                SocialNumber = "198912050336",
                JobTitle = "Vårdbiträde"
            };

            _context.User.Add(userToCreate);
            _context.SaveChanges();
        }
    }
}
