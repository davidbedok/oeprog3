using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace RSSReaderSpace
{
  
    public partial class ReaderWindow : Window
    {
       
        private static char KEYWORD_SEPARATOR = ',';

        public ReaderWindow()
        {
            InitializeComponent();
        }

        private void Go_Click(object sender, RoutedEventArgs e)
        {
            List<String> keywords = this.getKeywords();
            this.startNewRssProcessorThreadString("index.xml", "http://users.nik.uni-obuda.hu/cseri/hp/index.xml", keywords);
            this.startNewRssProcessorThreadString("origo.xml", "http://users.nik.uni-obuda.hu/cseri/hp/origo.xml", keywords);
        }

        private List<String> getKeywords()
        {
            return this.keywordsTextBox.Text.Split(KEYWORD_SEPARATOR).ToList();
        }

        private void startNewRssProcessorThreadString( String source, String rssUrl, List<String> keywords)
        {
            RSSProcessor processor = new RSSProcessor(source, rssUrl, keywords);
            processor.articleHandler += rssProcessorFinishEventHandler;
            processor.errorHandler += rssProcessorErrorEventHandler;
            Thread thread = new Thread(processor.run);
            thread.Start();
        }

        private void rssProcessorErrorEventHandler(String source, String message)
        {
            Dispatcher.Invoke(() => MessageBox.Show("Error: " + message));
        }

        private void rssProcessorFinishEventHandler(String fileCache, String article)
        {
            Dispatcher.Invoke(() => this.resultListView.Items.Add(article));
        }

    }
}
