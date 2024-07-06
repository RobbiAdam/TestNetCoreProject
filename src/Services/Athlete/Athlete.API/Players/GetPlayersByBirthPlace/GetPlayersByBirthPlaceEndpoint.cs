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
                var response = await sender.Send(query);
                return Results.Ok(response);
            })
            .WithName("GetPlayersByBirthPlace");
        }
    }
}
