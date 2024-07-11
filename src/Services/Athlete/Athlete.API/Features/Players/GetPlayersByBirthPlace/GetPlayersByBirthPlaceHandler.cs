namespace Athlete.API.Features.Players.GetPlayersByBirthPlace
{
    public record GetPlayersByBirthPlaceQuery(string BirthPlace) : IQuery<GetPlayersByBirthPlaceResult>;
    public record GetPlayersByBirthPlaceResult(
        IEnumerable<Player> Players);

    internal class GetPlayersByBirthPlaceQueryHandler(
        PlayerContext context)
        : IQueryHandler<GetPlayersByBirthPlaceQuery, GetPlayersByBirthPlaceResult>
    {
        public async Task<GetPlayersByBirthPlaceResult> Handle(GetPlayersByBirthPlaceQuery query, CancellationToken cancellationToken)
        {
            var players = await context.Players
                .Where(p => p.BirthPlace.ToLower().Contains(query.BirthPlace.ToLower()))
                .ToListAsync(cancellationToken);

            return new GetPlayersByBirthPlaceResult(players);
        }
    }
}
