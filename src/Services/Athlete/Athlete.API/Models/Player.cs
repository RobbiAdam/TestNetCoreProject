namespace Athlete.API.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int Age { get; set; }
        public string BirthPlace { get; set; } = default!;
        public string ClubName { get; set; } = default!;
    }
}
