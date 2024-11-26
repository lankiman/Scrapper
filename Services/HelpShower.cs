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

        }
    }
}
