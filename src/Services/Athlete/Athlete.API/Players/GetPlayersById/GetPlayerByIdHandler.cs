using Athlete.API.Exceptions;

namespace Athlete.API.Players.GetPlayersById
{
    public record GetPlayerByIdQuery(
        int Id) : IRequest<GetPlayerByIdResult>;

    public record GetPlayerByIdResult(
        Player Player);

    internal class GetPlayerByIdQueryHandler(
        PlayerContext context) : IRequestHandler<GetPlayerByIdQuery, GetPlayerByIdResult>
    {
        public async Task<GetPlayerByIdResult> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
            var player = await context.Players.FindAsync(request.Id, cancellationToken);

            if (player == null)
            {
                throw new PlayerNotFoundException(request.Id);
            }

            return new GetPlayerByIdResult(player);
        }
    }
}
