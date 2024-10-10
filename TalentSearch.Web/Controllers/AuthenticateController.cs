using Microsoft.AspNetCore.Mvc;

namespace TalentSearchWeb.Controllers
{
    public class AuthenticateController : Controller
    {
		public IActionResult SignUp()
		{
			return View();
		}
		public IActionResult ForgotPassword()
		{
			return View();
		}
	}
}
