using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TalentSearch.Core.Modules;

namespace TalentSearch.Core.Configurations
{
	[Table("AspNetUsers")]
    public partial class AspNetUser
    {
        [Key]
        [StringLength(128)]
        public String Id { get; set; }
        public String UserName { get; set; }
        public String NormalizedUserName { get; set; }
        public String Email { get; set; }
        public String NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public String PasswordHash { get; set; }
        public String SecurityStamp { get; set; }
        public String ConcurrencyStamp { get; set; }
        public String? PhoneNumber { get; set; }
        public bool? PhoneNumberConfirmed { get; set; }
        public bool? TwoFactorEnabled { get; set; }
		public DateTime? LockoutEnd { get; set; }
		public bool LockoutEnabled { get; set; }
        public int? AccessFailedCount { get; set; }
        public Guid? ModulePersonId { get; set; }
        //public String ThumbnailPicture { get; set; }
        public bool Active { get; set; }
        public Guid? Token { get; set; }
        public String? JWTToken { get; set; }
		public DateTime? Created { get; set; }

		[StringLength(128)]
		public string? CreatedBy { get; set; }
		public DateTime? Modified { get; set; }

		[StringLength(128)]
		public string? ModifiedBy { get; set; }

        //public DateTime? RefreshTokenExpiryTime { get; set; }

        //Custom Attributes
        public virtual ModulePerson ModulePerson { get; set; }
		public virtual ICollection<AspNetRoles> AspNetRoles { get; set; }

	}
}
