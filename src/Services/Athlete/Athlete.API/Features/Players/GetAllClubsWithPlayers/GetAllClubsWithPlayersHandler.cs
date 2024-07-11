namespace Athlete.API.Features.GetClubsWithPlayers
{
    public record GetClubsWithPlayersQuery() : IQuery<GetClubsWithPlayersResult>;

    public record ClubInfo(string ClubName, int PlayerCount, IEnumerable<Player> Players);

    public record GetClubsWithPlayersResult(IEnumerable<ClubInfo> Clubs);

    internal class GetClubsWithPlayersCommandHandler(
        PlayerContext context)
        : IQueryHandler<GetClubsWithPlayersQuery, GetClubsWithPlayersResult>
    {
        public async Task<GetClubsWithPlayersResult> Handle(GetClubsWithPlayersQuery query, CancellationToken cancellationToken)
        {
            var clubsWithPlayers = await context.Players
                .GroupBy(p => p.ClubName)
                .Select(g => new ClubInfo(
                    g.Key,
                    g.Count(),
                    g.ToList()))
                .ToListAsync(cancellationToken);

            return new GetClubsWithPlayersResult(clubsWithPlayers);
        }
    }
}