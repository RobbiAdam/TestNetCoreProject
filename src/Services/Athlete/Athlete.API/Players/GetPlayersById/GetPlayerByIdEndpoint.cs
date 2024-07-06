namespace Athlete.API.Players.GetPlayersById
{
    public record GetPlayerByIdResponse(
        Player Player);
    public class GetPlayerByIdEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/players/{id}", async (int id, ISender sender) =>
            {
                var query = new GetPlayerByIdQuery(id);
                var result = await sender.Send(query);
                var response = result.Adapt<GetPlayerByIdResponse>();

                return Results.Ok(response);
            })
                .WithName("GetPlayerById")
                .Produces<GetPlayerByIdResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status404NotFound)
                .ProducesProblem(StatusCodes.Status500InternalServerError);
        }
    }
}
