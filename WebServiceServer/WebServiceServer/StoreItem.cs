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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WebServiceServer
{
    [Serializable()]
    public class StoreItem : ISerializable
    {
        public static readonly string CURRENCY = "HUF";

        private int id;
        private string name;
        private int price;
        private string description;
        private int num;

        public StoreItem()
        {
            this.id = -1;
            this.name = "";
            this.price = 0;
            this.description = "";
            this.num = 0;
        }

        public StoreItem(int id, string name, int price, string description, int num)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.description = description;
            this.num = num;
        }

        public StoreItem(SerializationInfo info, StreamingContext ctxt)
        {
            this.id = (int)info.GetValue("id", typeof(int));
            this.name = (string)info.GetValue("name", typeof(string));
            this.price = (int)info.GetValue("price", typeof(int));
            this.description = (string)info.GetValue("description", typeof(string));
            this.num = (int)info.GetValue("num", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("id", this.id);
            info.AddValue("name", this.name);
            info.AddValue("price", this.price);
            info.AddValue("description", this.description);
            info.AddValue("num", this.num);
        }

        public int Id
        {
            get { return this.id; }
        }

        public string Name
        {
            get { return this.name; }
        }

        public int Price
        {
            get { return this.price; }
        }

        public string Description
        {
            get { return this.description; }
        }

        public int Num
        {
            get { return this.num; }
            set { this.num = value; }
        }


        public override string ToString()
        {
            return this.name + " [" + this.id + "] " + this.price + " " + StoreItem.CURRENCY;
        }

    }
}
