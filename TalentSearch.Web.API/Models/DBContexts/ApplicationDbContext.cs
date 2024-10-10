using Microsoft.EntityFrameworkCore;
using TalentSearch.Core.Modules;
using TalentSearch.Core.Configurations;

namespace TalentSearch.Web.API.Models.DBContexts
{
    public class ApplicationDbContext : DbContext
    {
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ 
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

		///Configuration
		public DbSet<AspNetRoles> AspNetRoles { get; set; }
        public DbSet<AspNetUser> AspNetUsers { get; set; }
        public DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public DbSet<ConfigEmail> ConfigEmail { get; set; }

        //Module
        public DbSet<ModulePerson> ModulePersons { get; set; }
		public DbSet<ModuleSurvey> ModuleSurveys { get; set; }
        public DbSet<ModuleFileUpload> ModuleFileUploads { get; set; }
		public DbSet<ModuleMemo> ModuleMemo { get; set; }
		public DbSet<ModuleLetterIssuance> ModuleLetterIssuance { get; set; }
		public DbSet<ConfigMemoStatus> ConfigMemoStatus { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //config primary key(Role, User,UserRole)
            builder.Entity<AspNetUser>().HasKey(s => s.Id);
            builder.Entity<AspNetRoles>().HasKey(s => s.Id);
            builder.Entity<AspNetUserRole>().HasKey(s =>
               new
               {
                   s.UserId,
                   s.RoleId
               });

            // Relationships table User,Role,UserRole
            //builder.Entity<AspNetUserRole>()
            //  .HasOne<AspNetUser>(sc => sc.AspNetUser)
            //  .WithMany(s => s.AspNetUserRoles)
            //  .HasForeignKey(sc => sc.UserId);

            //builder.Entity<AspNetUserRole>()
            //    .HasOne<AspNetRoles>(sc => sc.AspNetRoles)
            //    .WithMany(s => s.AspNetUserRoles)
            //    .HasForeignKey(sc => sc.RoleId);
        }
    }
}
