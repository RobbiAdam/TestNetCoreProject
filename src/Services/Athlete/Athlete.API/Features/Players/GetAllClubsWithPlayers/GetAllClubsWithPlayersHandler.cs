namespace Athlete.API.Clubs.GetClubsWithPlayers
{
    public record GetClubsWithPlayersCommand() : IQuery<GetClubsWithPlayersResult>;

    public record ClubInfo(string ClubName, int PlayerCount, IEnumerable<Player> Players);

    public record GetClubsWithPlayersResult(IEnumerable<ClubInfo> Clubs);

    internal class GetClubsWithPlayersCommandHandler(
        PlayerContext context)
        : IQueryHandler<GetClubsWithPlayersCommand, GetClubsWithPlayersResult>
    {
        public async Task<GetClubsWithPlayersResult> Handle(GetClubsWithPlayersCommand request, CancellationToken cancellationToken)
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