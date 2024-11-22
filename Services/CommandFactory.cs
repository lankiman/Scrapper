﻿using Scrapper.Interfaces;
using Scrapper.Models;
using System.Reflection;


namespace Scrapper.Services
{
    internal class CommandFactory(string commandName)
    {
        private IReadOnlyDictionary<string, CommandsGraph> _commands = PoplulateDictionaries.Commands;
        private string _commandName;
        private string[] _commandFlags;


        public CommandFactory(string commandName, string[] commandFlags) : this(commandName)
        {
            _commandName = commandName;
            _commandFlags = commandFlags;
        }


        public ICommand CreateCommand()
        {
            if (!_commands.ContainsKey(commandName))
            {
                throw new ArgumentException($"Invalid Command ${commandName}, see --help for list of avaliable commands");
            }

            if (_commandFlags != null && _commandFlags.Length != 0)
            {
                foreach (string flag in _commandFlags)
                {
                    if (!_commands[commandName].Flags.Contains(flag))
                    {
                        throw new ArgumentException($"Invalid Flag ${flag} for Command ${commandName}, see {commandName} --help for list of apprpriate flags");
                    }
                }
            }



            Type? commandType = Assembly.GetExecutingAssembly()
                              .GetType($"Scrapper.Commands.{_commands[commandName].Action}");

            var command = Activator.CreateInstance(commandType);
            return (ICommand)command!;


        }
    }
}
