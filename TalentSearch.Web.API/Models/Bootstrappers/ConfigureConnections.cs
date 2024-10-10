using TalentSearch.Web.API.Models.Connections.Connections;

namespace TalentSearch.Web.API.Bootstrapper
{
    public static class ConfigureConnections
    {
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services,
           IConfiguration configuration, IHostEnvironment hostingEnvironment)
        {
            var connection = String.Empty;

            //if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            //{
            //    connection = configuration.GetConnectionString("MSSQLDBContext") ??
            //                 "data source=172.16.42.43\\DATAWAREHOUSE;initial catalog=mfloraBlackBox;user id=sa;password=dat@wareh0us3;MultipleActiveResultSets=True;App=EntityFramework;";
            //}
            //else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            //{
            //    //connection = configuration.GetConnectionString("MSSQLDBContext") ??
            //    //             "Server=localhost,1433;Database=mfloraBlackBox;User=sa;Password=dat@wareh0us3;Trusted_Connection=False;Application Name=mfloraBlackBox";
            //}

            //services.AddDbContextPool<ChinookContext>(options => options.UseSqlServer(connection));

            //services.AddSingleton(new sqlconnection(connection));

            services.AddSingleton(new NpgSQLConfiguration(configuration));

            //services.AddSingleton(new SQLConfiguration(connection));

            return services;
        }
    }
}
