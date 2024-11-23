namespace Scrapper.Models
{
    internal class CommandsGraph
    {


        public string Action { get; set; }

        public string Description { get; set; }

        public HashSet<string> Flags { get; set; }

    }
}
