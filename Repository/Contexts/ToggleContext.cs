using DataAccessLayer.Entities;


using System.Data.Entity;


namespace DataAccessLayer.Repositories
{
    public class ToggleContext: DbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Toggle> Toggles { get; set; }
    }
}