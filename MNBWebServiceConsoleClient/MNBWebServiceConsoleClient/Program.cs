using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MNBWebServiceConsoleClient.MNBArfolyamServiceReference;

namespace MNBWebServiceConsoleClient
{
    public class Program
    {
        private static void Main(string[] args)
        {
            MNBArfolyamServiceSoapClient client = new MNBArfolyamServiceSoapClient();
            String currentExchangeRates = client.GetCurrentExchangeRates();
            XDocument doc = XDocument.Parse(currentExchangeRates);
            // Console.WriteLine(doc.ToString());
            XElement currentDay = doc.Root.Descendants("Day").First();
            // Console.WriteLine(currentDay.ToString());
            XElement eurEchangeRate = currentDay.Descendants("Rate").Where(x => ((String)x.Attribute("curr")).Equals("EUR") ).First();
            // Console.WriteLine(eurEchangeRate.ToString());
            double eur2huf = Double.Parse(eurEchangeRate.Value);
            Console.WriteLine("EUR 2 HUF: " + eur2huf);
            String value = doc.Root.Descendants("Rate").Where(x => ((String)x.Attribute("curr")).Equals("EUR")).First().Value;
            Console.WriteLine("EUR 2 HUF: " + value);

            String demo = client.GetExchangeRates("2004-07-14", "2004-07-16", "EUR,USD");
            XDocument docDemo = XDocument.Parse(demo);
            Console.WriteLine(docDemo.ToString());
        }
    }
}
