
using Scrapper.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var userInput = Console.ReadLine();
        var test = new CommandFactory(userInput);

        test.CreateCommand().Execute();

        //Console.WriteLine(PoplulateDictionaries.Commands["scrape"].Action);


    }
}