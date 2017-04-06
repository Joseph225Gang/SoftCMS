using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
<<<<<<< HEAD
=======
using System.ComponentModel.DataAnnotations;
>>>>>>> 8b99a5b61aa279f7828a8dfe0e8aaee4969c2f89

namespace SoftCMS.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string NickName { get; set; }
        public byte[] PhotoImage { get; set; }
<<<<<<< HEAD
=======
        [RegularExpression(@"image/(jpeg|png|gif)$",ErrorMessage ="結尾必須是jpg,png和gif檔")]
>>>>>>> 8b99a5b61aa279f7828a8dfe0e8aaee4969c2f89
        public string PhotoImageType { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
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
<<<<<<< HEAD
=======

        //public System.Data.Entity.DbSet<SoftCMS.Models.ApplicationUser> ApplicationUsers { get; set; }
>>>>>>> 8b99a5b61aa279f7828a8dfe0e8aaee4969c2f89
    }
}