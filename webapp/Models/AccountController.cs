using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace webapp.Models
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager)
        {

            userManager = _userManager;
            signInManager = _signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public async Task<IActionResult> Register(RegisterUserModel NewUserVM)
        {
            //create acount
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = NewUserVM.UserName;
                user.Email = NewUserVM.Email;
                IdentityResult result = await userManager.CreateAsync(user, NewUserVM.Password);
                if (result.Succeeded == true)

                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Login", "Account");

                }
                else
                {
                    foreach (var item in result.Errors) { ModelState.AddModelError("", item.Description); }


                }
            }
            return View(NewUserVM);
        }
        [HttpGet]
        public IActionResult Login() { return View(); }
        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public async Task<IActionResult> Login(LoginUserModel userVm)
        {
            if (ModelState.IsValid)
            {

                ApplicationUser usermodel = await userManager.FindByNameAsync(userVm.UserName);
                if (usermodel != null)
                {

                    bool found = await userManager.CheckPasswordAsync(usermodel, userVm.Password);
                    if (found)
                    {

                        await signInManager.SignInAsync(usermodel, userVm.RememberMe);
                        return RedirectToAction("index", "home");

                    }
                }
                ModelState.AddModelError("", "UserName And Password InValid");

            }

            return View(userVm);
        }



        public async Task<IActionResult> logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }

}
