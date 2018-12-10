using System.Data.Entity.Migrations;
using Heuristics.TechEval.Core.Models;

namespace Heuristics.TechEval.Core.Migrations
{
	internal sealed class Configuration : DbMigrationsConfiguration<DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

	        context.Categories.AddOrUpdate(
		        new Category {Name = "Software Developer"},
		        new Category {Name = "Director of Application Development"}
	        );

	        context.Members.AddOrUpdate(
		        new Member { Email = "sjohnson@heuristics.net", Name = "Seth Petry-Johnson", CategoryId=2},
		        new Member { Email = "sreed@heuristics.net", Name = "Scott Reed", CategoryId = 1 },
                new Member { Email = "mfeimster@heuristics.net", Name = "Mike Feimster", CategoryId = 1 },
                new Member { Email = "bphipps@heuristics.net", Name = "Brad Phipps", CategoryId = 1 }
            );


        }
    }
}
