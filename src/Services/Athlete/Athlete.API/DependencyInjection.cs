using BuildingBlocks.Behaviors;
using BuildingBlocks.Exceptions.Handler;
using FluentValidation;

namespace Athlete.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAthleteAPI(this IServiceCollection services)
        {
            return services
                .AddOpenAPI()
                .AddMediator()
                .AddValidation()
                .AddDatabase()
                .AddExceptionHandling()
                .AddCarter();
        }
        public static IServiceCollection AddOpenAPI(this IServiceCollection services)
        {
            return services
                .AddEndpointsApiExplorer()
                .AddSwaggerGen();
        }

        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            return services.AddMediatR(opt =>
            {
                opt.RegisterServicesFromAssembly(typeof(Program).Assembly);
                opt.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });
        }
        private static IServiceCollection AddValidation(this IServiceCollection services)
        {
            return services.AddValidatorsFromAssembly(typeof(Program).Assembly);
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            return services.AddDbContext<PlayerContext>(opt =>
            {
                opt.UseInMemoryDatabase("Database");
            });
        }

        public static IServiceCollection AddExceptionHandling(this IServiceCollection services)
        {
            return services.AddExceptionHandler<CustomExceptionHandler>();
        }
    }
}
