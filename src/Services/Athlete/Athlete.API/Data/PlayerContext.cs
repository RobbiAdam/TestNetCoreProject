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
                new Player { Id = 1, Name = "Cristiano Ronaldo", Age = 38, BirthPlace = "Europe", ClubName= "Juventus" },
                new Player { Id = 2, Name = "Lionel Messi", Age = 36, BirthPlace = "South America", ClubName= "Barcelona" },
                new Player { Id = 3, Name = "Karim Benzema", Age = 35, BirthPlace = "Europe", ClubName= "Real Madrid" },
                new Player { Id = 4, Name = "Erling Haaland", Age = 23, BirthPlace = "Europe", ClubName= "Manchester City" },
                new Player { Id = 5, Name = "Kylian Mbappe", Age = 24, BirthPlace = "Europe", ClubName= "Paris Saint-Germain" },
                new Player { Id = 6, Name = "Robert Lewandowski", Age = 34, BirthPlace = "Europe", ClubName= "Barcelona" },
                new Player { Id = 7, Name = "Kevin De Bruyne", Age = 32, BirthPlace = "Europe", ClubName= "Manchester City" },
                new Player { Id = 8, Name = "Neymar Jr.", Age = 32, BirthPlace = "South America", ClubName= "Real Madrid" },
                new Player { Id = 9, Name = "Paulo Dybala", Age = 30, BirthPlace = "South America", ClubName= "Juventus" },
                new Player { Id = 10, Name = "Luka Modric", Age = 38, BirthPlace = "Europe", ClubName= "Real Madrid" }
            );
        }
    }
}
