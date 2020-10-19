using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Corsair.NET.Corsair
{
    public static class CorsairSDK
    {
        public static CorsairProtocolDetails CorsairPerformProtocolHandshake()
        {
            return InternalCorsairSDK.CorsairPerformProtocolHandshake();
        }


        public static int CorsairGetDeviceCount()
        {
            return InternalCorsairSDK.CorsairGetDeviceCount();
        }

        public static CorsairDeviceInfo CorsairGetDeviceInfo(int deviceIndex)
        {
            var pointer = InternalCorsairSDK.CorsairGetDeviceInfo(deviceIndex);
            return Marshal.PtrToStructure<CorsairDeviceInfo>(pointer);
        }

        public static CorsairLedPositions CorsairGetLedPositionsByDeviceIndex(int deviceIndex)
        {
            var pointer = InternalCorsairSDK.CorsairGetLedPositionsByDeviceIndex(deviceIndex);
            var demarshalledInfo = Marshal.PtrToStructure<InternalCorsairLedPositions>(pointer);
            MarshalUnmananagedArray2Struct<CorsairLedPosition>(demarshalledInfo.pLedPosition, demarshalledInfo.numberOfLed, out var array);
            return new CorsairLedPositions
            {
                numberOfLed = demarshalledInfo.numberOfLed,
                pLedPosition = array
            };
        }

        public static bool CorsairSetLedsColors(int size, CorsairLedColor[] ledsColors)
        {
            return InternalCorsairSDK.CorsairSetLedsColors(size, ledsColors);
        }

        public static CorsairLedColor[] CorsairGetLedsColorsByDeviceIndex(int deviceIndex, int size, CorsairLedColor[] ledsColors)
        {
            InternalCorsairSDK.CorsairGetLedsColorsByDeviceIndex(deviceIndex, size, ledsColors);
            return ledsColors;
        }

        public static CorsairLedColor[] CorsairSetLedsColorsAsync(int size, CorsairLedColor[] ledsColors, SetLedsColorsCallback func)
        {
            InternalCorsairSDK.CorsairSetLedsColorsAsync(size, ledsColors, func, IntPtr.Zero);
            return ledsColors;
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

        public static CorsairLedColor[] CorsairGetLedsColors(int size, CorsairLedColor[] ledsColors)
        {
            InternalCorsairSDK.CorsairGetLedsColors(size, ledsColors);
            return ledsColors;
        }
    }
}
