
using Scrapper.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var userInput = Console.ReadLine();

        var parsedCommand = new CommandParser([userInput]);

        parsedCommand.Parse();

        //Console.WriteLine(PoplulateDictionaries.Commands["scrape"].Action);


    }
}