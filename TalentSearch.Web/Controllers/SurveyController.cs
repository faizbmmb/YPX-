using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using TalentSearch.Core.Modules;
using TalentSearchWeb.Models;
using TalentSearch.Core.Parameters;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TalentSearch.Core.Datawarehouse;
using TalentSearch.Core.Results;
using TalentSearch.Web.Models.Configurations;
using TalentSearchWeb.Controllers;

namespace TalentSearch.Web.Controllers
{
	public class SurveyController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IConfiguration _configuration;

		public SurveyController(ILogger<HomeController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
		}

		public IActionResult Index()
		{
			ViewBag.Message = "Your trusted Talent Bank";
			return View();
		}

		[HttpPost]
		
		public async Task<IActionResult> Survey([Bind("Fullname,Email,IdentityNo,PhoneNo,Q1,Q2,Q3,Q4,Q5,Q6,Q7,Q8,Q8_1,Q9,Q10,Q11_1,Q11_1R,Q11_1RT,Q11_2,Q11_2R,Q11_2RT,Q11_3,Q11_3R,Q11_3RT,Q12_1,Q12_1R,Q12_2,Q12_2R,Q12_3,Q12_3R,Q12_4,Q12_4R,Q12_5,Q12_5R,Q12_6,Q12_6R,Q13,Q14,Q15,Q16,Q17")] SurveyParameter _registration)
		//public async Task<IActionResult> Survey([Bind("Fullname,Email,IdentityNo,PhoneNo,Q1,Q2,Q3,Q4,Q5,Q6,Q7,Q8,Q9,Q10,Q11_1,Q11_1R,Q11_2,Q11_2R,Q11_3,Q11_3R,Q11_4,Q11_4R")] SurveyParameter _registration)
		{
			if (ModelState.IsValid)
			{
				try
				{
					using (var _Client = new HttpClient())
					{
						_Client.BaseAddress = new Uri(_configuration["WebAPI:IntegrationAPI"].ToString());
						_Client.DefaultRequestHeaders.Accept.Clear();
						_Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

						//POST Method
						HttpResponseMessage _Response = await _Client.PostAsync(URIConfiguration._Survey_AddNew,
							new StringContent(JsonConvert.SerializeObject(new
							{
								//Id = _registration.Id,
								Fullname = _registration.Fullname,
								Email = _registration.Email,
								IdentityNo = _registration.IdentityNo,
								PhoneNo = _registration.PhoneNo,
								Q1 = _registration.Q1,
								Q2 = _registration.Q2,
								Q3 = _registration.Q3,
								Q4 = _registration.Q4,
								Q5 = _registration.Q5,
								Q6 = _registration.Q6,
								Q7 = _registration.Q7,
								Q8 = _registration.Q8,
								Q8_1 = _registration.Q8_1,
								Q9 = _registration.Q9,
								Q10 = _registration.Q10,
								Q11_1 = _registration.Q11_1,
								Q11_1R = _registration.Q11_1R,
								Q11_1RT = _registration.Q11_1RT,
								Q11_2 = _registration.Q11_2,
								Q11_2R = _registration.Q11_2R,
								Q11_2RT = _registration.Q11_2RT,
								Q11_3 = _registration.Q11_3,
								Q11_3R = _registration.Q11_3R,
								Q11_3RT = _registration.Q11_3RT,
								//Q11_4 = _registration.Q11_4,
								//Q11_4R = _registration.Q11_4R
								Q12_1 = _registration.Q12_1,
								Q12_1R = _registration.Q12_1R,
								Q12_2 = _registration.Q12_2,
								Q12_2R = _registration.Q12_2R,
								Q12_3 = _registration.Q12_3,
								Q12_3R = _registration.Q12_3R,
								Q12_4 = _registration.Q12_4,
								Q12_4R = _registration.Q12_4R,
								Q12_5 = _registration.Q12_5,
								Q12_5R = _registration.Q12_5R,
								Q12_6 = _registration.Q12_6,
								Q12_6R = _registration.Q12_6R,
								Q13 = _registration.Q13,
								Q14 = _registration.Q14,
								Q15 = _registration.Q15,
								Q16 = _registration.Q16,
								Q17 = _registration.Q17,

							}), Encoding.UTF8, "application/json"));

						if (_Response.IsSuccessStatusCode)
						{
							var _Result = await _Response.Content.ReadAsStringAsync();
							if (_Result != null)
							{
								JsonResultAPI _Obj = JsonConvert.DeserializeObject<JsonResultAPI>(_Result);
								ViewBag.Success = _Obj.Success;
								ViewBag.Message = _Obj.Message;
							}
						}
					}

					//ModelState.Clear();
					

					ViewBag.Message = "Registration has been successfully completed";

					if (_registration.Q16 == "Sabah"){
						return RedirectToAction("StatusSabah", "Survey");

					}
					
					return RedirectToAction("Status", "Survey");
					//return RedirectToAction("Status", "Survey");
				}
				catch (Exception ex)
				{
					ViewBag.Message = "Sorry, looks like there are some errors detected, please try again.";
					return View();
				}
			}

			return View();
		}

		public IActionResult Status()
		{
			return View();
		}
		public IActionResult Survey()
		{
			return View();
		}
		public IActionResult StatusSabah()
		{
			return View();
		}
	}
}
