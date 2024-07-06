namespace Athlete.API.Settings
{
    public class SettingsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("api/settings", (IConfiguration config)=>
            {
                var connectionString = config.GetConnectionString("Database");
                return Results.Ok(new { ConnectionString = connectionString });
            })
                .WithName("GetConnectionString")
                .Produces(StatusCodes.Status200OK);
        }
    }
}
