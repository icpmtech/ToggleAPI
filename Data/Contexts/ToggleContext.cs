using Data.Entities;


using System.Data.Entity;


namespace Data.Repositories
{
    public class ToggleContext: DbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Toggle> Toggles { get; set; }
    }
}