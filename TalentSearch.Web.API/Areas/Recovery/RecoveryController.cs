using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Net.Mail;
using TalentSearch.Core.Modules;
using TalentSearch.Core.Results;
using TalentSearch.Core.Templates;
using TalentSearch.Core.Parameters;
using Microsoft.EntityFrameworkCore;
using TalentSearch.Core.Recovery.View;
using TalentSearch.Core.Datawarehouse;
using TalentSearch.Core.Datawarehouse.Results;
using TalentSearch.Web.API.Models.DBContexts;

namespace TalentSearch.Web.API.Areas.Recovery.Controllers
{
	[ApiExplorerSettings(GroupName = "Recovery")]
	[Area("Recovery")]
	[Route("api/[Area]/[controller]/[action]")]
	[ApiController]
	[EnableCors("AllowOrigin")]
	public class RecoveryController : ControllerBase
	{
		private readonly IConfiguration _iConfiguration;
		private readonly DWDbContext _db;
		private readonly ApplicationDbContext _dbA;

		private readonly DCPSDbContext _dbDCPS;
		private readonly IHttpContextAccessor _httpContextAccessor;
		//private readonly IEmailService _emailService;
		//private readonly IConfigEmailRepository _configEmailRepository;

		public RecoveryController(
			DWDbContext db,
			ApplicationDbContext dbA,
			DCPSDbContext dbDCPS,
			IConfiguration iConfiguration,
			IHttpContextAccessor httpContextAccessor

			//IConfigEmailRepository configEmailRepository
			)
		{
			_db = db;
			_dbA = dbA;
			_dbDCPS = dbDCPS;
			_iConfiguration = iConfiguration;
			_httpContextAccessor = httpContextAccessor;
			//_emailService = emailService;
			//_configEmailRepository = configEmailRepository;
		}

		[HttpPost]
		public async Task<JsonResultMemoDatatable> GetMemoList()
		{
			JsonResultMemoDatatable _Value = new JsonResultMemoDatatable();
			bool _Success = false;
			string _Message = string.Empty;
			try
			{
				var _ObjResult = (from tblMM in _dbA.ModuleMemo
								  join tblCMS in _dbA.ConfigMemoStatus
								  on tblMM.memostatusid equals tblCMS.id
								  where tblCMS.title != "Inactive"
								  select new MemoDatatable()
								  {
									  id = tblMM.id,
									  memo_no = tblMM.memo_no,
									  title = tblMM.title,
									  description = tblMM.description,
									  memostatusid = tblCMS.abbreviation,
									  letter_issuance_date = tblMM.letter_issuance_date,
								  })
								.ToList();

				if (_ObjResult.Count > 0)
				{
					_Value.data = _ObjResult;
					_Value.draw = 1;
					_Value.recordsTotal = _ObjResult.Count;
					_Value.recordsFiltered = _ObjResult.Count;
					_Success = true;
				}
				else
				{
					_Success = false;
					_Message = "Record not found";
				}
			}
			catch (Exception ex)
			{
				_Success = false;
				_Message = ex.Message;
			}

			return _Value;
		}

		// [HttpPost]
		// public async Task<JsonResultMemoDatatable> GetMemoStatus([FromBody] MemoId _MemoId)
		// {
		// 	JsonResultMemoDatatable _Value = new JsonResultMemoDatatable();
		// 	bool _Success = false;
		// 	string _Message = string.Empty;
		// 	try
		// 	{
		// 		var _ObjResult = (from tblMM in _dbA.ModuleMemo
		// 						  join tblCMS in _dbA.ConfigMemoStatus
		// 						  on tblMM.memostatusid equals tblCMS.id
		// 						  where tblCMS.title != "Inactive"
		// 						  where tblMM.id == _MemoId._Id
		// 						  select new MemoDatatable()
		// 						  {
		// 							  id = tblMM.id,
		// 							  memo_no = tblMM.memo_no,
		// 							  title = tblMM.title,
		// 							  description = tblMM.description,
		// 							  memostatusid = tblCMS.abbreviation,
		// 							  letter_issuance_date = tblMM.letter_issuance_date,
		// 							  reviewed = tblMM.reviewed,
		// 							  reviewed_by = tblMM.reviewed_by,
		// 							  approved = tblMM.approved,
		// 							  approved_by = tblMM.approved_by,
		// 							  memo_approved = tblMM.memo_approved,
		// 							  memo_approved_by = tblMM.memo_approved_by,
		// 							  issued = tblMM.issued,
		// 							  issued_by = tblMM.issued_by,
		// 						  })
		// 						.ToList();

		// 		if (_ObjResult.Count > 0)
		// 		{
		// 			_Value.data = _ObjResult;
		// 			_Value.draw = 1;
		// 			_Value.recordsTotal = _ObjResult.Count;
		// 			_Value.recordsFiltered = _ObjResult.Count;
		// 			_Success = true;
		// 		}
		// 		else
		// 		{
		// 			_Success = false;
		// 			_Message = "Record not found";
		// 		}
		// 	}
		// 	catch (Exception ex)
		// 	{
		// 		_Success = false;
		// 		_Message = ex.Message;
		// 	}

