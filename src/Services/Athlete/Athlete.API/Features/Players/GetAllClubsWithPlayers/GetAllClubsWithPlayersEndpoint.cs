using Athlete.API.Features.GetClubsWithPlayers;

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
                var result = await sender.Send(new GetClubsWithPlayersQuery());
                var response = result.Adapt<GetAllClubsWithPlayersResponse>();
                
                return Results.Ok(response);
            })
                .WithName("GetClubsWithPlayers")
                .Produces<GetAllClubsWithPlayersResponse>(StatusCodes.Status200OK);
        }
    }
}
