
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentSearch.Core.Modules
{
    [Table("ModuleMemoUpload")]
    public class ModuleFileUpload
    {
        [Key]
        public Guid id { get; set; }
        public Guid memo_id { get; set; }    
        public string filename { get; set; }
        public string type { get; set; }
        public string size { get; set; }
        public string url_link { get; set; }
        public DateTime created { get; set; }
        public string created_by { get; set; }
        public DateTime updated { get; set; }
        public string updated_by { get; set; }
        public DateTime deleted { get; set; }
        public string deleted_by { get; set; }
    }
}