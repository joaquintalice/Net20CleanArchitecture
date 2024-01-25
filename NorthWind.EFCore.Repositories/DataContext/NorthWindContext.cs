namespace NorthWind.EFCore.Repositories.DataContext
{
    // Add-Migration NorthWind.EFCore.Repositories -s NorthWind.EFCore.Repositories -Context NorthWindContext
    // Update-Database -p NorthWind.EFCore.Repositories -s NorthWind.EFCore.Repositories -Context NorthWindContext

    internal class NorthWindContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=NorthWindNET20");
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
