using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TalentSearch.Web.API.Bootstrapper;
using TalentSearch.Web.API.Models.Configurations;
using TalentSearch.Web.API.Models.DBContext;
using TalentSearch.Web.API.Models.DBContexts;
namespace TalentSearch.Web.API
{
	public class Startup
	{
		public IConfiguration Configuration { get; set; }
		public IHostEnvironment HostEnvironment { get; set; }

		public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment)
		{
			Configuration = configuration;
			HostEnvironment = hostEnvironment;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddMvc();
			services.AddMvcCore().AddApiExplorer();

			services.AddControllers()
			.AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.PropertyNamingPolicy = null;
			})
			.AddXmlDataContractSerializerFormatters();

			services.AddCors(c =>
			{
				c.AddPolicy("AllowOrigin", options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
			});

			services.AddAuthorization();

			////Postgresql 
			services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>(opt =>
				opt.UseNpgsql(Configuration.GetConnectionString("TalentSearchDBContext")));
			services.AddEntityFrameworkNpgsql().AddDbContext<DWDbContext>(opt =>
				opt.UseNpgsql(Configuration.GetConnectionString("DWDbContext")));
			services.AddEntityFrameworkNpgsql().AddDbContext<DCPSDbContext>(opt =>
				opt.UseNpgsql(Configuration.GetConnectionString("DCPSDbContext")));
			//set which server to handle identity
			services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationIdentityDbContext>(opt =>
				opt.UseNpgsql(Configuration.GetConnectionString("TalentSearchDBContext")));

			//MSSQL
			//services.AddDbContext<ApplicationDbContext>(opt =>
			//	opt.UseSqlServer(Configuration.GetConnectionString("TalentSearchDBContext")));
			//services.AddDbContext<ApplicationIdentityDbContext>(opt =>
			//   opt.UseSqlServer(Configuration.GetConnectionString("TalentSearchDBContext")));

			services.AddIdentity<ApplicationUser, ApplicationRole>(opt =>
			{
				opt.SignIn.RequireConfirmedAccount = true;
				opt.SignIn.RequireConfirmedEmail = true;
				opt.Lockout.MaxFailedAccessAttempts = 3;
				opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
			})
				.AddEntityFrameworkStores<ApplicationIdentityDbContext>()
				.AddDefaultTokenProviders();

			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("Authorizations", new OpenApiInfo { Title = "Talent Bank API Authorization", Version = "v1" });
				options.SwaggerDoc("Configurations", new OpenApiInfo { Title = "Talent Bank API Configuration", Version = "v1" });
				options.SwaggerDoc("Datawarehouses", new OpenApiInfo { Title = "Talent Bank API Datawarehouse", Version = "v1" });
				options.SwaggerDoc("Modules", new OpenApiInfo { Title = "Talent Bank API Module", Version = "v1" });
				options.SwaggerDoc("Recovery", new OpenApiInfo { Title = "Recovery API", Version = "v1" });
			});

			services.AddMemoryCache();

			services.AddConnectionProvider(Configuration, HostEnvironment);
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			//app.UseStaticFiles();
			// app.UseCookiePolicy();

			app.UseRouting();
			// app.UseRequestLocalization();
			app.UseCors("AllowOrigin");

			app.UseAuthentication();
			app.UseAuthorization();
			// app.UseSession();
			// app.UseResponseCaching();

			//app.UseResponseCompression();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{area:exist}/{controller=Home}/{action=Index}/{id?}");
			});


			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/Authorizations/swagger.json", "Talent Bank API Authorization");
				c.SwaggerEndpoint("/swagger/Configurations/swagger.json", "Talent Bank API Configuration");
				c.SwaggerEndpoint("/swagger/Datawarehouses/swagger.json", "Talent Bank API Datawarehouse");
				c.SwaggerEndpoint("/swagger/Modules/swagger.json", "Talent Bank API Module");
				c.SwaggerEndpoint("/swagger/Recovery/swagger.json", "Recovery API");
			});

			app.UseWelcomePage();
		}
	}
}