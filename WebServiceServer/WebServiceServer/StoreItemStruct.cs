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

namespace WebServiceServer
{ 
    public struct StoreItemStruct
    {
        public int id;
        public string name;
        public int price;
        public string description;
        public int num;

        public override string ToString()
        {
            return this.name;
        }
    }
}
