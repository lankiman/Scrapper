
using Scrapper.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var userInput = Console.ReadLine();

        var parsedCommand = new CommandParser([userInput]).Parse();

        if (parsedCommand != null)
        {
            var command = new CommandFactory(parsedCommand);
            command.CreateCommand().Execute();
        }
    }
}