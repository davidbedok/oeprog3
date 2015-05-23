using Ionic.Zip;
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

namespace PasswordCracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            XDocument oeXML = XDocument.Load("people.xml");
            var result = oeXML.Root.Descendants("person").Where(x => x.Element("name").Value.Contains("Dr.") 
                && x.Element("dept").Value.Contains("Alkalmazott Matematikai Intézet"))
                .Select(x => x.Element("room").Value).ToList();

            Thread thread = new Thread(Cracker);
            thread.Start(result);
        }

        private void Cracker(Object result)
        {

            foreach (string pw in (List<string>)result)
            {
                using (ZipFile zip = ZipFile.Read("info.zip"))
                {
                    try
                    {
                        ZipEntry entry = zip.Entries.First();
                        entry.ExtractWithPassword(pw);
                        MessageBox.Show("A jelszó: " + pw);
                    }
                    catch (BadPasswordException err)
                    {
                        Dispatcher.Invoke(() => lvEredmeny.Items.Add(pw));                        
                    }
                }
            }
        }
    }
}
