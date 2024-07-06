namespace Athlete.API.Data
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasData(
                new Player { Id = 1, Name = "Cristiano Ronaldo", Age = 38, BirthPlace = "Europe" },
                new Player { Id = 2, Name = "Lionel Messi", Age = 36, BirthPlace = "South America" },
                new Player { Id = 3, Name = "Karim Benzema", Age = 35, BirthPlace = "Europe" },
                new Player { Id = 4, Name = "Erling Haaland", Age = 23, BirthPlace = "Europe" },
                new Player { Id = 5, Name = "Kylian Mbappe", Age = 24, BirthPlace = "Europe" }
            );
        }
    }
}
