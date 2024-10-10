using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentSearch.Core.Datawarehouses
{
	[Table("tbl_dcps")]
	public class tbl_dcps
    {
		[Key]
		public int id { get; set; }
        public string? sch_name { get; set; } = string.Empty;
        public string? sch_nric_new { get; set; } = string.Empty;
        public DateOnly? pv_date { get; set; } = null;
        public string? pv_num { get; set; } = string.Empty;
        public string? payable_to { get; set; } = string.Empty;
        public string? inv_num { get; set; } = string.Empty;
        public DateOnly? inv_date { get; set; } = null;
        public string? description { get; set; } = string.Empty;
        public string? job { get; set; } = string.Empty;
        public float? amt_w_gst { get; set; } = null;
        public float? gst_amt { get; set; } = null;
        public float? tot_amt { get; set; } = null;
        public string? exp_cat { get; set; } = string.Empty;
    }
}
