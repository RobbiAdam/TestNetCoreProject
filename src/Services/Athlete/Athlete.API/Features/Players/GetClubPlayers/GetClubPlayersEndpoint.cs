namespace Athlete.API.Features.Players.GetClubPlayers
{
    public record GetClubPlayersRequest(string ClubName);
    public record GetClubPlayersResponse(int PlayerCount, IEnumerable<Player> Players);

    public class GetClubPlayersEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/players/club/{clubName}", async (string clubName, ISender sender) =>
            {
                var query = new GetClubPlayersQuery(clubName);
                var result = await sender.Send(query);
                var response = result.Adapt<GetClubPlayersResponse>();
                return Results.Ok(response);
            })
                .WithName("GetClubPlayers")
                .Produces<GetClubPlayersResponse>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status400BadRequest);
        }
    }
}