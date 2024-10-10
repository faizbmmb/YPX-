namespace TalentSearch.Core.Datawarehouse.Results
{
	public class MemoDatatable
	{

		public Guid? id { get; set; }
		public string? memo_no { get; set; } = string.Empty;
		public string? title { get; set; } = string.Empty;
		public string? description { get; set; } = string.Empty;
		public string? memostatusid { get; set; }
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
