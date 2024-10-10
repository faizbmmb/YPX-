using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TalentSearch.Core.Configurations;
using TalentSearch.Core.Results;
using TalentSearch.Web.Models.Configurations;

namespace TalentSearchWeb.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IConfiguration _configuration;

		public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(string email, string password)
		{
			ViewBag.Success = string.Empty;
			ViewBag.Message = string.Empty;

			try
			{
				using (var _Client = new HttpClient())
				{
					_Client.BaseAddress = new Uri(_configuration["WebAPI:IntegrationAPI"].ToString());//new Uri("http://localhost:5090/");
					_Client.DefaultRequestHeaders.Accept.Clear();
					_Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					//POST Method
					HttpResponseMessage _Response = await _Client.PostAsync(URIConfiguration._SignIn,
						new StringContent(JsonConvert.SerializeObject(new
						{
							Email = email,
							Password = password
						}), Encoding.UTF8, "application/json"));

					if (_Response.IsSuccessStatusCode)
					{
						var _Result = await _Response.Content.ReadAsStringAsync();
						if (_Result != null)
						{
							JsonResultAPI _Obj = JsonConvert.DeserializeObject<JsonResultAPI>(_Result);
							ViewBag.Success = _Obj.Success;
							ViewBag.Message = _Obj.Message;

							if (_Obj.Result != null)
							{
								AspNetUser _Data = JsonConvert.DeserializeObject<AspNetUser>(_Obj.Result.ToString());

								LoginSession _LS = new LoginSession(HttpContext.Session);
								LoginSession.UserID = _Data.Id;
								LoginSession.UserName = _Data.UserName;
								LoginSession.UserDisplayName = _Data.ModulePerson.FullName;
								LoginSession.UserIdentity = _Data.ModulePerson.NRICNoNew;
								LoginSession.UserEmail = _Data.Email;

								foreach (var item in _Data.AspNetRoles)
								{
									LoginSession.UserRole += item.Name + "|";
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				ViewBag.Success = false;
				ViewBag.Message = ex.Message;
			}

			// if(LoginSession.UserRole.Contains("Administrator")) return RedirectToAction("ScholarIndex", "Internal");
			if (LoginSession.UserRole.Contains("Administrator")) return RedirectToAction("Index", "Recovery");
			else if (LoginSession.UserRole.Contains("Scholar")) return RedirectToAction("Index", "Scholar");
			else if (LoginSession.UserRole.Contains("Recovery")) return RedirectToAction("Index", "Recovery");
			else if (LoginSession.UserRole.Contains("Finance")) return RedirectToAction("Index", "Recovery");

			return View();
		}

		public IActionResult Status()
		{
			return View();
		}
	}
}
