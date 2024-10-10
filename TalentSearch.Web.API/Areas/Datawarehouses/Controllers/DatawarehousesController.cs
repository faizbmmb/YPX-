using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.EntityFrameworkCore;
using TalentSearch.Core.Recovery.View;
using TalentSearch.Core.Datawarehouse;
using TalentSearch.Core.Datawarehouse.Results;
using TalentSearch.Core.Parameters;
using TalentSearch.Core.Results;
using TalentSearch.Web.API.Models.DBContexts;

namespace TalentSearch.Web.API.Areas.Datawarehouse.Controllers
{
	[ApiExplorerSettings(GroupName = "Datawarehouses")]
	[Area("Datawarehouses")]
	[Route("api/[Area]/[controller]/[action]")]
	[ApiController]
	[EnableCors("AllowOrigin")]
	public class DatawarehousesController : ControllerBase
	{
		private readonly IConfiguration _iConfiguration;
        private readonly DWDbContext _db;
        private readonly ApplicationDbContext _dbA;
        private readonly DCPSDbContext _dbDCPS;
        private readonly IHttpContextAccessor _httpContextAccessor;
		//private readonly IEmailService _emailService;
		//private readonly IConfigEmailRepository _configEmailRepository;

		public DatawarehousesController(
            DWDbContext db,
            ApplicationDbContext dbA,
			DCPSDbContext dbDCPS,
            IConfiguration iConfiguration
			//IConfigEmailRepository configEmailRepository
			)
		{
			_db = db;
			_dbA = dbA;
			_dbDCPS = dbDCPS;
            _iConfiguration = iConfiguration;
			//_httpContextAccessor = httpContextAccessor;
			//_emailService = emailService;
			//_configEmailRepository = configEmailRepository;
		}

		[HttpPost]
		public async Task<JsonResultAPI> GetScholarById([FromBody] DetailsId _DetailsId)
		{
			JsonResultAPI _Value = new JsonResultAPI();
            bool _Success = false;
            string _Message = string.Empty;
            try
            {
				var _scholarData = _db.tbl_scholar.Where(x => x.sch_nric_new == _DetailsId._Id).FirstOrDefault();
				if (_scholarData != null) {

					var _dcpsData = _db.tbl_dcps.Where(x => x.sch_nric_new == _DetailsId._Id).FirstOrDefault();
					_Value.Result = new tbl_datawarehouse
					{
						scholar_id = _scholarData.id,
						dcps_id = _dcpsData != null ? _dcpsData.id : null,
						tbl_Scholar = _scholarData,
						tbl_dcps = _dcpsData != null ? _dcpsData : null
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
		public async Task<JsonResultAPI> GetScholarByAll()
		{
			JsonResultAPI _Value = new JsonResultAPI();
			bool _Success = false;
			string _Message = string.Empty;
			try
			{
				List<tbl_datawarehouse> _DWResult = new List<tbl_datawarehouse>();

				var _ObjResult = (from tbls in _db.tbl_scholar
								  join tbld in _db.tbl_dcps on tbls.sch_nric_new equals tbld.sch_nric_new
								  where tbld.sch_nric_new != null
								  select tbls).Take(50).ToList();

				foreach (var _objSD in _ObjResult)
				{
					var _objDcps = _db.tbl_dcps.Where(x => x.sch_nric_new == _objSD.sch_nric_new).FirstOrDefault();
					_DWResult.Add(new tbl_datawarehouse
					{
						scholar_id = _objSD.id,
						dcps_id = _objDcps != null ? _objDcps.id : null,
						tbl_Scholar = _objSD,
						tbl_dcps = _objDcps != null ? _objDcps : null
					});
				}

				if (_DWResult.Count > 0)
				{
					_Value.Result = _DWResult;
					_Value.Total = _DWResult.Count;
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
		public async Task<JsonResultDatatable> GetScholarByAllDataTables()
		{
			JsonResultDatatable _Value = new JsonResultDatatable();
			bool _Success = false;
			string _Message = string.Empty;
			try
			{
				var _ObjResult = (from tbls in _db.tbl_scholar
								  join tbld in _db.tbl_dcps on tbls.sch_nric_new equals tbld.sch_nric_new
								  where tbld.sch_nric_new != null
								  select new ScholarDatatable()
								  {
									  //tbl_scholar
									  sch_id = tbls.sch_id,
									  sch_name = tbls.sch_name,
									  sch_nric_new = tbls.sch_nric_new,
									  sch_prog_status = tbls.sch_prog_status,
									  sch_gender = tbls.sch_gender,
									  sch_mobile_num = tbls.sch_mobile_num,
									  sch_email = tbls.sch_email,
									  main_thrust = tbls.main_thrust,
									  batch = tbls.batch,
									  cost_code = tbls.cost_code,
									  cohort = tbls.cohort,
									  thrust = tbls.thrust,
									  sub_thrust = tbls.sub_thrust,
									  framework	= tbls.framework,
									  funding_model	= tbls.funding_model,
									  type_of_enrolment	= tbls.type_of_enrolment,
									  prog_name = tbls.prog_name,
									  program_entry = tbls.program_entry,
									  contract_start = tbls.contract_start,
									  contract_end = tbls.contract_end,
									  programme_status = tbls.programme_status,
									  //tbl_dcps
									  amt_w_gst = tbld.amt_w_gst
								  })
								  //.Take(50)
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
	}
}
