using Microsoft.AspNetCore.Mvc;

namespace TalentSearchWeb.Controllers
{
	public class AccountController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
