

namespace Athlete.API.Exceptions
{
    public class PlayerNotFoundException : NotFoundException
    {
        public PlayerNotFoundException(int Id) : base($"Player with Id: {Id} was not found")
        {            
        }
    }
}
