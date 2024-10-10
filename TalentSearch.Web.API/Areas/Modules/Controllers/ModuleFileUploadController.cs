using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;
using TalentSearch.Core.Modules;
using TalentSearch.Core.Parameters;
using TalentSearch.Core.Results;
using TalentSearch.Core.Templates;
using TalentSearch.Web.API.Models.DBContexts;


namespace TalentSearch.Web.API.Areas.Modules.Controllers
{
	[ApiExplorerSettings(GroupName = "Modules")]
	[Area("Modules")]
	[Route("api/[Area]/[controller]/[action]")]
	[ApiController]
	[EnableCors("AllowOrigin")]
	public class ModuleFileUploadController : Controller
	{
		private readonly IConfiguration _iConfiguration;
		private readonly DWDbContext _db;
		private readonly ApplicationDbContext _dbA;
		private readonly IHttpContextAccessor _httpContextAccessor;
		//private readonly IEmailService _emailService;
		//private readonly IConfigEmailRepository _configEmailRepository;

		public ModuleFileUploadController(
			DWDbContext db,
			ApplicationDbContext dbA,
			IConfiguration iConfiguration
			//IConfigEmailRepository configEmailRepository
			)
		{
			_db = db;
			_dbA = dbA;
			_iConfiguration = iConfiguration;
			//_httpContextAccessor = httpContextAccessor;
			//_emailService = emailService;
			//_configEmailRepository = configEmailRepository;
		}

        //[HttpPost]
        //public async Task<JsonResultAPI> AddFile(String File, String NewFileName)
        //{
        //          JsonResultAPI _Value = new JsonResultAPI();
        //          bool _Success = false;
        //          string _Message = string.Empty;
        //          try
        //          {


        //          }
        //          catch (Exception ex)
        //          {
        //              _Success = false;
        //              _Message = ex.Message;
        //          }

        //          _Value.Success = _Success;
        //          _Value.Message = _Message;

        //          return _Value;
        //      }

        [HttpPost]
        public async Task<JsonResultAPI> AddFile([FromBody] FileUpload _FileUploadParameter)
        {
			JsonResultAPI _Value = new JsonResultAPI();
			bool _Success = false;
			string _Message = string.Empty;
			try
			{
                Guid _NewGuid = Guid.NewGuid();
                //Console.WriteLine(JsonConvert.SerializeObject(_FileUploadParameter)); // Log the parameter

                //Add File
                ModuleFileUpload _arg1 = new ModuleFileUpload();
                _arg1.id = _NewGuid;
                _arg1.filename = _FileUploadParameter.filename;
                _arg1.type = _FileUploadParameter.type;
                _arg1.size = _FileUploadParameter.size;
                _arg1.url_link = _FileUploadParameter.url_link;
                //_arg1.created_by = _FileUploadParameter.created_by;
                _arg1.created = DateTime.UtcNow;

                // Adding the new instance to the DbSet in the DbContext
                _dbA.ModuleFileUploads.Add(_arg1);
                await _dbA.SaveChangesAsync();
				_Success = true;
                //return Ok(value: new JsonResultAPI { Success = true, Message = "File uploaded successfully." });
            }
            catch (Exception ex)
			{
				_Success = false;
				_Message = ex.Message;
                // Log the exception (or set a breakpoint here to inspect the exception)
                //Console.WriteLine(ex.ToString());
            }

			_Value.Success = _Success;
			_Value.Message = _Message;

			return _Value;
		}
	}
}
