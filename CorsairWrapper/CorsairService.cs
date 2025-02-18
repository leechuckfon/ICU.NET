using Corsair.NET.Corsair;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CorsairWrapper
{
    public class CorsairService : BackgroundService
    {
        CorsairSessionState currentState = CorsairSessionState.CSS_Invalid;

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var response = CorsairSDK.CorsairConnect((context, eventData) =>
            {
                Console.WriteLine(eventData.state);
                currentState = eventData.state;
            });

            return base.StartAsync(cancellationToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            CorsairSDK.CorsairDisconnect();

            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (currentState != CorsairSessionState.CSS_Connected)
            {

            }

            var response = CorsairSDK.CorsairGetDeviceCount();

            foreach (var device in response)
            {
                Console.WriteLine(device.serial);
                Console.WriteLine(device.ledsCount);
            }
        }
    }
}
