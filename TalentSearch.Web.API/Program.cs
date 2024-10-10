using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using System.Configuration;
using TalentSearch.Web.API;
using TalentSearch.Web.API.Models.Configurations;
using TalentSearch.Web.API.Models.DBContext;
using TalentSearch.Web.API.Models.DBContexts;

public class Program
{
	public static void Main(string[] args)
	{
		CreateHostBuilder(args).Build().Run();
	}
	public static IHostBuilder CreateHostBuilder(string[] args)
	{
		string port = Environment.GetEnvironmentVariable("PORT") ?? "80";
		string url = String.Concat("http://0.0.0.0:", port);

		return Host.CreateDefaultBuilder(args)
			.ConfigureWebHostDefaults(webBuilder =>
			{
				//webBuilder.UseKestrel();
				webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
				webBuilder.UseIISIntegration();
				webBuilder.UseStartup<Startup>();//.UseUrls(url);
			});
	}
}

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(options =>
//{
//	options.SwaggerDoc("Authorizations", new OpenApiInfo { Title = "Talent Bank API Authorization", Version = "v1" });
//	options.SwaggerDoc("Weathers", new OpenApiInfo { Title = "Talent Bank API Weather", Version = "v1" });
//});

//builder.Services.AddControllers()
//.AddJsonOptions(options =>
//{
//	options.JsonSerializerOptions.PropertyNamingPolicy = null;
//});


//builder.Services.AddMvc();
//builder.Services.AddMvcCore().AddApiExplorer();

//builder.Services.AddCors(c =>
//{
//	//c.AddPolicy("AllowOrigin", options => options.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
//	c.AddPolicy("AllowOrigin", options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
//});


////Postgresql
////builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>(opt =>
////	opt.UseNpgsql((builder.Configuration.GetConnectionString("TalentSearchDBContext"))));
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//		options.UseNpgsql(builder.Configuration.GetConnectionString("TalentSearchDBContext")));
////set which server to handle identity
//builder.Services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationIdentityDbContext>(opt =>
//	opt.UseNpgsql((builder.Configuration.GetConnectionString("TalentSearchDBContext"))));

////MSSQL
////builder.Services.AddDbContext<ApplicationDbContext>(options =>
////{
////	options.UseNpgsql(builder.Configuration.GetConnectionString("TalentSearchDBContext"));
////}); 
////builder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
////{
////	options.UseNpgsql(builder.Configuration.GetConnectionString("TalentSearchDBContext"));
////});

//// Add services to the container.
//builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(opt =>
//{
//	opt.SignIn.RequireConfirmedAccount = true;
//	opt.SignIn.RequireConfirmedEmail = true;
//	opt.Lockout.MaxFailedAccessAttempts = 3;
//	opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
//})
//.AddEntityFrameworkStores<ApplicationIdentityDbContext>()
//.AddDefaultTokenProviders();
//builder.Services.AddScoped<AuthenticationService>();



//var app = builder.Build();


//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//	app.UseSwagger();
//	app.UseSwaggerUI(options =>
//	{
//		options.SwaggerEndpoint("/swagger/Authorizations/swagger.json", "Talent Bank API Authorizations");
//		options.SwaggerEndpoint("/swagger/Weathers/swagger.json", "Talent Bank API Weathers");
//	});
//}

//app.UseRouting();
////Enable Authentication
//app.UseAuthentication();
//app.UseAuthorization();
//app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
//app.UseEndpoints(endpoints =>
//{
//	endpoints.MapControllers();
//});
//app.MapControllers();
//app.Run();
