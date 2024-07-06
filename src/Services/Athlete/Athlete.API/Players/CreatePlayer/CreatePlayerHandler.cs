using FluentValidation;

namespace Athlete.API.Players.CreatePlayer
{
    public record CreatePlayerCommand(
        string Name, int Age, string BirthPlace) : ICommand<CreatePlayerResult>;

    public class CreatePlayerValidation : AbstractValidator<CreatePlayerCommand>
    {
        public CreatePlayerValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(x => x.Age).GreaterThan(0).WithMessage("Age must be greater than 0");
            RuleFor(x => x.BirthPlace).NotEmpty().WithMessage("BirthPlace cannot be empty");
        }
    }
    public record CreatePlayerResult(
        Player Player);

    internal class CreatePlayerCommandHandler(
        PlayerContext context)
        : ICommandHandler<CreatePlayerCommand, CreatePlayerResult>
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
