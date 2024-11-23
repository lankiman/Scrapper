using Scrapper.Interfaces;


namespace Scrapper.Commands
{
    internal class Scrape : ICommand
    {
        public void Execute()
        {
            Console.WriteLine("this command has exectued");
        }
    }
}
