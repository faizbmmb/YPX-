using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using TalentSearch.Core.Configurations;
using TalentSearch.Core.Datawarehouse.Results;
using TalentSearch.Core.Datawarehouse;
using TalentSearch.Core.Results;
using TalentSearch.Core.Parameters;
using TalentSearch.Web.Models.Configurations;
using TalentSearch.Core.Recovery.View;

namespace TalentSearchWeb.Controllers
{
    public class RecoveryController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public RecoveryController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        } 

        [Route("Recovery/Memo/Details")]
        public IActionResult MemoIndex(string id)
        {
            return View();
        }

        [Route("Recovery/Memo/Details/View")]
        public async Task<IActionResult> MemoIndexView(string id)
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
					HttpResponseMessage _Response = await _Client.PostAsync(URIConfiguration._Scholar_GetByNRIC,
						new StringContent(JsonConvert.SerializeObject(new
						{
							_id = id
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
								issuance_letter _Data = JsonConvert.DeserializeObject<issuance_letter>(_Obj.Result.ToString());
								ViewData["UserProfileDetail"] = _Data;
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

        [HttpPost]
        public async Task<JsonResultAPI> GetMemoStatus(string memo_id)
        {
            JsonResultAPI return_result = new JsonResultAPI();
            try
            {
                using (var _Client = new HttpClient())
                {
                    _Client.BaseAddress = new Uri(_configuration["WebAPI:IntegrationAPI"].ToString());
                    _Client.DefaultRequestHeaders.Accept.Clear();
                    _Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage _Response = await _Client.PostAsync(URIConfiguration._Recovery_GetMemoStatus,
                        new StringContent(JsonConvert.SerializeObject(new
                        {
                            _Id = memo_id

                        }), Encoding.UTF8, "application/json"));

                    if (_Response.IsSuccessStatusCode)
                    {
                        var _Result = await _Response.Content.ReadAsStringAsync();
                        if (_Result != null)
                        {
                            return_result = JsonConvert.DeserializeObject<JsonResultAPI>(_Result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return_result.Success = false;
                return_result.Message = ex.Message;
            }

            return return_result;
        }

        [HttpPost]
        public async Task<JsonResultAPI> UpdateMemoStatus([FromBody] UpdateMemoStatusRequest request)
        {
            JsonResultAPI return_result = new JsonResultAPI();
            try
            {
                using (var _Client = new HttpClient())
                {
                    _Client.BaseAddress = new Uri(_configuration["WebAPI:IntegrationAPI"].ToString());
                    _Client.DefaultRequestHeaders.Accept.Clear();
                    _Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage _Response = await _Client.PostAsync(URIConfiguration._Recovery_UpdateMemoStatus,
                        new StringContent(JsonConvert.SerializeObject(new
                        {
                            request.MemoId,
                            request.Status,
                            request.Flag,
                            UserName = LoginSession.UserName,

                        }), Encoding.UTF8, "application/json"));

                    if (_Response.IsSuccessStatusCode)
                    {
                        var _Result = await _Response.Content.ReadAsStringAsync();
                        if (_Result != null)
                        {
                            return_result = JsonConvert.DeserializeObject<JsonResultAPI>(_Result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return_result.Success = false;
                return_result.Message = ex.Message;
            }

            return return_result;
        }

        [HttpPost]
        public async Task<JsonResultAPI> SendEmailtoScholar([FromBody] RecoveryEmailParameter request)
        {
            JsonResultAPI return_result = new JsonResultAPI();
            try
            {
                using (var _Client = new HttpClient())
                {
                    _Client.BaseAddress = new Uri(_configuration["WebAPI:IntegrationAPI"].ToString());
                    _Client.DefaultRequestHeaders.Accept.Clear();
                    _Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage _Response = await _Client.PostAsync(URIConfiguration._Recovery_SendEmailtoScholar,
                        new StringContent(JsonConvert.SerializeObject(new
                        {
                            Fullname = request.Fullname,
                            NRIC = request.NRIC,
                            Email = request.Email,
                            Link = request.Link,

                        }), Encoding.UTF8, "application/json"));

                    if (_Response.IsSuccessStatusCode)
                    {
                        var _Result = await _Response.Content.ReadAsStringAsync();
                        if (_Result != null)
                        {
                            return_result = JsonConvert.DeserializeObject<JsonResultAPI>(_Result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return_result.Success = false;
                return_result.Message = ex.Message;
            }

            return return_result;
        }

    }
}
