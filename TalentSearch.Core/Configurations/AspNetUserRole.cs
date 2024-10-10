using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentSearch.Core.Configurations
{
	[Table("AspNetUserRoles")]
    public class AspNetUserRole
    {
		[Key]
		[Column(Order = 0)]
		public string UserId { get; set; }

		[Key]
		[Column(Order = 1)]
		public string RoleId { get; set; }
     
    }
}
