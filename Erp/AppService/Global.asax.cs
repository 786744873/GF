using AppService.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace AppService
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteMethod<Messages>("Messages");
            RouteMethod<CustomerManager>("CustomerManager");
            RouteMethod<Case>("Case");
            RouteMethod<BaseInfoDoc>("BaseInfoDoc");
            RouteMethod<ProcessManager>("ProcessManager");
            RouteMethod<SystemManager>("SystemManager");
            RouteMethod<Form>("Form"); 
            RouteMethod<FileInfo>("FileInfo");
        }

        protected void RouteMethod<T>(string urlname)
        {
            RouteTable.Routes.Add(new ServiceRoute(urlname, new WebServiceHostFactory(), typeof(T)));
        }
    }
}