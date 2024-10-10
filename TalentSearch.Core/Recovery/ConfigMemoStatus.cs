using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentSearch.Core.Modules
{
	[Table("ConfigMemoStatus")]
	public class ConfigMemoStatus
    {
        [Key]
        public Guid id { get; set; }
        public String? title { get; set; }
        public String? description { get; set; }
        public String? abbreviation { get; set; }
        
	}
}
