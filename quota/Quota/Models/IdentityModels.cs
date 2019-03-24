using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using Core.Globalization;

namespace DoE.Quota.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            userIdentity.AddClaim(new Claim(GlobalConstants.CLAIM_NAME, string.IsNullOrEmpty(this.C_Name) ? " " : this.C_Name));

            userIdentity.AddClaim(new Claim(GlobalConstants.CLAIM_FIRSTNAME, string.IsNullOrEmpty(this.C_FirstName) ? " " : this.C_FirstName));

            userIdentity.AddClaim(new Claim(GlobalConstants.CLAIM_SURNAME, string.IsNullOrEmpty(this.C_Surname) ? " " : this.C_Surname));

            userIdentity.AddClaim(new Claim(GlobalConstants.CLAIM_SUBID, string.IsNullOrEmpty(this.C_SubId) ? " " : this.C_SubId));

            userIdentity.AddClaim(new Claim(GlobalConstants.CLAIM_ENTITY, string.IsNullOrEmpty(this.C_Entity) ? " " : this.C_Entity));

            return userIdentity;
        }

        public string C_Name            { get; set; }
        public string C_FirstName       { get; set; }
        public string C_Surname         { get; set; }
        public string C_SubId           { get; set; }
        public string C_Entity          { get; set; }
    
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}