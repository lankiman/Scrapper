
using Scrapper.Models;
using Scrapper.Utils;
using System.Text.Json;

namespace Scrapper.Services
{
    internal static class PoplulateDictionaries
    {
        public static readonly Dictionary<string, CommandsGraph> Commands;

        static PoplulateDictionaries()
        {

            var commandsJson = Helpers.GetEmbeddedResourceContent("Scrapper.Resources.commands.json");

            Commands = JsonSerializer.Deserialize<Dictionary<string, CommandsGraph>>(commandsJson)!;
        }


    }

}

