using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace IntegratedQueryDemo
{
    public class XmlTest
    {

        private XDocument xmlDoc;

        public XmlTest( String xmlFile )
        {
            this.xmlDoc = XDocument.Load(xmlFile);
        }

        public String getNameByEmail(String email)
        {
            Console.WriteLine("\n\n# Get name by email (" + email + ")");
            List<XElement> names = xmlDoc.Root.Descendants("worker").Where(x => ((String)x.Element("mail")).Equals("bkiss.judit@nik.uni-obuda.hu")).Select(x => x.Element("name")).ToList();
            return printElements(names);
        }

        public String getAnonymousClassByLimitAndDivider(int limit, int divider)
        {
            var elements = xmlDoc.Root.Descendants("worker").Where(x => (int)x.Element("number") > limit && (int)x.Attribute("id") % divider == 1).Select(x => new { id = (int)x.Attribute("id"), name = (String)x.Element("name"), number = (int)x.Element("number") }).ToList();

            StringBuilder result = new StringBuilder();
            foreach (var element in elements)
            {
                result.AppendLine(element.ToString());
            }
            return "\n\n# Get anonymous class by limit and divider (" + limit + ", "+divider+")\n" + result.ToString();
        }

        private String printElements(List<XElement> elements )
        {
            StringBuilder result = new StringBuilder(50);
            foreach (XElement element in elements)
            {
                result.AppendLine(element.Value);
            }
            return result.ToString();
        }

    }
}
