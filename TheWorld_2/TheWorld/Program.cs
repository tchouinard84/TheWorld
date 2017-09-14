using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace TheWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()   // tells the kind of web server to use
                .UseContentRoot(Directory.GetCurrentDirectory())    // where the content to be delivered exists
                .UseIISIntegration()    
                .UseStartup<Startup>()  // what class to use
                .UseApplicationInsights()   // for telemetry
                .Build();

            host.Run();
        }
    }
}
