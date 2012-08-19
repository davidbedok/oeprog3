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
    public class User : ISerializable 
    {

        private int id;
        private string loginname;
        private string password;
        private string name;

        public UserStruct AsStruct
        {
            get {
                UserStruct ret;
                ret.id = this.id;
                ret.loginname = this.loginname;
                ret.password = this.password;
                ret.name = this.name;
                return ret;
            }
        }

        public User()
        {
            this.id = -1;
            this.loginname = "";
            this.password = "";
            this.name = "";
        }

        public User(int id, string loginname, string password, string name)
        {
            this.id = id;
            this.loginname = loginname;
            this.password = password;
            this.name = name;
        }

        public User(SerializationInfo info, StreamingContext ctxt)
        {
            this.id = (int)info.GetValue("id", typeof(int));
            this.loginname = (string)info.GetValue("loginname", typeof(string));
            this.password = (string)info.GetValue("password", typeof(string));
            this.name = (string)info.GetValue("name", typeof(string));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("id", this.id);
            info.AddValue("loginname", this.loginname);
            info.AddValue("password", this.password);
            info.AddValue("name", this.name);
        }

        public int Id
        {
            get { return this.id; }
        }

        public string LoginName
        {
            get { return this.loginname; }
        }

        public string Password
        {
            get { return this.password; }
        }

        public string Name
        {
            get { return this.name; }
        }

    }
}
