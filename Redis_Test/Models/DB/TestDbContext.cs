using Microsoft.EntityFrameworkCore;

namespace Redis_Test.Models.DB
{
    public class Game11
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time{ get; set; }
    }
    public class TestDbContext: DbContext
    {


        public DbSet<Game11> Game11s { get; set; }

        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game11>().ToTable("Game11");
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    //optionsBuilder.UseSqlServer(@"Server=DESKTOP-8C408JE;Database=Test1;User Id=hahaer;Password=a91134042;");
        //}
    }
}
