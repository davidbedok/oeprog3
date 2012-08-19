using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

namespace WebServiceServer
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class Service1 : System.Web.Services.WebService
    {

        private IStoreDatasource datasource;

        public Service1()
        {
            this.datasource = new FileStoreDatasource();
        }

        [WebMethod]
        public string Ping()
        {
            return "Pong";
        }

        [WebMethod]
        public int Login( string loginname, string password )
        {
            UserTrunk trunk = new UserTrunk(this.datasource);
            return trunk.identify(loginname, password);
        }

        [WebMethod]
        public UserStruct GetLoginUser(int id)
        {
            UserTrunk trunk = new UserTrunk(this.datasource);
            return trunk.getUser(id).AsStruct;
        } 

        [WebMethod]
        public StoreItemStruct[] List()
        {
            return (new Store(this.datasource)).ItemsArrayStruct;
        }

        [WebMethod]
        public bool Buy(int id, int count)
        {
            return (new Store(this.datasource)).Buy(id,count);
        }

        [WebMethod]
        public int BuyByName(string name, int count)
        {
            Store iStore = new Store(this.datasource);
            int ret = iStore.Buy(name, count);
            if (ret > 0)
            {
                this.datasource.SaveStoreItems(iStore.Items);
            }
            return ret;
        }

    }
}
