using Scrapper.Interfaces;
using Scrapper.Models;


namespace Scrapper.Services
{
    internal class CommandFactory
    {
        private IReadOnlyDictionary<string, CommandsGraph> _commands = PoplulateDictionaries.Commands;
        private string _commandName;
        private string[] _flags;

        public CommandFactory(string commandName, string[] commandflags)
        {


        }


        public ICommand CreateCommand()
        {

        }
    }
}
