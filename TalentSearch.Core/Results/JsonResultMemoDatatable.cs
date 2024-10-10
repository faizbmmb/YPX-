﻿using System.Runtime.Serialization;
using TalentSearch.Core.Datawarehouse.Results;

namespace TalentSearch.Core.Results
{
	[DataContract]
	public class JsonResultMemoDatatable
	{
		[DataMember]
		public int draw { get; set; }
		[DataMember]
		public int recordsTotal { get; set; }
		[DataMember]
		public int recordsFiltered { get; set; }
		[DataMember]
		public List<MemoDatatable> data { get; set; }
	}
}
