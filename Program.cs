using System;

namespace Webscrape
{
    class Program
    {
        static void Main(string[] args)
        {
            Scraper scraper = new Scraper();
            Console.WriteLine("///////////CSV/////////////////");
            scraper.ScrapeToCSV();
            Console.WriteLine("///////////JSON/////////////////");
            scraper.ScrapeToJSON();
            Console.WriteLine("///////////XML/////////////////");
            scraper.ScrapeToXML();
        }
    }
}
