using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Webscrape
{
    public class Scraper
    {
        private string url;
        private static readonly Regex _classNameRegex = new Regex(@"\bfloat\b", RegexOptions.Compiled);
        public Scraper(string WebUrl)
        {
            url = WebUrl;
        }

        private List<TicketDataDto> WebDataScrape()
        {
            List<TicketDataDto> listOfEvents = new List<TicketDataDto>();
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(url);

                var EventName = doc.DocumentNode.SelectNodes("//span[@class='g-blocklist-sub-text ']");
                foreach (var item in EventName)
                {
                    var splitWords = Regex.Split(item.InnerText, "\r\n\r\n");

                    listOfEvents.Add
                    (
                    new TicketDataDto
                    {
                        EventName = string.Concat(splitWords[0].Where(c => !char.IsWhiteSpace(c))),
                        Venue = string.Concat(splitWords[1].Where(c => !char.IsWhiteSpace(c))),
                        Date = string.Concat(splitWords[2].Where(c => !char.IsWhiteSpace(c)))
                    });
                };
            }
            catch(Exception e)
            {
                Console.WriteLine(string.Format("no info found with error: {e}"), e);
            }
            return listOfEvents;
        }

        public void ScrapeToJSON()
        {
            List<TicketDataDto> listOfEvents = WebDataScrape();
            Console.WriteLine(JsonConvert.SerializeObject(listOfEvents));
        }

        public void ScrapeToXML()
        {

            using (var stringwriter = new System.IO.StringWriter())
            {
                List<TicketDataDto> listOfEvents = WebDataScrape();
                var serializer = new XmlSerializer(listOfEvents.GetType());
                serializer.Serialize(stringwriter, listOfEvents);
                Console.WriteLine(stringwriter.ToString());
            }
        }

        public void ScrapeToCSV()
        {
            List<TicketDataDto> listOfEvents = WebDataScrape();
            var sb = new StringBuilder();
            foreach (var data in listOfEvents)
            {
                sb.AppendLine(data.EventName + ", " + data.Venue + ", " + data.Date + ", " +data.ImageUrl + ", " + data.Status);
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
