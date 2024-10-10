using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentSearch.Core.Modules
{
	[Table("ModuleLetterIssuance")]
	public class ModuleLetterIssuance
    {
        [Key]
        public string ref_issuance_no { get; set; }
        public Guid? memo_id { get; set; }
		public string? scholar_nric { get; set; }
		public string? programme_name { get; set; }
		public string? cost_code { get; set; }
		public DateTime? issuanced { get; set; }
		public String? issuanced_by { get; set; }
		public String? email_status { get; set; }
        
	}
}
