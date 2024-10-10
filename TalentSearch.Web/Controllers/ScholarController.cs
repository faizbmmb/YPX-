using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using TalentSearch.Core.Datawarehouse;
using TalentSearch.Core.Results;
using TalentSearch.Web.Models.Configurations;

namespace TalentSearchWeb.Controllers
{
	public class ScholarController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IConfiguration _configuration;

		public ScholarController(ILogger<HomeController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
		}

		public async Task<IActionResult> Index()
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
							_id = LoginSession.UserIdentity
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
        public async Task<IActionResult> Programme()
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
                            _id = LoginSession.UserIdentity
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
		public async Task<IActionResult> Certification()
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
							_id = LoginSession.UserIdentity
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

		public async Task<IActionResult> Employment()
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
							_id = LoginSession.UserIdentity
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
		public async Task<IActionResult> Education()
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
							_id = LoginSession.UserIdentity
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
