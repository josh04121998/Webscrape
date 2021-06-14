using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Webscrape
{
    public class Scraper
    {
        private string url;

        public Scraper(string WebUrl)
        {
            url = WebUrl;
        }

        public void WebDataScrap()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);

            var EventName = doc.DocumentNode.SelectNodes("//span[@class='g-blocklist-sub-text ']");
            foreach (var item in EventName)
            {
                var splitWords = Regex.Split(item.InnerText, "\r\n\r\n");

                List<TicketDataDto> listOfEvents = new List<TicketDataDto>
                {
                    new TicketDataDto
                    {
                        EventName = string.Concat(splitWords[0].Where(c => !char.IsWhiteSpace(c))),
                        Venue = string.Concat(splitWords[1].Where(c => !char.IsWhiteSpace(c))),
                        Date = string.Concat(splitWords[2].Where(c => !char.IsWhiteSpace(c)))
                    }
                };
            };

        }


        public void ScrapeToJSON()
        {

        }

        public void ScrapeToXML()
        {

        }

        public void ScrapeToCSV()
        {

        }
    }
}
