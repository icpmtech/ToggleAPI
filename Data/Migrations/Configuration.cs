namespace Data.Migrations
{
    using Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Data.Repositories.ToggleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.Repositories.ToggleContext context)
        {
            //  This method will be called after migrating to the latest version.
            IList<Service> defaultServices = new List<Service>();
            defaultServices.Add(new Service() { Name = "ABC", Identifier = Guid.NewGuid(), Version = 1 });

            for (int i = 1; i <= 61; i++)
            {
                defaultServices.Add(new Service() { Name = "ABC" + i, Identifier = Guid.NewGuid(), Version = 1 });

            }

            context.Services.AddRange(defaultServices);
           
            base.Seed(context);
           //   helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
