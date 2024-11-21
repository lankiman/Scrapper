
using Scrapper.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var commandDictionary = PoplulateDictionaries.Commands;

        Console.WriteLine(commandDictionary.Count);

    }
}