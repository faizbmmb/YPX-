using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TalentSearch.Web.API.Models.Configurations;

namespace TalentSearch.Web.API.Models.DBContext
{
	public class ApplicationIdentityDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
	{
		public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options) : base(options)
		{ }
	}
}
