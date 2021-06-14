using System;
using System.Collections.Generic;

namespace Webscrape
{
    class Program
    {
        static void Main(string[] args)
        {
            Scraper scraper = new Scraper();
            List<TicketDataDto> listOftickets = scraper.Scrape("https://www.seetickets.com/search?BrowseOrder=Relevance&q=&s=&se=false&c=3&dst=&dend=&l");
            Console.WriteLine("///////////CSV/////////////////");
            scraper.ConvertToCSV(listOftickets);
            Console.WriteLine("///////////JSON/////////////////");
            scraper.ConvertToJSON(listOftickets);
            Console.WriteLine("///////////XML/////////////////");
            scraper.ConvertToXML(listOftickets);
        }
    }
}
