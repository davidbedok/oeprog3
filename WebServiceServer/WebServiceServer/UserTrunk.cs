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
    public class UserTrunk
    {
         
        private List<User> users;
        private IStoreDatasource datasource;


        public List<User> Items
        {
            get { return this.users; }
        }

        public User[] ItemsArray
        {
            get
            {
                User[] ret = new User[this.users.Count];
                int i = 0;
                foreach (User item in this.users)
                {
                    ret[i++] = item;
                }
                return ret;
            }
        }

        public UserStruct[] ItemsArrayStruct
        {
            get
            {
                UserStruct[] ret = new UserStruct[this.users.Count];
                int i = 0;
                foreach (User item in this.users)
                {
                    ret[i].id = item.Id;
                    ret[i].loginname = item.LoginName;
                    ret[i].password = item.Password;
                    ret[i].name = item.Name;
                    i++;
                }
                return ret;
            }
        }

        public UserTrunk( IStoreDatasource datasource )
        {
            this.datasource = datasource;
            this.users = this.datasource.LoadUsers();
        }

        public int identify(string loginname, string password)
        {
            int ret = -1;
            foreach (User item in this.users)
            {
                if (item.LoginName.Equals(loginname))
                {
                    if (item.Password.Equals(password))
                    {
                        ret = item.Id;
                    }
                }
            }
            return ret;
        }

        public User getUser(int id)
        {
            User ret = null;
            foreach (User item in this.users)
            {
                if (item.Id == id)
                {
                    ret = item;
                }
            }
            return ret;
        }


    }
}
