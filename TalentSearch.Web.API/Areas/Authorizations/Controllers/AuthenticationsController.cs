using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TalentSearch.Core.Parameters;
using TalentSearch.Core.Results;
using TalentSearch.Web.API.Models.Configurations;
using TalentSearch.Web.API.Models.DBContexts;
using TalentSearch.Web.API.Models.Repositories;

namespace TalentSearch.Web.API.Areas.Authorizations.Controllers
{
	[ApiExplorerSettings(GroupName = "Authorizations")]
	[Area("Authorizations")]
	[Route("api/[Area]/[controller]/[action]")]
	[ApiController]
	[EnableCors("AllowOrigin")]
	public class AuthenticationsController : ControllerBase
	{
		private readonly IConfiguration _iConfiguration;
		private readonly ApplicationDbContext _db;
		private readonly SignInManager<ApplicationUser> _signManager;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<ApplicationRole> _roleManager;
		private readonly IHttpContextAccessor _httpContextAccessor;
		//private readonly IEmailService _emailService;
		//private readonly IConfigEmailRepository _configEmailRepository;

		public AuthenticationsController(
			ApplicationDbContext db,
			SignInManager<ApplicationUser> signManager,
			UserManager<ApplicationUser> userManager,
			RoleManager<ApplicationRole> roleManager,
			IConfiguration iConfiguration
			//IConfigEmailRepository configEmailRepository
			)
		{
			_db = db;
			_signManager = signManager;
			_userManager = userManager;
			_roleManager = roleManager;
			_iConfiguration = iConfiguration;
			//_httpContextAccessor = httpContextAccessor;
			//_emailService = emailService;
			//_configEmailRepository = configEmailRepository;
		}
		
		[HttpPost]
		public JsonResultAPI Seed()
		{
			JsonResultAPI _Value = new JsonResultAPI();
			bool _Success = false;
			string _Message = string.Empty;
			try
			{
				AuthenticationRepository _Repository = new AuthenticationRepository
					(_db, 
					_signManager,
					_userManager,
					_roleManager, 
					_iConfiguration//,
					//_configEmailRepository
					);
				_Repository.SeedData(_db, _userManager, _roleManager, ref _Message, ref _Success);
				if (_Value.Result != null)
				{
					_Value.Total = 1;
				}

				_Value.Success = _Success;
				_Value.Message = _Message;
			}
			catch (Exception ex)
			{
				_Value.Success = false;
				_Value.Message = ex.Message;
			}
			return _Value;
		}

		[HttpPost]
		public async Task<JsonResultAPI> SignIn([FromBody] Credential credential)
		{
			JsonResultAPI _Value = new JsonResultAPI();
			bool _Success = false;
			string _Message = string.Empty;
			try
			{
				AuthenticationRepository _Repository = new AuthenticationRepository(_db, _signManager, _userManager, _roleManager, _iConfiguration);//, _configEmailRepository);
				_Value.Result = _Repository.SignIn(credential, ref _Message, ref _Success);
				if (_Value.Result != null)
				{
					_Value.Total = 1;
				}
				_Value.Success = _Success;
				_Value.Message = _Message;
			}
			catch (Exception ex)
			{
				_Value.Success = false;
				_Value.Message = ex.Message;
			}

			return _Value;
		}

		[HttpPost]
		public async Task<JsonResultAPI> SignUp([FromBody] Credential credential)
		{
			JsonResultAPI _Value = new JsonResultAPI();
			bool _Success = false;
			string _Message = string.Empty;
			try
			{
				AuthenticationRepository _Repository = new AuthenticationRepository(_db, _signManager, _userManager, _roleManager, _iConfiguration);//, _configEmailRepository);
				_Value.Result = _Repository.SignIn(credential, ref _Message, ref _Success);
				if (_Value.Result != null)
				{
					_Value.Total = 1;
				}
				_Value.Success = _Success;
				_Value.Message = _Message;
			}
			catch (Exception ex)
			{
				_Value.Success = false;
				_Value.Message = ex.Message;
			}

			return _Value;
		}

		[HttpPost]
		public async Task<JsonResultAPI> ForgotPasswprd([FromBody] Credential credential)
		{
			JsonResultAPI _Value = new JsonResultAPI();
			bool _Success = false;
			string _Message = string.Empty;
			try
			{
				AuthenticationRepository _Repository = new AuthenticationRepository(_db, _signManager, _userManager, _roleManager, _iConfiguration);//, _configEmailRepository);
				_Value.Result = _Repository.SignIn(credential, ref _Message, ref _Success);
				if (_Value.Result != null)
				{
					_Value.Total = 1;
				}
				_Value.Success = _Success;
				_Value.Message = _Message;
			}
			catch (Exception ex)
			{
				_Value.Success = false;
				_Value.Message = ex.Message;
			}

			return _Value;
		}

		[HttpPost]
		public async Task<JsonResultAPI> ChangePassword([FromBody] Credential credential)
		{
			JsonResultAPI _Value = new JsonResultAPI();
			bool _Success = false;
			string _Message = string.Empty;
			try
			{
				AuthenticationRepository _Repository = new AuthenticationRepository(_db, _signManager, _userManager, _roleManager, _iConfiguration);//, _configEmailRepository);
				_Value.Result = _Repository.SignIn(credential, ref _Message, ref _Success);
				if (_Value.Result != null)
				{
					_Value.Total = 1;
				}
				_Value.Success = _Success;
				_Value.Message = _Message;
			}
			catch (Exception ex)
			{
				_Value.Success = false;
				_Value.Message = ex.Message;
			}

			return _Value;
		}
	}
}
