using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentSearch.Core.Modules
{
	[Table("ModulePerson")]
	public class ModulePerson
    {
        [Key]
        public Guid Id { get; set; }
        public String FullName { get; set; }
        public String? PhoneNumber { get; set; }
        public String? NRICNoNew { get; set; }
        public String? NRICNoOld { get; set; }
        public String? PassportNo { get; set; }
        public String? OtherIDNo { get; set; }

        //public String UserRoleName; //{ get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public String Email { get; set; }
        public Boolean Active { get; set; }
		public DateTime? Created { get; set; }

		[StringLength(128)]
		public string CreatedBy { get; set; }
		public DateTime? Modified { get; set; }

		[StringLength(128)]
		public string? ModifiedBy { get; set; }
	}
}
