namespace FoodOrderApp.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menus>().HasData(
                new Menus {Id = 1, Status = "Completed"},
                new Menus {Id = 2, Status = "In Progress"}
                );

            modelBuilder.Entity<Order>().HasData(
                new Order { 
                    Id = 1, 
                    NoOrder = "ABC1", 
                    NomorMeja = "1", 
                    MenusId = 1
                },
                new Order { 
                    Id = 2, 
                    NoOrder = "ABC2", 
                    NomorMeja = "2", 
                    MenusId = 2
                },
                new Order { 
                    Id = 3, 
                    NoOrder = "ABC3", 
                    NomorMeja = "3", 
                    MenusId = 1
                });
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Menus> Menu { get; set; }

    }
}
