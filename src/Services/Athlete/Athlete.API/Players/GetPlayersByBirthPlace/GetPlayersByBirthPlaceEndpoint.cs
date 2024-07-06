namespace Athlete.API.Players.GetPlayersByBirthPlace
{
    public record GetPlayersByBirthPlaceResponse(
        IEnumerable<Player> Players);
    public class GetPlayersByBirthPlaceEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/players/birthplace/{birthPlace}", async (
                string birthPlace, ISender sender) =>
            {
                var query = new GetPlayersByBirthPlaceQuery(birthPlace);
                var result = await sender.Send(query);
                var response = result.Adapt<GetPlayersByBirthPlaceResponse>();

                return Results.Ok(response);
            })
            .WithName("GetPlayersByBirthPlace")
            .Produces<GetPlayersByBirthPlaceResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status400BadRequest);
        }
    }
}
