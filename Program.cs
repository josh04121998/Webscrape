using System;

namespace Webscrape
{
    class Program
    {
        static void Main(string[] args)
        {
            Scraper scraper = new Scraper("https://www.seetickets.com/search?BrowseOrder=Relevance&q=&s=&se=false&c=3&dst=&dend=&l");
            Console.WriteLine("///////////CSV/////////////////");
            scraper.ScrapeToCSV();
            Console.WriteLine("///////////JSON/////////////////");
            scraper.ScrapeToJSON();
            Console.WriteLine("///////////XML/////////////////");
            scraper.ScrapeToXML();
        }
    }
}
