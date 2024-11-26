using Scrapper.Models;

namespace Scrapper.Services
{
    internal class HelpShower
    {

        private IReadOnlyDictionary<string, CommandsGraph> _commands = PoplulateDictionaries.Commands;

        private IReadOnlyDictionary<string, FlagsGraph> _flags = PoplulateDictionaries.Flags;
        public void ShowGeneral()
        {
            Console.WriteLine("\nUsage:scrapper [command] <options> argument\n");
            Console.WriteLine("To Execute a web scrapping operation\n");

            Console.WriteLine("Command Line Options:\n");

            int longestFlag = _flags.Max(flag => (flag.Key + flag.Value.ShortForm).Length);

            Console.WriteLine(longestFlag);

            foreach (var flag in _flags)
            {
                if (flag.Value.Class == "general")
                {
                    if (flag.Value.ShortForm != null)
                    {

                        Console.WriteLine($"{flag.Key}|{flag.Value.ShortForm.PadRight(2)}  {flag.Value.Description,-10}");
                    }
                }
            }

        }
    }
}
