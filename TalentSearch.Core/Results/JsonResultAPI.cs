using System.Runtime.Serialization;

namespace TalentSearch.Core.Results
{
	[DataContract]
    public class JsonResultAPI
    {
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public int Total { get; set; }
        [DataMember]
        public object Result { get; set; }
    }
}
