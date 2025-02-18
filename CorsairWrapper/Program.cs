using Corsair.NET.Corsair;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

            builder.ConfigureServices(x => x.AddHostedService<CorsairService>());

            builder.Build().Run();


            //var devices = CorsairSDK.CorsairGetDeviceCount();

            Console.WriteLine("Done");
            //SetLedsColorsCallback test = new SetLedsColorsCallback(OnColorsSet);
            //var details = CorsairSDK.CorsairPerformProtocolHandshake();
            //var ledPositions = CorsairSDK.CorsairGetLedPositionsByDeviceIndex(0);
            //var ledTest = ledPositions.pLedPosition.OrderBy(x => x.left).Select(x => new CorsairLedColor() { ledId = x.ledId, b = 0, g = 0, r = 0 }).ToArray();
            //var color = ColorCycle.BLUE;
            //while (true)
            //{

            //    for (int i=0; i < ledTest.Length; i++)
            //    {
            //        switch ((int)color)
            //        {
            //            case 0: ledTest[i].b = 255; ledTest[i].r = 0; ledTest[i].g = 0; break;
            //            case 1: ledTest[i].r = 255; ledTest[i].b = 0; ledTest[i].g = 0; break;
            //            case 2: ledTest[i].g = 255; ledTest[i].b = 0; ledTest[i].r = 0; break;
            //        }
            //        var worked = CorsairSDK.CorsairSetLedsColorsAsync(ledPositions.numberOfLed, ledTest, (x,y,z) => {
            //            Console.WriteLine("Callback Called");
            //        });
            //        Thread.Sleep(5);
            //    }

            //    if ((int)color == 2)
            //    {
            //        color = (ColorCycle)0;
            //    } else
            //    {
            //        color++;
            //    }
            //}

        }

        public static void OnColorsSet(IntPtr context, bool result, CorsairError error)
        {
            Console.WriteLine("Callback Called");
        }

        public static void MarshalUnmananagedArray2Struct<T>(IntPtr unmanagedArray, int length, out T[] mangagedArray)
        {
            var size = Marshal.SizeOf(typeof(T));
            mangagedArray = new T[length];

            for (int i = 0; i < length; i++)
            {
                IntPtr ins = new IntPtr(unmanagedArray.ToInt64() + i * size);
                mangagedArray[i] = Marshal.PtrToStructure<T>(ins);
            }
        }
    }

    public enum ColorCycle: int
    {
        BLUE = 0,
        RED = 1,
        GREEN = 2
    }
}
