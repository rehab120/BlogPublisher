using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.Context;
using WebApplication1.Models.Entites;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManger;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly BlogDbContext context;

        //inject
        public AccountController( BlogDbContext context,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManger = userManager;
            this.signInManager = signInManager;
            this.context = context;


        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                //mapping for Vm to model 
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = newUserVM.UserName;
                userModel.Address = newUserVM.Address;
                userModel.PasswordHash = newUserVM.Password;
                //Save db
                IdentityResult result = await userManger.CreateAsync(userModel ,newUserVM.Password);
                if (result.Succeeded)
                {
                   await userManger.AddToRoleAsync(userModel, "User");
                    //create cookies
                    await signInManager.SignInAsync(userModel,false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("password", item.Description);
                    }

                }

            }
            return View(newUserVM);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                //check db
                ApplicationUser userModel = await userManger.FindByNameAsync(userVM.UserName);
                if (userModel != null)
                {
                    bool found = await userManger.CheckPasswordAsync(userModel, userVM.Password);
                    if (found)
                    {
                        //cookie
                        await signInManager.SignInAsync(userModel, userVM.RememberMe);
                        return RedirectToAction("Index", "Home");

                    }

                }
                ModelState.AddModelError("", "User name or Password Wrong");
            }
            return View(userVM);
        }
        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult AddAdmin()
        {

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAdmin(RegisterUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                //mapping for Vm to model 
                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = newUserVM.UserName;
                userModel.Address = newUserVM.Address;
                userModel.PasswordHash = newUserVM.Password;
                //Save db
                IdentityResult result = await userManger.CreateAsync(userModel, newUserVM.Password);
                if (result.Succeeded)
                {
                    await userManger.AddToRoleAsync(userModel, "Admin");
                    //create cookies
                    await signInManager.SignInAsync(userModel, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("password", item.Description);
                    }

                }

            }

            return View(newUserVM);
        }


        [HttpGet]
        public IActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddAuthor(AuthorViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                //mapping for Vm to model 
                Author author = new Author();
                author.Address = newUserVM.Address;
                author.Name= newUserVM.Name;
                author.EmailAddress = newUserVM.EmailAddress;
                author.BirthDate = newUserVM.BirthDate;
                author.Gender = newUserVM.Gender;
                author.Salary = newUserVM.Salary;

                ApplicationUser userModel = new ApplicationUser();
                userModel.UserName = newUserVM.Name;
                userModel.Address = newUserVM.Address;
                userModel.Email = newUserVM.EmailAddress;
                userModel.PasswordHash = newUserVM.Password;

                //Save db
                IdentityResult result = await userManger.CreateAsync(userModel, newUserVM.Password);
                if (result.Succeeded)
                {
                    await userManger.AddToRoleAsync(userModel, "Author");

                    context.Authors.Add(author);  
                    await context.SaveChangesAsync();
                    //create cookies
                    await signInManager.SignInAsync(userModel, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("password", item.Description);
                    }

                }

            }

            return View(newUserVM);
        }

    }
}
