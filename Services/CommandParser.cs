namespace Scrapper.Services
{
    internal class CommandParser(string[] arguments)
    {
        public string[] Parse()
        {
            var command = arguments[0];

            if (command == "--help" || command == "-h")
            {
                var helpShower = new HelpShower();
                helpShower.ShowGeneral();
                return null;
            }

            return arguments;
        }
    }
}
