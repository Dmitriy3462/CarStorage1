using Microsoft.EntityFrameworkCore;


namespace CarStorage.DAL.Models.Context
{
    public class CarStorageContext:DbContext
    {
        #region Conection
        public CarStorageContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CarStorage;Trusted_Connection=True;");
        }
        #endregion
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
