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

namespace WebServiceServer
{
    public class Store
    {
        
        private List<StoreItem> items;
        private IStoreDatasource datasource; 

        public List<StoreItem> Items
        {
            get { return this.items; }
        }

        public StoreItem[] ItemsArray
        {
            get { 
              StoreItem[] ret = new StoreItem[this.items.Count];
              int i = 0;
              foreach (StoreItem item in this.items)
              {
                  ret[i++] = item;
              }
              return ret;
            }
        }

        public StoreItemStruct[] ItemsArrayStruct
        {
            get
            {
                StoreItemStruct[] ret = new StoreItemStruct[this.items.Count];
                int i = 0;
                foreach (StoreItem item in this.items)
                {
                    ret[i].id = item.Id;
                    ret[i].name = item.Name;
                    ret[i].price = item.Price;
                    ret[i].description = item.Description;
                    ret[i].num = item.Num;
                    i++;
                }
                return ret;
            }
        }

        public Store( IStoreDatasource datasource )
        {
            this.datasource = datasource;
            this.items = this.datasource.LoadStoreItems();
        }

        public bool Buy(int id, int count){
            bool ret = false;
            foreach (StoreItem item in this.items)
            {
                if (item.Id.Equals(id))
                {
                    if (item.Num >= count)
                    {
                        item.Num -= count;
                        ret = true;
                    }
                }
            }
            return ret;
        }

        public int Buy(string name, int count)
        {
            int ret = 0;
            foreach (StoreItem item in this.items)
            {
                if (item.Name.Equals(name))
                {
                    if (item.Num >= count)
                    {
                        item.Num -= count;
                        ret = count * item.Price;
                    }
                }
            }
            return ret;
        }

    }
}
