using Microsoft.EntityFrameworkCore;
using TalentSearch.Core.Recovery.View;

namespace TalentSearch.Web.API.Models.DBContexts
{
	public class DCPSDbContext : DbContext
    {
		public DCPSDbContext(DbContextOptions<DCPSDbContext> options) : base(options){ }

		public DbSet<issuance_letter> issuance_letter { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
        {
			
		}
    }
}