		// 	return _Value;
		// }

		[HttpPost]
		public async Task<JsonResultAPI> GetMemoStatus([FromBody] MemoId _MemoId)
		{
			JsonResultAPI _Value = new JsonResultAPI();
			bool _Success = false;
			string _Message = string.Empty;

			try
			{
				Console.WriteLine($"Received MemoId: {_MemoId._Id}");
				var _ObjResult = (from tblMM in _dbA.ModuleMemo
								  join tblCMS in _dbA.ConfigMemoStatus
								  on tblMM.memostatusid equals tblCMS.id
								  where tblMM.id == _MemoId._Id
								  select new MemoDatatable()
								  {
									  id = tblMM.id,
									  memo_no = tblMM.memo_no,
									  title = tblMM.title,
									  description = tblMM.description,
									  memostatusid = tblCMS.abbreviation,
									  letter_issuance_date = tblMM.letter_issuance_date,
									  reviewed = tblMM.reviewed,
									  reviewed_by = tblMM.reviewed_by,
									  approved = tblMM.approved,
									  approved_by = tblMM.approved_by,
									  memo_approved = tblMM.memo_approved,
									  memo_approved_by = tblMM.memo_approved_by,
									  issued = tblMM.issued,
									  issued_by = tblMM.issued_by,
								  })
								.ToList();

				Console.WriteLine($"Query Result Count: {_ObjResult.Count}");

				if (_ObjResult.Count > 0)
				{
					_Value.Result = _ObjResult;
					_Value.Total = _ObjResult.Count;
					_Success = true;
				}
				else
				{
					_Value.Result = new List<MemoDatatable>();
					_Value.Total = 0;
					_Message = "Record not found";
				}
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

		[HttpPost]
		public async Task<JsonResultDCPSDatatable> GetAppendixAList()
		{
			JsonResultDCPSDatatable _Value = new JsonResultDCPSDatatable();
			bool _Success = false;
			string _Message = string.Empty;
			try
			{
				var _ObjResult = (from tblRA in _dbDCPS.issuance_letter
									  //   join tblMI in _dbA.ModuleLetterIssuance
									  //   on tblRA.scholar_nric equals tblMI.scholar_nric
									  //   where tblRA.cost_code == tblMI.cost_code
								  select new DCPSDatatable()
								  {
									  scholar_name = tblRA.scholar_name,
									  scholar_nric = tblRA.scholar_nric,
									  address_1 = tblRA.address_1,
									  address_2 = tblRA.address_2,
									  address_3 = tblRA.address_3,
									  postcode = tblRA.postcode,
									  city = tblRA.city,
									  state = tblRA.state,
									  cost_code = tblRA.cost_code,
									  email = tblRA.email,
									  programme_name = tblRA.programme_name,
									  total = tblRA.total,
									  ra_amount = tblRA.ra_amount,
									  nra_amount = tblRA.nra_amount,
									  status = tblRA.status,
									  lod_issued_percentage = tblRA.lod_issued_percentage,
									  lod_amount = tblRA.lod_amount,
									  unique_id = tblRA.unique_id,
									  email_status = "UNRELEASED",
								  })
								.ToList();

				if (_ObjResult.Count > 0)
				{
					_Value.data = _ObjResult;
					_Value.draw = 1;
					_Value.recordsTotal = _ObjResult.Count;
					_Value.recordsFiltered = _ObjResult.Count;
					_Success = true;
				}
				else
				{
					_Success = false;
					_Message = "Record not found";
				}
			}
			catch (Exception ex)
			{
				_Success = false;
				_Message = ex.Message;
			}

			return _Value;
		}

		[HttpPost]
		public async Task<JsonResultAPI> GetScholarByNRIC([FromBody] DetailsId _DetailsId)
		{
			JsonResultAPI _Value = new JsonResultAPI();
			bool _Success = false;
			string _Message = string.Empty;
			try
			{
				var _scholarData = _dbDCPS.issuance_letter.Where(x => x.scholar_nric == _DetailsId._Id).FirstOrDefault();
				if (_scholarData != null)
				{
					_Value.Result = new issuance_letter
					{
						scholar_nric = _scholarData.scholar_nric,
						scholar_name = _scholarData.scholar_name,
						email = _scholarData.email,
						address_1 = _scholarData.address_1,
						address_2 = _scholarData.address_2,
						address_3 = _scholarData.address_3,
						postcode = _scholarData.postcode,
						city = _scholarData.city,
						cost_code = _scholarData.cost_code,
						programme_name = _scholarData.programme_name,
						total = _scholarData.total,
						ra_amount = _scholarData.ra_amount,
						nra_amount = _scholarData.nra_amount,
						status = _scholarData.status,
						lod_issued_percentage = _scholarData.lod_issued_percentage,
						lod_amount = _scholarData.lod_amount,
						unique_id = _scholarData.unique_id,
					};
					_Value.Total = 1;

					_Success = true;
				}
				else
				{
					_Success = false;
					_Message = "Record not found";
				}
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

		[HttpPost]
		public async Task<JsonResultAPI> UpdateMemoStatus([FromBody] UpdateMemoStatusRequest request)
		{
			JsonResultAPI _Value = new JsonResultAPI();
			bool _Success = false;
			string _Message = string.Empty;
			try
			{
				if (request == null || string.IsNullOrEmpty(request.MemoId) || string.IsNullOrEmpty(request.Status) || string.IsNullOrEmpty(request.Flag) || string.IsNullOrEmpty(request.UserName))
				{

					_Value.Success = false;
					_Value.Message = "Invalid request data";

				}

				var result = await UpdateStatusInDatabase(request.MemoId, request.Status, request.Flag, request.UserName);

				if (result)
				{
					_Value.Success = true;
					_Value.Message = "Memo status updated successfully";
				}
				else
				{
					_Value.Success = true;
					_Value.Message = "Failed to update memo status";
				}
			}
			catch (Exception ex)
			{
				_Value.Success = false;
				_Value.Message = ex.Message;
			}

			return _Value;
		}

		private async Task<bool> UpdateStatusInDatabase(string memoId, string status, string flag, string UserName)
		{
			if (!Guid.TryParse(memoId, out Guid memoIdGuid) ||
				!Guid.TryParse(status, out Guid statusGuid))
			{
				return false;
			}

			var memo = await _dbA.ModuleMemo.FindAsync(memoIdGuid);

			if (memo != null)
			{
				memo.memostatusid = statusGuid;
				if (flag == "SAA")
				{
					memo.reviewed_by = UserName;
					memo.reviewed = DateTime.UtcNow;
				}
				else if (flag == "AAA")
				{
					memo.approved_by = UserName;
					memo.approved = DateTime.UtcNow;
				}
				else if (flag == "AM")
				{
					memo.memo_approved_by = UserName;
					memo.memo_approved = DateTime.UtcNow;
				}

				_dbA.Entry(memo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
				await _dbA.SaveChangesAsync();
				await _dbA.DisposeAsync();
				return true;
			}

			return false;
		}

		[HttpPost]
		public async Task<JsonResultAPI> UpdateEmailMemoStatus([FromBody] UpdateEmailMemoStatusRequest request)
		{
			JsonResultAPI _Value = new JsonResultAPI();

			try
			{
				// Validate request data
				if (request == null || string.IsNullOrEmpty(request.MemoId) || string.IsNullOrEmpty(request.UserDisplayName) || string.IsNullOrEmpty(request.NRIC) || string.IsNullOrEmpty(request.ProgrammeName) || string.IsNullOrEmpty(request.CostCode))
				{
					_Value.Success = false;
					_Value.Message = "Invalid request data";
					return _Value;
				}

				var result = await UpdateEmailStatusInDatabase(request.MemoId, request.UserDisplayName, request.NRIC, request.ProgrammeName, request.CostCode);

				if (result)
				{
					_Value.Success = true;
					_Value.Message = "Memo status updated successfully";
					_Value.Result = result;
				}
				else
				{
					_Value.Success = false;
					_Value.Message = "Failed to update memo status";
				}
			}
			catch (Exception ex)
			{
				_Value.Success = false;
				_Value.Message = ex.Message;
			}

			return _Value;
		}



		private async Task<bool> UpdateEmailStatusInDatabase(string memoId, string UserDisplayName, string NRIC, string ProgrammeName, string CostCode)
		{
			if (!Guid.TryParse(memoId, out Guid memoIdGuid))
			{
				return false;
			}

			string guidRefNoString = Guid.NewGuid().ToString();

			var newLetterIssuance = new ModuleLetterIssuance
			{
				ref_issuance_no = guidRefNoString,
				memo_id = memoIdGuid,
				scholar_nric = NRIC,
				programme_name = ProgrammeName,
				cost_code = CostCode,
				issuanced = DateTime.UtcNow,
				issuanced_by = UserDisplayName
			};
			_dbA.ModuleLetterIssuance.Add(newLetterIssuance);
			await _dbA.SaveChangesAsync();
			return true;

		}

		[HttpPost]
		public async Task<bool> SendEmailtoScholar([FromBody] RecoveryEmailParameter _RecoveryEmailParameter)
		{
			try
			{
				using (var smtpClient = new SmtpClient("smtp.office365.com")
				{
					Port = 587,
					Credentials = new NetworkCredential("noreply@yayasanpeneraju.com.my", "wpdscnqpxvbwzdcp"),
					EnableSsl = true,
				})
				{
					var mailMessage = new MailMessage
					{
						From = new MailAddress("noreply@yayasanpeneraju.com.my"),
						Subject = "Notis Pembayaran Balik Skim Pembiayaan Pendidikan Yayasan Peneraju",
						Body = RecoveryEmailTemplate.EmailSurveyTemplate(
							_RecoveryEmailParameter.Fullname,
							_RecoveryEmailParameter.NRIC,
							_RecoveryEmailParameter.Email,
							_RecoveryEmailParameter.LOD,
							_RecoveryEmailParameter.Link),
						IsBodyHtml = true,
					};
					mailMessage.To.Add(_RecoveryEmailParameter.Email);

					await smtpClient.SendMailAsync(mailMessage);
				}

				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}


	}
}
