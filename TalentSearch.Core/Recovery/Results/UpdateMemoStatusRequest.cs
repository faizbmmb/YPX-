namespace TalentSearch.Core.Datawarehouse.Results
{
    public class UpdateMemoStatusRequest
    {
        public string MemoId { get; set; }
        public string Status { get; set; }
        public string Flag { get; set; }
        public string UserName { get; set; }
    }
}
