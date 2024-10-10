namespace TalentSearch.Core.Parameters
{
	public class ResetPassword
	{
		public String Email { get; set; }
		public String Token { get; set; }
		public String NewPassword { get; set; }
	}
}
