using Scrapper.Interfaces;
using Scrapper.Models;
using System.Reflection;


namespace Scrapper.Services
{
    internal class CommandFactory(ParsedCommand command)
    {
        private ParsedCommand _command = command;
        public ICommand CreateCommand()
        {
            Type? commandType = Assembly.GetExecutingAssembly()
                              .GetType($"Scrapper.Commands.{_command.Command}");

            var command = Activator.CreateInstance(commandType);
            return (ICommand)command!;


        }
    }
}
