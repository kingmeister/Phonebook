using PhonebookServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Configuration;

namespace PhonebookServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseAdress = ConfigurationManager.AppSettings["BaseAdress"];

            var config = new HttpSelfHostConfiguration(baseAdress);

            config.Routes.MapHttpRoute(  
                "API Default", "api/{controller}/{action}/{id}",
                new { id = RouteParameter.Optional });

            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                Console.WriteLine("Server working");
                Console.ReadLine();
            }
        }
        
    }
}
