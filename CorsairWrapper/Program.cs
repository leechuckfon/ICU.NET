using Corsair.NET.Corsair;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading;

namespace CorsairWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            HostBuilder builder = new HostBuilder();

            builder.ConfigureServices(x =>
            {
                x.AddLogging(y => y.AddConsole());
                x.AddHostedService<CorsairService>();
            });

            builder.Build().Run();
        }
    }
}
