using System;

namespace Webscrape
{
    class Program
    {
        static void Main(string[] args)
        {
            Scraper scraper = new Scraper("https://www.seetickets.com/search?BrowseOrder=Relevance&q=&s=&se=false&c=3&dst=&dend=&l");
            scraper.WebDataScrap();
        }
    }
}
