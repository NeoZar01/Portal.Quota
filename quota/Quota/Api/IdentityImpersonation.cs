using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace DoE.Quota.Web.Api
{
    public static class IdentityImpersonation
    {
        public async static Task<SignInStatus> ImpersonationSignInAsync(this ApplicationSignInManager signInManager, string impersonator, string impersonatee, ApplicationUserManager _userManager, HttpContext context)
        {

            try
            {
                var impersonatedUser = await _userManager.FindByNameAsync(impersonatee);

                //TODO :: Log the impersonation attempt.
                if(impersonatedUser != null)
                {
                    var impersonatedIdentity = await impersonatedUser.GenerateUserIdentityAsync(_userManager);
                        impersonatedIdentity.AddClaim(new Claim("UserImpersonation", "true"));
                        impersonatedIdentity.AddClaim(new Claim("impersonator", impersonator));

                    var authenticationManager = context.GetOwinContext().Authentication;
                        authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                        authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, impersonatedIdentity);
                    return SignInStatus.Success;

                }
                    return SignInStatus.Failure;
            }
            catch
            {
                    return SignInStatus.Failure;
            }
        }
    }
}