using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LearningPortal.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName) { }

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
      
            public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CourseLearning> CourseLearnings { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<SectionMedia> SectionMedia { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<SubCategories> SubCategories { get; set; }

        public virtual DbSet<UserMediaHistory> UserMediaHistories { get; set; }
        public virtual DbSet<CourseTag> CourseTag { get; set; }
        public virtual DbSet<TagManager> TagManager { get; set; }

        public System.Data.Entity.DbSet<LearningPortal.Models.RoleViewModel> RoleViewModels { get; set; }
    }
}