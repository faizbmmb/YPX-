using TalentSearch.Core.Datawarehouses;

namespace TalentSearch.Core.Datawarehouse
{
	public class tbl_datawarehouse
	{
		public int scholar_id { get; set; }
		public int? dcps_id { get; set; }
		public tbl_scholar tbl_Scholar { get; set; } = null;
		public tbl_dcps? tbl_dcps { get; set; } = null;

	}
}
