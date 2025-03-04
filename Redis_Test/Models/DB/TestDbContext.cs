using Microsoft.EntityFrameworkCore;

namespace Redis_Test.Models.DB
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time{ get; set; }
    }
    public class TestDbContext: DbContext
    {


        public DbSet<Product> Products { get; set; }

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    //optionsBuilder.UseSqlServer(@"Server=DESKTOP-8C408JE;Database=Test1;User Id=hahaer;Password=a91134042;");
        //}
    }
}
