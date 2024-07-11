namespace Athlete.API.Features.Players.CreatePlayer
{
    public record CreatePlayerRequest(
        string Name, int Age, string BirthPlace);
    public record CreatePlayerResponse(Player player);

    public class CreatePlayerEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/players", async (CreatePlayerRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreatePlayerCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CreatePlayerResponse>();
                return Results.Created($"/players/{response.player.Id}", response);
            })
                .WithName("CreatePlayer")
                .Produces<CreatePlayerResponse>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest);
        }
    }
}
