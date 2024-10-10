using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
	public class ModuleSurveysController : Controller
	{
		private readonly IConfiguration _iConfiguration;
		private readonly DWDbContext _db;
		private readonly ApplicationDbContext _dbA;
		private readonly IHttpContextAccessor _httpContextAccessor;
		//private readonly IEmailService _emailService;
		//private readonly IConfigEmailRepository _configEmailRepository;

		public ModuleSurveysController(
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
		public async Task<JsonResultAPI> AddSurvey([FromBody] SurveyParameter _SurveyParameter)
		{
			JsonResultAPI _Value = new JsonResultAPI();
			bool _Success = false;
			string _Message = string.Empty;
			try
			{
				Guid _NewGuid = Guid.NewGuid();

				ModuleSurvey _arg1 = new ModuleSurvey();
				_arg1.Id = _NewGuid;
                _arg1.Fullname = _SurveyParameter.Fullname;
                _arg1.Email = _SurveyParameter.Email;
                _arg1.IdentityNo = _SurveyParameter.IdentityNo;
                _arg1.PhoneNo = _SurveyParameter.PhoneNo;
                _arg1.Q1 = (_SurveyParameter.Q1 != null && _SurveyParameter.Q1.Equals("Yes", StringComparison.OrdinalIgnoreCase)) ? true : false;
				_arg1.Q2 = (_SurveyParameter.Q2 != null && _SurveyParameter.Q2.Equals("Yes", StringComparison.OrdinalIgnoreCase)) ? true : false;
				_arg1.Q3 = _SurveyParameter.Q3;
				_arg1.Q4 = _SurveyParameter.Q4;
				_arg1.Q5 = _SurveyParameter.Q5;
				_arg1.Q6 = _SurveyParameter.Q6;
				_arg1.Q7 = _SurveyParameter.Q7;
				_arg1.Q8 = _SurveyParameter.Q8;
				_arg1.Q8_1 = _SurveyParameter.Q8_1;
				_arg1.Q9 = _SurveyParameter.Q9;
				_arg1.Q10 = _SurveyParameter.Q10;
				_arg1.Q11_1 = (_SurveyParameter.Q11_1 != null && _SurveyParameter.Q11_1.Equals("Yes", StringComparison.OrdinalIgnoreCase)) ? true : false;
				_arg1.Q11_1R = _SurveyParameter.Q11_1R;
				_arg1.Q11_1RT = _SurveyParameter.Q11_1RT;
				_arg1.Q11_2 = (_SurveyParameter.Q11_2 != null && _SurveyParameter.Q11_2.Equals("Yes", StringComparison.OrdinalIgnoreCase)) ? true : false;
				_arg1.Q11_2R = _SurveyParameter.Q11_2R;
				_arg1.Q11_2RT = _SurveyParameter.Q11_2RT;
				_arg1.Q11_3 = (_SurveyParameter.Q11_3 != null && _SurveyParameter.Q11_3.Equals("Yes", StringComparison.OrdinalIgnoreCase)) ? true : false;
				_arg1.Q11_3R = _SurveyParameter.Q11_3R;
				_arg1.Q11_3RT = _SurveyParameter.Q11_3RT;
				_arg1.Q12_1 = (_SurveyParameter.Q12_1 != null && _SurveyParameter.Q12_1.Equals("Yes", StringComparison.OrdinalIgnoreCase)) ? true : false;
				_arg1.Q12_1R = _SurveyParameter.Q12_1R;
				_arg1.Q12_2 = (_SurveyParameter.Q12_2 != null && _SurveyParameter.Q12_2.Equals("Yes", StringComparison.OrdinalIgnoreCase)) ? true : false;
				_arg1.Q12_2R = _SurveyParameter.Q12_2R;
				_arg1.Q12_3 = (_SurveyParameter.Q12_3 != null && _SurveyParameter.Q12_3.Equals("Yes", StringComparison.OrdinalIgnoreCase)) ? true : false;
				_arg1.Q12_3R = _SurveyParameter.Q12_3R;
				_arg1.Q12_4 = (_SurveyParameter.Q12_4 != null && _SurveyParameter.Q12_4.Equals("Yes", StringComparison.OrdinalIgnoreCase)) ? true : false;
				_arg1.Q12_4R = _SurveyParameter.Q12_4R;
				_arg1.Q12_5 = (_SurveyParameter.Q12_5 != null && _SurveyParameter.Q12_5.Equals("Yes", StringComparison.OrdinalIgnoreCase)) ? true : false;
				_arg1.Q12_5R = _SurveyParameter.Q12_5R;
				_arg1.Q12_6 = (_SurveyParameter.Q12_6 != null && _SurveyParameter.Q12_6.Equals("Yes", StringComparison.OrdinalIgnoreCase)) ? true : false;
				_arg1.Q12_6R = _SurveyParameter.Q12_6R;
				_arg1.Q13 = _SurveyParameter.Q13;
				_arg1.Q14 = _SurveyParameter.Q14;
				_arg1.Q15 = _SurveyParameter.Q15;
				_arg1.Q16 = _SurveyParameter.Q16;
				_arg1.Q17 = _SurveyParameter.Q17;
				_arg1.Created = DateTime.UtcNow;

                _dbA.ModuleSurveys.Add(_arg1);
				await _dbA.SaveChangesAsync();
				
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
