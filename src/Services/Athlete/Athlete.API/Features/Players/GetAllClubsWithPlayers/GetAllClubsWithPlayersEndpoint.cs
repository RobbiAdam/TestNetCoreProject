using Athlete.API.Clubs.GetClubsWithPlayers;

namespace Athlete.API.Features.Players.GetAllClubsWithPlayers
{
    public record ClubInfoResponse(string ClubName, int PlayerCount, IEnumerable<Player> Players);
    public record GetAllClubsWithPlayersResponse(IEnumerable<ClubInfoResponse> Clubs);
    public class GetAllClubsWithPlayersEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/clubs-with-players", async (ISender sender) =>
            {
                var command = new GetClubsWithPlayersCommand();
                var result = await sender.Send(command);
                var response = new GetAllClubsWithPlayersResponse(
                    result.Clubs.Select(c => new ClubInfoResponse(c.ClubName, c.PlayerCount, c.Players)).ToList()
                );
                return Results.Ok(response);
            })
                .WithName("GetClubsWithPlayers")
                .Produces<GetAllClubsWithPlayersResponse>(StatusCodes.Status200OK);
        }
    }
}
