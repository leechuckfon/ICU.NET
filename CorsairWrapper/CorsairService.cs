using Corsair.NET.Corsair;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CorsairWrapper
{
    public class CorsairService : BackgroundService
    {
        CorsairSessionState currentState = CorsairSessionState.CSS_Invalid;
        private readonly ILogger<CorsairService> _logger;

        public CorsairService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CorsairService>();
        }

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
                await Task.Delay(100);
            }


            var response = CorsairSDK.GetDevices();

            var main = response.FirstOrDefault();

            var positions = CorsairSDK.CorsairGetLedPositions(main.id);

            positions = positions.OrderBy(x => x.cx).ThenBy(x => x.cy);

            foreach (var pos in positions)
            {
                _logger.LogInformation($"{pos.ledId}: {pos.cx} {pos.cy}");
            }

            var columns = positions.Select(x => x.cx).Distinct();`                                                                                                                                                                                                  
            var rows = positions.Select(x => x.cy).Distinct();

            var colors = CorsairSDK.CorsairGetLedColors(main.id, positions.ToArray());

            var color = ColorCycle.Blue;

            var limit = positions.Count() % 10 == 0 ?  positions.Count() / 10 : (positions.Count() / 10) + 1;

            var count = 0;

            var newColors = new List<CorsairLedColor>();

            while (true) {
                foreach (CorsairLedId_Keyboard a in Enum.GetValues(typeof(CorsairLedId_Keyboard)))
                {
                    var toAddColors = GetNewColorArray(color, colors, count, a);

                    foreach (var toColor in toAddColors)
                    {
                        var found = newColors.FindIndex(x => x.id == toColor.id);
                        if (found == -1)
                        {
                            newColors.Add(toColor);
                        } else
                        {
                            newColors.RemoveAt(found);
                            newColors.Insert(found, toColor);
                        }
                    }

                    color += 1;

                    if ((int)color == 3)
                    {
                        color = ColorCycle.Red;
                    }

                    var result = CorsairSDK.CorsairSetLedsColors(main.id, newColors.ToArray());

                    count = count + 1 > limit ? 0 : count + 1;

                    await Task.Delay(100);
                }
            }
        }

        public static CorsairLedColor[] GetNewColorArray(ColorCycle cycle, CorsairLedColor[] oldColors, int count, CorsairLedId_Keyboard key)
        {
            Random r = new Random();
            var limit = 255;
            var a = r.Next(limit);
            var b = r.Next(limit - a);
            var c = r.Next(limit - a - b);


            switch (cycle)
            {
                case ColorCycle.Blue: return oldColors.Where(x => x.id == (uint)key).Select(x => new CorsairLedColor { b = 255, id = x.id, a = 255 }).ToArray();
                case ColorCycle.Red: return oldColors.Where(x => x.id == (uint)key).Select(x => new CorsairLedColor { r = 255, id = x.id, a = 255 }).ToArray();
                case ColorCycle.Green: return oldColors.Where(x => x.id == (uint)key).Select(x => new CorsairLedColor { g = 255, id = x.id, a = 255 }).ToArray();
                default: return oldColors.Where(x => x.id == (uint)key).Select(x => new CorsairLedColor { b = (byte)a, g = (byte)b, r = (byte)b, id = x.id, a = 255 }).ToArray();
            }

        }
    }

    public enum ColorCycle : int
    {
        Red = 0,
        Green = 1,
        Blue = 2
    }
}
