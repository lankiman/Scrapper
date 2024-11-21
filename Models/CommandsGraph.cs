namespace Scrapper.Models
{
    internal class CommandsGraph
    {
        public string Command { get; set; }

        public string Action { get; set; }

        public string Description { get; set; }

        public List<string> Flags { get; set; }

    }
}
