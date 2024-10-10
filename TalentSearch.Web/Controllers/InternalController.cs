using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TalentSearch.Core.Datawarehouse;
using TalentSearch.Core.Results;
using TalentSearch.Web.Models.Configurations;

namespace TalentSearchWeb.Controllers
{
	public class InternalController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IConfiguration _configuration;

		public InternalController(ILogger<HomeController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
		}

		[Route("Internal/Scholar/List")]
		public IActionResult ScholarIndex()
		{
			return View();
		}

		[Route("Internal/Scholar/Details/Overview")]
		public async Task<IActionResult> ScholarOverview(string Id)
		{
			ViewBag.Success = string.Empty;
			ViewBag.Message = string.Empty;

			try
			{
				using (var _Client = new HttpClient())
				{
					_Client.BaseAddress = new Uri(_configuration["WebAPI:IntegrationAPI"].ToString());
					_Client.DefaultRequestHeaders.Accept.Clear();
					_Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					//POST Method
					HttpResponseMessage _Response = await _Client.PostAsync(URIConfiguration._Scholar_GetById,
						new StringContent(JsonConvert.SerializeObject(new
						{
							_id = Id
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
								tbl_datawarehouse _DataDW = JsonConvert.DeserializeObject<tbl_datawarehouse>(_Obj.Result.ToString());
								ViewData["UserProfileDetail"] = _DataDW;
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

			return View();
		}

		[Route("Internal/Scholar/Details/Programme")]
		public async Task<IActionResult> ScholarProgramme(string Id)
		{
			ViewBag.Success = string.Empty;
			ViewBag.Message = string.Empty;

			try
			{
				using (var _Client = new HttpClient())
				{
					_Client.BaseAddress = new Uri(_configuration["WebAPI:IntegrationAPI"].ToString());
					_Client.DefaultRequestHeaders.Accept.Clear();
					_Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					//POST Method
					HttpResponseMessage _Response = await _Client.PostAsync(URIConfiguration._Scholar_GetById,
						new StringContent(JsonConvert.SerializeObject(new
						{
							_id = Id
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
								tbl_datawarehouse _DataDW = JsonConvert.DeserializeObject<tbl_datawarehouse>(_Obj.Result.ToString());
								ViewData["UserProfileDetail"] = _DataDW;
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

			return View();
		}

		[Route("Internal/Scholar/Details/Certification")]
		public async Task<IActionResult> ScholarCertification(string Id)
		{
			ViewBag.Success = string.Empty;
			ViewBag.Message = string.Empty;

			try
			{
				using (var _Client = new HttpClient())
				{
					_Client.BaseAddress = new Uri(_configuration["WebAPI:IntegrationAPI"].ToString());
					_Client.DefaultRequestHeaders.Accept.Clear();
					_Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					//POST Method
					HttpResponseMessage _Response = await _Client.PostAsync(URIConfiguration._Scholar_GetById,
						new StringContent(JsonConvert.SerializeObject(new
						{
							_id = Id
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
								tbl_datawarehouse _DataDW = JsonConvert.DeserializeObject<tbl_datawarehouse>(_Obj.Result.ToString());
								ViewData["UserProfileDetail"] = _DataDW;
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

			return View();
		}

		[Route("Internal/Scholar/Details/Employment")]
		public async Task<IActionResult> ScholarEmployment(string Id)
		{
			ViewBag.Success = string.Empty;
			ViewBag.Message = string.Empty;

			try
			{
				using (var _Client = new HttpClient())
				{
					_Client.BaseAddress = new Uri(_configuration["WebAPI:IntegrationAPI"].ToString());
					_Client.DefaultRequestHeaders.Accept.Clear();
					_Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					//POST Method
					HttpResponseMessage _Response = await _Client.PostAsync(URIConfiguration._Scholar_GetById,
						new StringContent(JsonConvert.SerializeObject(new
						{
							_id = Id
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
								tbl_datawarehouse _DataDW = JsonConvert.DeserializeObject<tbl_datawarehouse>(_Obj.Result.ToString());
								ViewData["UserProfileDetail"] = _DataDW;
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

			return View();
		}

		[Route("Internal/Scholar/Details/Education")]
		public async Task<IActionResult> ScholarEducation(string Id)
		{
			ViewBag.Success = string.Empty;
			ViewBag.Message = string.Empty;

			try
			{
				using (var _Client = new HttpClient())
				{
					_Client.BaseAddress = new Uri(_configuration["WebAPI:IntegrationAPI"].ToString());
					_Client.DefaultRequestHeaders.Accept.Clear();
					_Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

					//POST Method
					HttpResponseMessage _Response = await _Client.PostAsync(URIConfiguration._Scholar_GetById,
						new StringContent(JsonConvert.SerializeObject(new
						{
							_id = Id
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
								tbl_datawarehouse _DataDW = JsonConvert.DeserializeObject<tbl_datawarehouse>(_Obj.Result.ToString());
								ViewData["UserProfileDetail"] = _DataDW;
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

			return View();
		}
	}
}
