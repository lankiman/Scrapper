using Scrapper.Models;

namespace Scrapper.Services
{
    internal class HelpShower
    {

        private IReadOnlyDictionary<string, CommandsGraph> _commands = PoplulateDictionaries.Commands;

        private IReadOnlyDictionary<string, FlagsGraph> _flags = PoplulateDictionaries.Flags;

        private readonly int _columnWidth = 18;
        public void ShowGeneral()
        {
            Console.WriteLine("\nUsage:scrapper [command] <options> argument\n");
            Console.WriteLine("To Execute a web scrapping operation\n");

            Console.WriteLine("Command Line Options:\n");

            foreach (var flag in _flags)
            {
                if (flag.Value.Class == "general")
                {
                    if (flag.Value.ShortForm != null)
                    {
                        Console.Write($"{flag.Key}|{flag.Value.ShortForm}");
                        Console.SetCursorPosition(_columnWidth, Console.CursorTop);
                        Console.WriteLine(flag.Value.Description);
                    }
                    else
                    {
                        Console.Write($"{flag.Key}");
                        Console.SetCursorPosition(_columnWidth, Console.CursorTop);
                        Console.WriteLine(flag.Value.Description);
                    }
                }
            }

            Console.WriteLine("\nAvailable Commands:\n");

            foreach (var command in _commands)
            {
                Console.Write($"{command.Key}");
                Console.SetCursorPosition(_columnWidth, Console.CursorTop);
                Console.WriteLine(command.Value.Description);
            }

            Console.WriteLine("\nsee command --help for details about a specific command\n");

        }

        public void ShowSpecificCommandHelp(CommandsGraph command)
        {
            var requiredArguments = command.Arguments.Where(arg => arg.Required == true).Select(arg => arg.Name);

            Console.WriteLine("Description:");
            Console.WriteLine($"Scrapper {command.Action.ToLower()} command".PadRight(5));

            Console.WriteLine("\nUsage:");
            Console.WriteLine($"scrapper {command.Action.ToLower()} [options] <CommandArguments>".PadRight(5));

            Console.WriteLine("\nInfo:");

            Console.WriteLine($"{command.Action.ToLower()} takes a minimum of ${command.MinArgs} {(command.MinArgs < 2 ? "argument" : "arguments")}".PadRight(5));

            Console.WriteLine($"{command.Action.ToLower()} takes a maximum of ${command.MinArgs} {(command.MaxArgs < 2 ? "argument" : "arguments")}".PadRight(5));

            Console.WriteLine($"Required Arguments: {string.Join(",", requiredArguments)}");
        }
    }
}
