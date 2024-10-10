using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentSearch.Core.Parameters
{
    public class FileUpload
    {
        [Required]
        public string memo_id { get; set; }
        public string filename { get; set; }
        public string type { get; set; }
        public string size { get; set; }
        public string url_link { get; set; }
        //public string created_by { get; set; }
    }
}
