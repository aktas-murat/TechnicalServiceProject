using TechnicalServiceProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechnicalServiceProject.Models.Identity;
using TechnicalServiceProject.Models.Role;
using TechnicalServiceProject.ViewModels;

namespace TechnicalServiceProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            CheckRoles();
        }
        private void CheckRoles()
        {
            foreach (var item in Roles.RoleList)
            {
                if (_roleManager.RoleExistsAsync(item).Result)
                    continue;
                var result = _roleManager.CreateAsync(new ApplicationRole()
                {
                    Name = item
                }).Result;
            }
        }
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            var model = new LoginViewModel()
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, true);

            if (result.Succeeded)
            {
                var user = _userManager.FindByNameAsync(model.UserName).Result;
                HttpContext.Session.SetString("User", System.Text.Json.JsonSerializer.Serialize(new
                {
                    user.Name,
                    user.Surname,
                    user.Email
                }));
                model.ReturnUrl ??= Url.Content("~/");

                return LocalRedirect(model.ReturnUrl);
            }
            else if (result.IsLockedOut)
            {

            }
            else if (result.RequiresTwoFactor)
            {

            }

            ModelState.AddModelError(string.Empty, "Username or password is incorrect");
            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Bir hata oluştu");
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                //Rol Atama
                var count = _userManager.Users.Count();
                result = await _userManager.AddToRoleAsync(user, count == 1 ? Roles.Admin : Roles.Passive);

                //Email gönderme - Aktivasyon
                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code },
                //    protocol: Request.Scheme);

                //var email = new MailModel()
                //{
                //    To = new List<EmailModel>
                //{
                //    new EmailModel()
                //        { Adress = user.Email, Name = user.UserName }
                //},
                //    Body =
                //        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.",
                //    Subject = "Confirm your email"
                //};

                //await _emailService.SendMailAsync(email);
                //TODO: Login olma
                return RedirectToAction("Login");
            }

            var messages = string.Join("<br>", result.Errors.Select(x => x.Description));
            ModelState.AddModelError(string.Empty, messages);
            return View(model);
        }

    }
}
