using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TalentSearchWeb.Controllers;
using TalentSearch.Web.API.Models.DBContexts;
using TalentSearch.Core.Modules;
using System.Net.Http.Headers;
using TalentSearch.Web.Models.Configurations;
using Newtonsoft.Json;
using System.Text;
using TalentSearch.Core.Results;
using TalentSearch.Core.Configurations;
using TalentSearch.Core.Parameters;

public class FileUploadController : Controller
{
    private readonly IWebHostEnvironment _webHost;
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _configuration;
    //private readonly ApplicationDbContext _context;


    public FileUploadController(IWebHostEnvironment webHost, ILogger<HomeController> logger, IConfiguration configuration)//, ApplicationDbContext context)
    {
        _webHost = webHost;
        _logger = logger;
        _configuration = configuration;
        //_context = context;
    }

    [Route("Internal/File/Upload")]
    [HttpGet]
    public IActionResult FileUpload()
    {
        return View();
    }

    [Route("Internal/File/Upload")]
    [HttpPost]
    public async Task<IActionResult> FileUpload(IFormFile file)//, [Bind("memo_id,filename,type,size,url_link")] FileUpload _FileUploadParameter)
    {
        if (file == null || file.Length == 0)
        {
            // Setting a message to be displayed in the view
            ViewBag.Message = "No file selected for upload.";
            return View();
        }

        string uploadsFolder = Path.Combine(_webHost.WebRootPath, "FileUploads");

            try
            {
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(file.FileName);
                string fileSavePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                using (var _Client = new HttpClient())
                {
                    _Client.BaseAddress = new Uri(_configuration["WebAPI:IntegrationAPI"].ToString());
                    _Client.DefaultRequestHeaders.Accept.Clear();
                    _Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                FileUpload _FileUploadParameter = new FileUpload
                {
                    filename = file.FileName,
                    memo_id = Guid.NewGuid().ToString(),
                    size = file.Length.ToString(),
                    type = file.ContentType.ToString(),
                    url_link = fileSavePath
                };
                
                    //POST Method
                    HttpResponseMessage _Response = await _Client.PostAsync(URIConfiguration._Memo_AddNew,
                        new StringContent(JsonConvert.SerializeObject(new
                        {
                            memo_id = _FileUploadParameter.memo_id,
                            filename = _FileUploadParameter.filename,
                            type = _FileUploadParameter.type,
                            size = _FileUploadParameter.size,
                            url_link = _FileUploadParameter.url_link,
                            //created_by = _FileUploadParameter.created_by,
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
                ViewBag.Message = "File uploaded successfully.";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading file");
                ViewBag.Message = "File upload failed. Please try again.";
            }
        return View();
    }
}
