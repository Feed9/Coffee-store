using Coffee_store.Data;
using Coffee_store.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coffee_store.Controllers
{
    public class UserAuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public UserAuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, Data.ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(UserLoginModel model)
        {
            model.LoginInValid = "true";
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    model.LoginInValid = "";
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login attempt");
                }
            }
            return PartialView("_UserLoginPartial", model);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut(string? url = null)
        {
            await _signInManager.SignOutAsync();
            if (url != null)
            {
                return LocalRedirect(url);
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistrationModel model)
        {
            model.RegistrationInValid = "true";
            if (ModelState.IsValid)
            {

                ApplicationUser user = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,                    
                    PhoneNumber = model.PhoneNumber
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    model.RegistrationInValid = "";
                    await _signInManager.SignInAsync(user, isPersistent: false);
                }
                else
                {
                    AddExistedErrorsToModelState(result);
                }
            }
            return PartialView("_UserRegistrationPartial", model);
        }
        [AllowAnonymous]
        public async Task<bool> UserExists(string? userName)
        {
            if(userName == null)
            {
                return false;
            }
            bool isExists = await _context.Users.AnyAsync(user => user.UserName.ToUpper() == userName.ToUpper());
            return isExists;
        }
        public void  AddExistedErrorsToModelState(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
