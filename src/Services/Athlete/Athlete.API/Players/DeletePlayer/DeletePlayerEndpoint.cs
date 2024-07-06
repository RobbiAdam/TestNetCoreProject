namespace Athlete.API.Players.DeletePlayer
{
    public record DeletePlayerResponse(bool IsSuccess);


    public class DeletePlayerEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/api/players/{id}", async (int id, ISender sender) =>
            {
                var result = await sender.Send(new DeletePlayerCommand(id));
                var response = result.Adapt<DeletePlayerResponse>();
                return Results.Ok(response);
            })
                .WithName("DeletePlayer")
                .Produces<DeletePlayerResponse>(StatusCodes.Status200OK)
                .ProducesProblem(StatusCodes.Status400BadRequest)
                .ProducesProblem(StatusCodes.Status404NotFound);
        }
    }
}
