﻿namespace Athlete.API.Players.GetPlayers
{
    public record GetPlayersQuery() : IRequest<GetPlayersResult>;

    public record GetPlayersResult(
        IEnumerable<Player> Players);

    internal class GetPlayersQueryHandler (
        PlayerContext context)
        : IRequestHandler<GetPlayersQuery, GetPlayersResult>
    {
        public async Task<GetPlayersResult> Handle(GetPlayersQuery request, CancellationToken cancellationToken)
        {
            var players = await context.Players.ToListAsync();
            return new GetPlayersResult(players);
        }
    }
}
