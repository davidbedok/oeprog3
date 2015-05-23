using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RSSReaderSpace
{

    public delegate void RelevantArticle(String source, String article);
    public delegate void RSSProcessorError(String source, String message);

    public class RSSProcessor
    {
        private static bool OFFLINE_MODE = true;
        private static String CHILD_ELEMENT = "item";
        private static String TITLE_ELEMENT = "title";

        private readonly String source;
        private readonly List<String> keywords;
        private readonly String url;

        public event RelevantArticle articleHandler;
        public event RSSProcessorError errorHandler;

        public RSSProcessor(String source, String url, List<String> keywords)
        {
            this.source = source;
            this.keywords = keywords;
            this.url = url;
        }

        public void run()
        {
            try
            {
                this.process(XDocument.Load( OFFLINE_MODE ? source : url ));
            }
            catch (Exception e)
            {
                if (this.errorHandler != null)
                {
                    this.errorHandler(source, e.Message);
                }
            }       
        }

        private void process(XDocument xdoc)
        {
            List<XElement> children = xdoc.Root.Descendants(CHILD_ELEMENT).ToList();
            foreach (string keyword in this.keywords)
            {
                List<String> relevantTitles = children.Where(x => x.Element(TITLE_ELEMENT).Value.Contains(keyword)).Select(x => x.Element(TITLE_ELEMENT).Value).ToList();
                if (this.articleHandler != null)
                {
                    foreach (String article in relevantTitles)
                    {
                        this.articleHandler(this.source, article);
                    }
                }
            }
            
        }
    }
}
