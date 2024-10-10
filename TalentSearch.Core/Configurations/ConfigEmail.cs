using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TalentSearch.Core.Configurations
{
	[Table("ConfigEmail")]
	public class ConfigEmail
    {
        public Guid Id { get; set; }

        [StringLength(250)]
        public string Host { get; set; }

        [StringLength(250)]
        public string Domain { get; set; }

        [StringLength(250)]
        public string UserName { get; set; }

        [StringLength(250)]
        public string Password { get; set; }

        public int? Port { get; set; }

        public bool EnableSSL { get; set; }

        [StringLength(250)]
        public string Sender { get; set; }

        public bool Active { get; set; }

        public DateTime? Created { get; set; }

        [StringLength(128)]
        public string CreatedBy { get; set; }

        public DateTime? Modified { get; set; }

        [StringLength(128)]
        public string ModifiedBy { get; set; }

       
    }
}
