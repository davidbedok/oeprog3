using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebServiceServer
{
    public class FileStoreDatasource : IStoreDatasource
    {
        private static readonly char DELIMITER = ';';
        private static readonly string STORE_DIR_NAME = @"e:\workspacecsharp\WebServiceServer\WebServiceServer\resources\";
        private static readonly string STORE_FILE_NAME = "store.dat";
        private static readonly string USER_FILE_NAME = "user.dat";

        public List<StoreItem> LoadStoreItems()
        {
            List<StoreItem> ret = new List<StoreItem>();
            string filename = FileStoreDatasource.STORE_DIR_NAME + FileStoreDatasource.STORE_FILE_NAME;
            string line;
            string[] lineItem;
            try
            {
                StreamReader sr = new StreamReader(File.Open(filename, FileMode.Open));
                line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    lineItem = line.Split(FileStoreDatasource.DELIMITER);
                    if (lineItem.Length == 5)
                    {
                        ret.Add(new StoreItem(
                                Convert.ToInt32(lineItem[0]),
                                lineItem[1],
                                Convert.ToInt32(lineItem[2]),
                                lineItem[3],
                                Convert.ToInt32(lineItem[4])
                            ));
                    }
                }

                sr.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            return ret;
        }

        public void SaveStoreItems(List<StoreItem> items)
        {
            string filename = FileStoreDatasource.STORE_DIR_NAME + FileStoreDatasource.STORE_FILE_NAME;
            try
            {
                TextWriter tw = new StreamWriter(filename);
                foreach (StoreItem item in items)
                {
                    StringBuilder sb = new StringBuilder(100);
                    sb.Append(item.Id).Append(FileStoreDatasource.DELIMITER);
                    sb.Append(item.Name).Append(FileStoreDatasource.DELIMITER);
                    sb.Append(item.Price).Append(FileStoreDatasource.DELIMITER);
                    sb.Append(item.Description).Append(FileStoreDatasource.DELIMITER);
                    sb.Append(item.Num);
                    tw.WriteLine(sb.ToString());
                }      
                tw.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
        }

        public List<User> LoadUsers()
        {
            List<User> ret = new List<User>();
            string filename = FileStoreDatasource.STORE_DIR_NAME + FileStoreDatasource.USER_FILE_NAME;
            string line;
            string[] lineItem;
            try
            {
                StreamReader sr = new StreamReader(File.Open(filename, FileMode.Open));
                line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    lineItem = line.Split(FileStoreDatasource.DELIMITER);
                    if (lineItem.Length == 4)
                    {
                        ret.Add(new User(
                                Convert.ToInt32(lineItem[0]),
                                lineItem[1],
                                lineItem[2],
                                lineItem[3]
                            ));
                    }
                }

                sr.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }
            return ret;
        }


    }
}
