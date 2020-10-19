using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Corsair.NET.Corsair
{
    public delegate CorsairError SetLedsColorsCallback(IntPtr context, bool result);

    internal class InternalCorsairSDK
    {
        internal const string DLL_NAME = "CUESDK.x64_2017";
        [DllImport(DLL_NAME, CharSet = CharSet.Unicode)]
        public static extern CorsairProtocolDetails CorsairPerformProtocolHandshake();
        [DllImport(DLL_NAME, CharSet = CharSet.Unicode)]
        public static extern int CorsairGetDeviceCount();
        [DllImport(DLL_NAME, CharSet = CharSet.Unicode)]
        public static extern IntPtr CorsairGetDeviceInfo(int deviceIndex);
        [DllImport(DLL_NAME)]
        public static extern IntPtr CorsairGetLedPositionsByDeviceIndex(int deviceIndex);
        [DllImport(DLL_NAME)]
        public static extern bool CorsairGetLedsColorsByDeviceIndex(int deviceIndex, int size, [In, Out] CorsairLedColor[] ledsColors);
        [DllImport(DLL_NAME)]
        public static extern bool CorsairGetLedsColors(int size, [In, Out] CorsairLedColor[] ledsColors);
        [DllImport(DLL_NAME)]
        public static extern bool CorsairSetLedsColors(int size, CorsairLedColor[] ledsColors);
        [DllImport(DLL_NAME, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CorsairSetLedsColorsAsync(int size, CorsairLedColor[] ledsColors, SetLedsColorsCallback callback, IntPtr context);
    }
}
