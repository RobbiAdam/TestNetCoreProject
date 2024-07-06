﻿namespace Athlete.API.Exceptions
{
    public class PlayerNotFoundException : Exception
    {
        public PlayerNotFoundException(int Id) : base($"Player with Id: {Id} was not found")
        {            
        }
    }
}
