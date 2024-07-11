namespace Athlete.API.Features.Players.GetPlayers
{
    public record GetPlayersQuery() : IQuery<GetPlayersResult>;

    public record GetPlayersResult(
        IEnumerable<Player> Players);

    internal class GetPlayersQueryHandler(
        PlayerContext context)
        : IQueryHandler<GetPlayersQuery, GetPlayersResult>
    {
        public async Task<GetPlayersResult> Handle(GetPlayersQuery query, CancellationToken cancellationToken)
        {
            var players = await context.Players.ToListAsync(cancellationToken);
            return new GetPlayersResult(players);
        }
    }
}
