using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TalentSearch.Core.Datawarehouse;
using TalentSearch.Core.Datawarehouse.Results;
using TalentSearch.Core.Parameters;
using TalentSearch.Core.Results;
using TalentSearch.Core.Templates;
using TalentSearch.Web.API.Models.DBContexts;
using TalentSearch.Web.API.Models.Repositories;

namespace TalentSearch.Web.API.Areas.Datawarehouse.Controllers
{
	[ApiExplorerSettings(GroupName = "Configurations")]
	[Area("Configurations")]
	[Route("api/[Area]/[controller]/[action]")]
	[ApiController]
	[EnableCors("AllowOrigin")]
	public class ConfigurationsController : ControllerBase
	{
		private readonly IConfiguration _iConfiguration;
        private readonly DWDbContext _db;
        private readonly ApplicationDbContext _dbA;
        private readonly IHttpContextAccessor _httpContextAccessor;
		//private readonly IEmailService _emailService;
		//private readonly IConfigEmailRepository _configEmailRepository;

		public ConfigurationsController(
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

		[HttpPost]
		public async Task<JsonResultAPI> GetScholarById([FromBody] Email _parameter)
		{
			JsonResultAPI _Value = new JsonResultAPI();
            bool _Success = false;
            string _Message = string.Empty;
            try
            {
				ConfigEmailRepository _CER = new ConfigEmailRepository(_iConfiguration, _dbA);
				_Value.Result = _CER.SendEmail(_parameter);
				_Value.Total = 1;
				_Success = true;
			}
			catch (Exception ex)
			{
				_Success = false;
				_Message = ex.Message;
			}

			_Value.Success = _Success;
			_Value.Message = _Message;

			return _Value;
		}
	}
}
