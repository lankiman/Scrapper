
using Scrapper.Models;
using Scrapper.Utils;
using System.Text.Json;

namespace Scrapper.Services
{
    internal static class PoplulateDictionaries
    {
        public static IReadOnlyDictionary<string, CommandsGraph> Commands { get; private set; }
        public static IReadOnlyDictionary<string, string> Flags { get; private set; }
        static PoplulateDictionaries()
        {

            var commandsJson = Helpers.GetEmbeddedResourceContent("Scrapper.Resources.commands.json");
            var flagsJson = Helpers.GetEmbeddedResourceContent("Scrapper.Resources.flags.json");

            Commands = JsonSerializer.Deserialize<Dictionary<string, CommandsGraph>>(commandsJson)!;

            Flags = JsonSerializer.Deserialize<Dictionary<string, string>>(flagsJson)!;
        }
    }
}

