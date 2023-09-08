using AltTab.Identity;
using AltTab.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AltTab.Controllers
{
	public class AccountController : Controller
	{
		private UserManager<ApplicationUser> _userManager;
		private RoleManager<ApplicationRole> _roleManager;
		public AccountController()
		{
			var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
			_userManager = new UserManager<ApplicationUser>(userStore);

			var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
			_roleManager = new RoleManager<ApplicationRole>(roleStore);
		}
		// GET: Account
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Register(Register model)
		{
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser();
				user.Name = model.Name;
				user.Surname = model.Surname;
				user.UserName = model.Username;
				user.Email = model.Email;
				var result = _userManager.Create(user, model.Password);
				if (result.Succeeded)
				{
					if (_roleManager.RoleExists("user"))
					{
						_userManager.AddToRole(user.Id, "user");
					}
					return RedirectToAction("Login", "Account");
				}
				else
				{
					ModelState.AddModelError("Hata", "Kullanıcı oluşturma hatası");
				}
			}
			return View(model);
		}
		public ActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Login(Login login, string ReturnUrl)
		{
			if (ModelState.IsValid)
			{
				var user = _userManager.Find(login.Username, login.Password);
				if (user != null)
				{
					var authManager = HttpContext.GetOwinContext().Authentication;
					var identityClaims = _userManager.CreateIdentity(user, "ApplicationCookie");
					var authProperties = new AuthenticationProperties();
					authProperties.IsPersistent = login.RememberMe;
					authManager.SignIn(authProperties, identityClaims);
					if (ReturnUrl == null)
					{
						return RedirectToAction("Index", "Home");
					}
					else
					{
						Redirect(ReturnUrl);
					}
				}
				else
				{
					ModelState.AddModelError("Hata", "Böyle Bir Kullanıcı Yok!!!");
				}
			}
			return View(login);
		}
		public ActionResult Logout()
		{
			var authManager = HttpContext.GetOwinContext().Authentication;
			authManager.SignOut();
			return RedirectToAction("Index", "Home");
		}
		//Get
		public ActionResult Profil()
		{
			var id = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();
			var user = _userManager.FindById(id);
			var data = new ProfilGuncelle()
			{
				Id = id,
				Name = user.Name,
				Surname = user.Surname,
				Mail = user.Email,
				Username = user.UserName
			};
			return View(data);
		}
		[HttpPost]
		public ActionResult Profil(ProfilGuncelle model)
		{
			var user = _userManager.FindById(model.Id);
			user.Name = model.Name;
			user.Surname = model.Surname;
			user.Email = model.Mail;
			user.UserName = model.Username;
			_userManager.Update(user);
			return View("Update");
		}
		public ActionResult ChangePassword()
		{
			return View();
		}
		[HttpPost]
		[Authorize]
		public ActionResult ChangePasswords(PasswordChange model)
		{
			if (ModelState.IsValid)
			{
				var user = _userManager.ChangePassword(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
				return View("Update");
			}
			return View(model);
		}
	}
}