namespace Athlete.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAthleteAPI(this IServiceCollection services)
        {
            services.AddMediatR(opt =>
            {
                opt.RegisterServicesFromAssembly(typeof(Program).Assembly);

            });

            services.AddDbContext<PlayerContext>(opt =>
            {
                opt.UseInMemoryDatabase("Database");
            });

            services.AddCarter();

            return services;
        }
    }
}
