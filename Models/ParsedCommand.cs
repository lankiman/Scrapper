namespace Scrapper.Models
{
    internal class ParsedCommand
    {
        public string Command { get; set; }

        public string[] Flags { get; set; }

        public string[] Arguments { get; set; }
    }
}
