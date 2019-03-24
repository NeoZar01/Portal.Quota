using System;
using System.Linq;
using System.Threading.Tasks;

using System.Web;
using System.Web.Mvc;
using System.Web.Caching;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

using Core.Globalization;

namespace DoE.Quota.Web.Controllers
{
    using Api;
    using Models;
    using Repositories.Services.Contracts;

    using Core.Exceptions;
    using Core.Repositories.BusinessInterOps.Models;
    using Core.Web.Utilities.Common;

    [Authorize]
    public class AccountController : BaseController
    {

        #region [CONSTRUCTOR]

        private IUserServices _userService;

        public AccountController()
        : this(new UserService(new ServerRepository()), new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext())), null)
        {
            context = new ApplicationDbContext();
        }

        public AccountController(IUserService userService, ApplicationUserManager userManager,  ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            _userService = userService;
        }

        #endregion
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {

            if (!ModelState.IsValid)
            {
                ModelState.ModelState.AddModelError(ExceptionConstants.GetAttributes(ExceptionConstants.INVALID_CREDENTIALS_FAIL).Category , ExceptionConstants.GetAttributes(ExceptionConstants.INVALID_CREDENTIALS_FAIL).Description);
                return View(model);
            } 

            TSAuthenticationToken authentication;

            string signIn =  await Task.FromResult(_userService.SignIn(model.UserName, model.Password, out authentication));

            if(!signIn.Equals(GlobalConstants.SUCCESSFULL) || authentication == null)
            {
                if(authentication.Exception.Equals(ExceptionConstants.INVALID_CREDENTIALS_FAIL, StringComparison.CurrentCultureIgnoreCase))
                {
                    ModelState.ModelState.AddModelError(ExceptionConstants.GetAttributes(ExceptionConstants.INVALID_CREDENTIALS_FAIL).Category, ExceptionConstants.GetAttributes(ExceptionConstants.INVALID_CREDENTIALS_FAIL).Description);
                }
                return View(model);
            }

            if(authentication.GroupPolicy != null)
               model.Cache.Add(CacheKeys.GROUP_POLICY, authentication.GroupPolicy, null, DateTime.Now.AddHours(CacheKeys.GROUP_POLICY_LIFESPAN), Cache.NoSlidingExpiration, CacheItemPriority.High, null);


            return RedirectToAction("Index", "Home");
        }        

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Administrators")]
        public ActionResult Impersonate()
        {
            return View();
        }

        //
        //POST /Account/Impersonate
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrators")]
        [Authorize(Roles = "EmisOfficers")]
        public async Task<ActionResult> ImpersonateUser([Bind(Include = "username")] ImpersonateViewModel model)
        {

            if (ModelState.IsValid && UserManager != null)
            {
                var userName = User.Identity.GetUserName();
                var imposter = model.UserName;

                var status = await SignInManager.ImpersonationSignInAsync(userName, imposter, UserManager, System.Web.HttpContext.Current);

                if (status == SignInStatus.Success)
                    return RedirectToAction("Index", "Home");
                return RedirectToAction("Impersonate", "Account");

            }
            throw new ArgumentNullException(nameof(model));
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }



        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        #endregion

    }
}