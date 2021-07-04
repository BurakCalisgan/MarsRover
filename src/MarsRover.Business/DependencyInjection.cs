using MarsRover.Business.Abstract;
using MarsRover.Business.Concrete;
using MarsRover.Business.Concrete.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace MarsRover.Business
{
    public class DependencyInjection
    {
        public static ServiceProvider Configure()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<ICommand, TurnLeftCommand>();
            services.AddTransient<ICommand, TurnRightCommand>();
            services.AddTransient<ICommand, MoveCommand>();
            services.AddTransient<IRoverCommand, RoverCommand>();
            services.AddTransient<IRoverPosition, RoverPosition>();
            services.AddTransient<IRover, Rover>();
            services.AddTransient<IPlateau, Plateau>();

            return services.BuildServiceProvider();
        }
    }
}
