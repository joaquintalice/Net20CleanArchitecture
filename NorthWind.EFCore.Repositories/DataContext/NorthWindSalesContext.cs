namespace NorthWind.EFCore.Repositories.DataContext
{
    public class NorthWindSalesContext : DbContext
    {
        public NorthWindSalesContext(DbContextOptions<NorthWindSalesContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
