namespace TalentSearch.Core.Datawarehouse.Results
{
    public class UpdateEmailMemoStatusRequest
    {
        public string NRIC { get; set; }
        public string ProgrammeName { get; set; }
        public string CostCode { get; set; }
        public string MemoId { get; set; }
        public string UserDisplayName { get; set; }
    }
}
