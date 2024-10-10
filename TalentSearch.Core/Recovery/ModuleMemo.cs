using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentSearch.Core.Modules
{
	[Table("ModuleMemo")]
	public class ModuleMemo
    {
        [Key]
        public Guid id { get; set; }
        public String? memo_no { get; set; }
        public String? title { get; set; }
        public String? description { get; set; }
        public Guid? memostatusid { get; set; }
        public DateOnly? letter_issuance_date { get; set; }
		public DateTime? reviewed { get; set; }
		public string? reviewed_by { get; set; }
		public DateTime? approved { get; set; }
		public string? approved_by { get; set; }
		public DateTime? memo_approved { get; set; }
		public string? memo_approved_by { get; set; }
		public DateTime? issued { get; set; }
		public string? issued_by { get; set; }
        
	}
}
