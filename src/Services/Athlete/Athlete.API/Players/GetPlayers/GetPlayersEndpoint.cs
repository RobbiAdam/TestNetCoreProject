namespace Athlete.API.Players.GetPlayers
{
    public record GetPlayersResponse(
        IEnumerable<Player> Players);
    public class GetPlayersEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/players", async (ISender sender) =>
            {
                var players = await sender.Send(new GetPlayersQuery());
                return Results.Ok(players);
            })
                .WithTags("GetPlayers");

        }
    }
}
