using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Heuristics.TechEval.Core.Models;

namespace Heuristics.TechEval.Core {

	public class DataContext : DbContext {

		public DataContext() : base("Database") { }

		public DbSet<Category> Categories { get; set; }

		public DbSet<Member> Members { get; set; }


		protected override void OnModelCreating(DbModelBuilder modelBuilder) {
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}