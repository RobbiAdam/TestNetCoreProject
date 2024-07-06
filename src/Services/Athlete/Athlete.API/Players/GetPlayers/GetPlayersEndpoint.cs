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
                    var result = await sender.Send(new GetPlayersQuery());
                    var response = result.Adapt<GetPlayersResponse>();
                    return Results.Ok(response);
                })
                .WithName("GetPlayers")
                .Produces<GetPlayersResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest);
        }
    }
}
