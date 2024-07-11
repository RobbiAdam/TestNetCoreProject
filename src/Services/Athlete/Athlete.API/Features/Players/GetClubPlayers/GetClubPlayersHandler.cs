namespace Athlete.API.Features.Players.GetClubPlayers;

public record GetClubPlayersQuery(string ClubName) : IQuery<GetClubPlayersResult>;
public class GetClubPlayersValidation : AbstractValidator<GetClubPlayersQuery>
{
    public GetClubPlayersValidation()
    {
        RuleFor(x => x.ClubName).NotEmpty().WithMessage("Club name cannot be empty");
    }
}

public record GetClubPlayersResult(
    IEnumerable<Player> Players, int PlayerCount);

internal class GetClubPlayersQueryHandler(
    PlayerContext context) : IQueryHandler<GetClubPlayersQuery, GetClubPlayersResult>
{
    public async Task<GetClubPlayersResult> Handle(GetClubPlayersQuery query, CancellationToken cancellationToken)
    {
        var players = await context.Players
             .Where(p => p.ClubName.ToLower().Contains(query.ClubName.ToLower()))
             .ToListAsync(cancellationToken);

        return new GetClubPlayersResult(
            PlayerCount: players.Count,
            Players: players);
    }
}
