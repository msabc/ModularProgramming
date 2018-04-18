using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebClient
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            HostingEnvironment.RegisterVirtualPathProvider(new Hosting.CustomVirtualPathProvider());
            RegisterRoutes(RouteTable.Routes);
        }

        private void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("", 
                "Modules/{module}/", 
                $"~/{Hosting.HostingUtils.VirtualLocation}/{{module}}");
        }
    }
}