namespace Athlete.API.Players.GetPlayersByBirthPlace
{
    public record GetPlayersByBirthPlaceQuery(string BirthPlace) : IRequest<GetPlayersByBirthPlaceResult>;
    public record GetPlayersByBirthPlaceResult(
        IEnumerable<Player> Players);

    internal class GetPlayersByBirthPlaceQueryHandler(
        PlayerContext context) 
        : IRequestHandler<GetPlayersByBirthPlaceQuery, GetPlayersByBirthPlaceResult>
    {
        public async Task<GetPlayersByBirthPlaceResult> Handle(GetPlayersByBirthPlaceQuery request, CancellationToken cancellationToken)
        {
            var players = await context.Players
                .Where(p => p.BirthPlace.ToLower().Contains(request.BirthPlace.ToLower()))
                .ToListAsync(cancellationToken);

            return new GetPlayersByBirthPlaceResult(players);
        }
    }
}
