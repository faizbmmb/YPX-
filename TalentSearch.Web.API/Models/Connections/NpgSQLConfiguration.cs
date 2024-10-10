using Npgsql;
using Microsoft.Extensions.Configuration;

namespace TalentSearch.Web.API.Models.Connections.Connections
{

	public class NpgSQLConfiguration
    {
        public string _SQLConnectionString_TalentSearch { get; }
        public string _SQLConnectionString_Datawarehouse { get; }
        private static NpgsqlConnection _NpgSQLConnection_TalentSearch;
        private static NpgsqlConnection _NpgSQLConnection_Datawarehouse;
        private static NpgsqlCommand _NpgSQLCommand;
		private static IConfiguration _Configuration;

		public NpgSQLConfiguration(IConfiguration configuration)
		{
			//_NpgSQLConnectionStrings = NpgSQLConnectionStrings;
			_Configuration = configuration;
            _SQLConnectionString_TalentSearch = _Configuration.GetConnectionString("TalentSearchDBContext");
            _SQLConnectionString_Datawarehouse = _Configuration.GetConnectionString("DWDbContext");
        }

        public static NpgsqlConnection NpgSQLConnection_TalentSearch
        {
            get
            {

                NpgSQLConnection_TalentSearch = new NpgsqlConnection(_Configuration.GetConnectionString("TalentSearchDBContext"));
                return NpgSQLConnection_TalentSearch;
            }
            set
            {
                NpgSQLConnection_TalentSearch = new NpgsqlConnection(_Configuration.GetConnectionString("TalentSearchDBContext"));
            }
        }

        public static NpgsqlConnection NpgSQLConnection_Datawarehouse
        {
            get
            {

                NpgSQLConnection_Datawarehouse = new NpgsqlConnection(_Configuration.GetConnectionString("DWDbContext"));
                return NpgSQLConnection_Datawarehouse;
            }
            set
            {
                NpgSQLConnection_Datawarehouse = new NpgsqlConnection(_Configuration.GetConnectionString("DWDbContext"));
            }
        }

        public static NpgsqlCommand NpgSQLCommand
		{
			get
			{
				_NpgSQLCommand = new NpgsqlCommand();
				_NpgSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
				_NpgSQLCommand.CommandTimeout = 0;
				return _NpgSQLCommand;
			}
			set
			{
				_NpgSQLCommand = new NpgsqlCommand();
				_NpgSQLCommand.CommandType = System.Data.CommandType.StoredProcedure;
				_NpgSQLCommand.CommandTimeout = 0;
			}
		}

		public static NpgsqlCommand NpgSQLTextCommand
		{
			get
			{
				_NpgSQLCommand = new NpgsqlCommand();
				_NpgSQLCommand.CommandTimeout = 0;
				return _NpgSQLCommand;
			}
			set
			{
				_NpgSQLCommand = new NpgsqlCommand();
				_NpgSQLCommand.CommandTimeout = 0;
			}
		}
	}
}
