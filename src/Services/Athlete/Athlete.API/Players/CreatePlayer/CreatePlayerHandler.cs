namespace Athlete.API.Players.CreatePlayer
{
    public record CreatePlayerCommand(
        string Name, int Age, string BirthPlace) : IRequest<CreatePlayerResult>;

    public record CreatePlayerResult(
        Player Player);

    internal class CreatePlayerCommandHandler(
        PlayerContext context)
        : IRequestHandler<CreatePlayerCommand, CreatePlayerResult>
    {
        public async Task<CreatePlayerResult> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var player = new Player
            {
                Name = request.Name,
                Age = request.Age,
                BirthPlace = request.BirthPlace
            };

            context.Players.Add(player);
            await context.SaveChangesAsync(cancellationToken);

            return new CreatePlayerResult(player);
        }
    }
}
