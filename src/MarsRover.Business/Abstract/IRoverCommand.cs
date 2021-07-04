namespace MarsRover.Business.Abstract
{
    public interface IRoverCommand
    {
        IRover Rover { get; set; }
        void AddCommand(ICommand command);
        void ProcessCommands();
    }
}