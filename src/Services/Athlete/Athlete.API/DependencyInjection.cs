namespace Athlete.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAthleteAPI(this IServiceCollection services)
        {
            return services
                .AddMediator()
                .AddDatabase()
                .AddCarter();
        }

        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            return services.AddMediatR(opt =>
            {
                opt.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            return services.AddDbContext<PlayerContext>(opt =>
            {
                opt.UseInMemoryDatabase("Database");
            });
        }
    }
}
