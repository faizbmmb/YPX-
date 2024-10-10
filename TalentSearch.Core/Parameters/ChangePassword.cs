using System.ComponentModel.DataAnnotations;

namespace TalentSearch.Core.Parameters
{
	public class ChangePassword
	{
		[Required]
		[EmailAddress]
		public String Email { get; set; }

		[Required]
		public String CurrentPassword { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public String NewPassword { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Compare("NewPassword")]
		public String RetypePassword { get; set; }
	}
}
