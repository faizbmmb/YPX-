using Microsoft.EntityFrameworkCore;
using TalentSearch.Core.Configurations;
using TalentSearch.Core.Datawarehouses;

namespace TalentSearch.Web.API.Models.DBContexts
{
	public class DWDbContext : DbContext
    {
		public DWDbContext(DbContextOptions<DWDbContext> options) : base(options){ }

		//Module
		public DbSet<tbl_scholar> tbl_scholar { get; set; }
		public DbSet<tbl_dcps> tbl_dcps { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
        {
			//base.OnModelCreating(builder);

			builder.Entity<tbl_scholar>().HasKey(s => s.id);
            builder.Entity<tbl_dcps>().HasKey(s => s.id);
		}
    }
}
