namespace TalentSearch.Web.Models.Configurations
{
	public class URIConfiguration
	{

		public static string _SignIn = "/api/Authorizations/Authentications/SignIn";
		public static string _Scholar_GetAll = "/api/Datawarehouses/Datawarehouses/GetScholarByAll";
		public static string _Scholar_GetById = "/api/Datawarehouses/Datawarehouses/GetScholarById";

		//Module Survey
		public static string _Survey_AddNew = "/api/Modules/ModuleSurveys/AddSurvey";

		//Module FileUpload
		public static string _Memo_AddNew = "api/Modules/ModuleFileUpload/AddFile";
		public static string _Scholar_GetByNRIC = "/api/Recovery/Recovery/GetScholarByNRIC";
		public static string _Recovery_UpdateMemoStatus = "api/Recovery/Recovery/UpdateMemoStatus";
		public static string _Recovery_GetMemoStatus = "api/Recovery/Recovery/GetMemoStatus";
		public static string _Recovery_SendEmailtoScholar = "api/Recovery/Recovery/SendEmailtoScholar";
	}
}
