
using Scrapper.Services;


internal class Program
{
    private static void Main(string[] args)
    {
        var userInput = Console.ReadLine();
        var temp = userInput.Split(new[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        var parsedCommand = new CommandParser(temp).Parse();

        if (parsedCommand != null)
        {
            var command = new CommandFactory(parsedCommand);
            command.CreateCommand().Execute();
        }
    }
}