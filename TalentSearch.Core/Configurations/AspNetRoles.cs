using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentSearch.Core.Configurations
{
	[Table("AspNetRoles")]
    public partial class AspNetRoles 
    {
        [Key]
        [StringLength(128)]
        public String Id { get; set; }
        public String Name { get; set; }
        //public String NormalizedName { get; set; }
        public String? ConcurrencyStamp { get; set; }
        //public String Description { get; set; }
        //public Boolean Active { get; set; }
        //public String Abbreviation { get; set; }

        //[StringLength(128)]
        //public string ModifiedBy { get; set; }
        //public DateTime? Modified { get; set; }
		//public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
	}
}
