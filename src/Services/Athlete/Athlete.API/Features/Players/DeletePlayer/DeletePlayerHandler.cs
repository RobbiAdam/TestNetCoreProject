namespace Athlete.API.Features.Players.DeletePlayer
{
    public record DeletePlayerCommand(
    int Id) : ICommand<DeletePlayerResult>;

    public record DeletePlayerResult(bool IsSuccess);

    public class DeletePlayerCommandHandler(
        PlayerContext context) : ICommandHandler<DeletePlayerCommand, DeletePlayerResult>
    {
        public async Task<DeletePlayerResult> Handle(DeletePlayerCommand command, CancellationToken cancellationToken)
        {
            var player = await context.Players.FindAsync(command.Id);
            if (player != null)
            {
                context.Players.Remove(player);
            }

            await context.SaveChangesAsync(cancellationToken);
            return new DeletePlayerResult(true);
        }
    }
}
