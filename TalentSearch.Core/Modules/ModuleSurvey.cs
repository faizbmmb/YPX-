using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentSearch.Core.Modules
{
	[Table("ModuleSurvey")]
	public class ModuleSurvey
	{
		[Key]
		public Guid Id { get; set; }

		[StringLength(250)]
		public string? Fullname { get; set; }

		[StringLength(50)]
		public string? IdentityNo { get; set; }

		[StringLength(50)]
		public string? PhoneNo { get; set; }

		[StringLength(250)]
		public string? Email { get; set; }

		public bool? Q1 { get; set; }

		public bool? Q2 { get; set; }

		public string? Q3 { get; set; }

		public string? Q4 { get; set; }

		public string? Q5 { get; set; }

		public string? Q6 { get; set; }

		public string? Q7 { get; set; }

		public string? Q8 { get; set; }
		public string? Q8_1 { get; set; }

		public string? Q9 { get; set; }
		
		public string? Q10 { get; set; }

		public bool? Q11_1 { get; set; }
		
		public string? Q11_1R { get; set; }

		[Column(TypeName = "text")]
		public string? Q11_1RT { get; set; }

		public bool? Q11_2 { get; set; }
		
		public string? Q11_2R { get; set; }

		[Column(TypeName = "text")]
		public string? Q11_2RT { get; set; }

		public bool? Q11_3 { get; set; }
		
		public string? Q11_3R { get; set; }

		[Column(TypeName = "text")]
		public string? Q11_3RT { get; set; }

		public bool? Q12_1 { get; set; }
		
		[Column(TypeName = "text")]
		public string? Q12_1R { get; set; }
		
		public bool? Q12_2 { get; set; }
		
		[Column(TypeName = "text")]
		public string? Q12_2R { get; set; }
		
		public bool? Q12_3 { get; set; }
		
		[Column(TypeName = "text")]
		public string? Q12_3R { get; set; }
		
		public bool? Q12_4 { get; set; }
		
		[Column(TypeName = "text")]
		public string? Q12_4R { get; set; }
		
		public bool? Q12_5 { get; set; }
		
		[Column(TypeName = "text")]
		public string? Q12_5R { get; set; }
		
		public bool? Q12_6 { get; set; }
		
		[Column(TypeName = "text")]
		public string? Q12_6R { get; set; }
		
		public string? Q13 { get; set; }
		
		public string? Q14 { get; set; }
		
		public string? Q15 { get; set; }
		
		public string? Q16 { get; set; }
		
		public string? Q17 { get; set; }
		
		public DateTime? Created { get; set; }
	}
}
