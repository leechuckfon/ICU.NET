using Corsair.NET.Corsair;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace CorsairWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            SetLedsColorsCallback test = new SetLedsColorsCallback(OnColorsSet);
            var details = CorsairSDK.CorsairPerformProtocolHandshake();
            var ledPositions = CorsairSDK.CorsairGetLedPositionsByDeviceIndex(0);
            var ledTest = ledPositions.pLedPosition.Select(x => new CorsairLedColor() { ledId = x.ledId, b = 0, g = 0, r = 0 }).ToArray();
            var colors = CorsairSDK.CorsairGetLedsColorsByDeviceIndex(0, ledPositions.numberOfLed, ledTest);
            var ledColors = ledPositions.pLedPosition.Select(x => new CorsairLedColor() { ledId = x.ledId, b = 255, g = 0, r = 0 }).ToArray();
            var worked = CorsairSDK.CorsairSetLedsColorsAsync(ledPositions.numberOfLed, ledColors, test);

            Console.ReadLine();

        }

        public static CorsairError OnColorsSet(IntPtr context, bool result)
        {
            Console.WriteLine("Callback Called");
            return CorsairError.CE_Success;
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
}
