using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentSearch.Core.Recovery.View
{
	[Table("issuance_letter")]
	public class issuance_letter
    {
        [Key]
        public String? scholar_name { get; set; }
        public String? scholar_nric { get; set; }
        public String? address_1 { get; set; }
        public String? address_2 { get; set; }
        public String? address_3 { get; set; }
        public String? postcode { get; set; }
        public String? city { get; set; }
        public String? state { get; set; }
        public String? cost_code { get; set; }
        public String? email { get; set; }
        public String? programme_name { get; set; }
        public double? total { get; set; }
        public double? ra_amount { get; set; }
        public double? nra_amount { get; set; }
        public String? status { get; set; }
        public int? lod_issued_percentage { get; set; }
        public double? lod_amount { get; set; }
        public String? unique_id { get; set; }
        
	}
}
