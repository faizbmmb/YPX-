using System.ComponentModel.DataAnnotations;

namespace TalentSearch.Core.Parameters
{
	public class Credential
	{
		public String Email { get; set; }
		public String Password { get; set; }
	}

	public class DetailsId
	{
		public String _Id { get; set; }
	}

	public class MemoId
	{
		public Guid _Id { get; set; }
	}

	public class Email
	{
		public string _Email { get; set; }
	}

	public class RecoveryEmailParameter
	{
		[Required]
		[Display(Name = "Full Name")]
		public string Fullname { get; set; }
		[Required]
		[Display(Name = "Number Identification")]
		public string NRIC { get; set; }
		[Required]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string Email { get; set; }
		[Required]
		[Display(Name = "LOD")]
		public string LOD { get; set; }
		[Required]
		[Display(Name = "Link")]
		public string Link { get; set; }
	}

	public class SurveyParameter
	{
		//public Guid Id { get; set; }
		[Required]
		[Display(Name = "Full Name")]
		public string Fullname { get; set; }
		[Required]
		[EmailAddress(ErrorMessage = "Invalid Email Address")]
		public string Email { get; set; }
		[Required]
		[Display(Name = "Identity No")]
		public string IdentityNo { get; set; }
		[Required]
		[Display(Name = "Phone No")]
		public string PhoneNo { get; set; }

		//Survey
		public string? Q1 { get; set; }

		public string? Q2 { get; set; }

		public string? Q3 { get; set; }

		public string? Q4 { get; set; }

		public string? Q5 { get; set; }

		public string? Q6 { get; set; }

		public string? Q7 { get; set; }

		public string? Q8 { get; set; }

		public string? Q8_1 { get; set; }

		public string? Q9 { get; set; }

		public string? Q10 { get; set; }

		public string? Q11_1 { get; set; }

		public string? Q11_1R { get; set; }

		public string? Q11_1RT { get; set; }

		public string? Q11_2 { get; set; }

		public string? Q11_2R { get; set; }

		public string? Q11_2RT { get; set; }

		public string? Q11_3 { get; set; }

		public string? Q11_3R { get; set; }

		public string? Q11_3RT { get; set; }
		public string? Q12_1 { get; set; }
		public string? Q12_1R { get; set; }
		public string? Q12_2 { get; set; }
		public string? Q12_2R { get; set; }
		public string? Q12_3 { get; set; }
		public string? Q12_3R { get; set; }
		public string? Q12_4 { get; set; }
		public string? Q12_4R { get; set; }
		public string? Q12_5 { get; set; }
		public string? Q12_5R { get; set; }
		public string? Q12_6 { get; set; }
		public string? Q12_6R { get; set; }
		public string? Q13 { get; set; }
		public string? Q14 { get; set; }
		public string? Q15 { get; set; }
		public string? Q16 { get; set; }
		public string? Q17 { get; set; }


	}
}
