namespace Scrapper.Models
{
    internal class CommandsGraph
    {
        public string Action { get; set; }

        public string Description { get; set; }

        public HashSet<string> Flags { get; set; }

        public bool RequiresArguments { get; set; }

        public int MinArgs { get; set; }

        public int MaxArgs { get; set; }

        //public List<ArgumentsGraph> Arguments { get; set; }
    }
}
