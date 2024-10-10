using Microsoft.AspNet.Identity;
using System.Net.Mail;
using System.Net.Security;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using TalentSearch.Core.Configurations;
using TalentSearch.Web.API.Models.DBContexts;
using TalentSearch.Core.Templates;
using TalentSearch.Core.Parameters;

namespace TalentSearch.Web.API.Models.Repositories
{
	public class ConfigEmailRepository
	{
		private readonly IConfiguration _iConfiguration;
		private readonly ApplicationDbContext _db;

		public ConfigEmailRepository(IConfiguration iConfiguration, ApplicationDbContext db)
		{
			_iConfiguration = iConfiguration;
			_db = db;
		}

		public async Task<(string message, bool success, ConfigEmail data)> SendEmail(Email _Parameter)
		{
			ConfigEmail _Value = null;
			string Content = "";
			string _Message = string.Empty;
			bool _Success = false;

			try
			{
				_Value = (from a in _db.ConfigEmail select a).ToList().FirstOrDefault();

				if (_Value != null)
				{
					//Email to target
					var smtpClient = new SmtpClient(_Value.Host)
					{
						Port = 587,
						Credentials = new NetworkCredential(_Value.UserName, _Value.Password),
						EnableSsl = true,
					};

					var mailMessage = new MailMessage
					{
						From = new MailAddress(_Value.Sender),
						Subject = "Congratulations! Welcome to YP Talent Bank",
						Body = EmailTemplate.EmailActivation(),
						IsBodyHtml = true,
					};
					mailMessage.IsBodyHtml = true;
					mailMessage.To.Add(_Parameter._Email);
					//mailMessage.Bcc.Add("helme.yusop@yayasanpeneraju.com.my");
					//mailMessage.Bcc.Add("ahmad.zahari@yayasanpeneraju.com.my");
					//mailMessage.Bcc.Add("rose.adzreen@yayasanpeneraju.com.my");

					smtpClient.Send(mailMessage);
					smtpClient.Dispose();
				}

				_Success = true;
			}
			catch (Exception ex)
			{
				_Success = false;
				_Message = ex.Message;
			}

			return (_Message, _Success, _Value);
		}

		private static bool CertificateValidationCallBack(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}
	}
}
