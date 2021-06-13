using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PasswordHashedLoginWebApp.Models;

namespace PasswordHashedLoginWebApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignUp(SignUpVM model)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    User user = new User();
                    user.EmailId = model.EmailId;
                    user.Salt = Crypto.GenerateSalt();

                    var passworAndSalt = model.Password + user.Salt;
                    user.PasswordHash = Crypto.HashPassword(passworAndSalt);

                    dbContext.Users.Add(user);
                    await dbContext.SaveChangesAsync();
                }
                return RedirectToAction("index", "home");
            }
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    User user = dbContext.Users.Where(u => u.EmailId == model.EmailId).FirstOrDefault();

                    var passworAndSalt = model.Password + user.Salt;

                    if (user != null && Crypto.VerifyHashedPassword(user.PasswordHash, passworAndSalt))
                    {
                        return RedirectToAction("contact", "home");
                    }
                    else
                    {
                        ModelState.AddModelError("loginerror", "Inavlid Username or Passoword");
                    }

                }
            }
            return View(model);
        }
    }
}