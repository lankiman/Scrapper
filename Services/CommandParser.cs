using Scrapper.Models;

namespace Scrapper.Services
{
    internal class CommandParser(string[] arguments)
    {

        private IReadOnlyDictionary<string, CommandsGraph> _commands = PoplulateDictionaries.Commands;

        private CommandsGraph ValidateCommand(string command)
        {

            if (command == "--help" || command == "-h")
            {
                var helpShower = new HelpShower();
                helpShower.ShowGeneral();
            }

            if (command != "--help" || command != "-h")

            {
                if (!_commands.ContainsKey(command))
                {
                    throw new ArgumentException($"Invalid command: {command}, see scrapper --help for list of commands");
                }
            }
            return _commands[command];
        }

        private void ValidateFlags(CommandsGraph command, string[] flags)
        {
            var validFlags = command.Flags;

            foreach (var flag in flags)
            {
                if (!validFlags.Contains(flag))
                {
                    throw new ArgumentException($"Invalid flag {flag} for command {command}, see command --help for list of available flags for command");
                }
            }
        }
        private void ValidateArguments(CommandsGraph command, string[] arguments)
        {
            //if (command.RequiresArguments)
            //{
            //    if (arguments.Length < command.MinArgs)
            //        throw new ArgumentException($"Insufficient arguments. Minimum {command.MinArgs} required.");

            //    if (arguments.Length > command.MaxArgs)
            //        throw new ArgumentException($"Too many arguments. Maximum {command.MaxArgs} allowed.");
            //}
        }

        public ParsedCommand Parse()
        {
            if (arguments.Length == 0)
            {
                var helpShower = new HelpShower();
                helpShower.ShowGeneral();
                throw new ArgumentNullException("No command provided");
            }
            try
            {
                var command = ValidateCommand(arguments[0]);

                var flags = arguments
               .Skip(1)
               .Where(arg => arg.StartsWith("-") || arg.StartsWith("--"))
               .ToArray();

                var commandArguments = arguments
                .Skip(1)
                .Where(arg => !arg.StartsWith("-") && !arg.StartsWith("--"))
                .ToArray();

                ValidateFlags(command, flags);

                ValidateArguments(command, commandArguments);

                return new ParsedCommand
                {
                    Command = command.Action,
                    Flags = flags,
                    Arguments = arguments
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
