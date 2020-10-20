using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Corsair.NET.Corsair
{
    public delegate void SetLedsColorsCallback(IntPtr context, bool result, CorsairError error);
    public delegate void KeyPressedCallback(IntPtr context, CorsairKeyIdEnum keyId, bool pressed);
    public delegate void CorsairEventHandler(IntPtr context, CorsairEvent corsairEvent);
    internal class InternalCorsairSDK
    {
        internal const string DLL_NAME = "CUESDK.x64_2017";
        [DllImport(DLL_NAME)]
        public static extern CorsairProtocolDetails CorsairPerformProtocolHandshake();
        [DllImport(DLL_NAME)]
        public static extern int CorsairGetDeviceCount();
        [DllImport(DLL_NAME)]
        public static extern IntPtr CorsairGetDeviceInfo(int deviceIndex);
        [DllImport(DLL_NAME)]
        public static extern IntPtr CorsairGetLedPositionsByDeviceIndex(int deviceIndex);
        [DllImport(DLL_NAME)]
        public static extern IntPtr CorsairGetLedPositions();
        [DllImport(DLL_NAME)]
        public static extern bool CorsairGetLedsColorsByDeviceIndex(int deviceIndex, int size, [In, Out] CorsairLedColor[] ledsColors);
        [DllImport(DLL_NAME)]
        public static extern bool CorsairGetLedsColors(int size, [In, Out] CorsairLedColor[] ledsColors);
        [DllImport(DLL_NAME)]
        public static extern bool CorsairSetLedsColors(int size, CorsairLedColor[] ledsColors);
        [DllImport(DLL_NAME)]
        public static extern bool CorsairSetLedsColorsAsync(int size, CorsairLedColor[] ledsColors, SetLedsColorsCallback callback, IntPtr context);

        [DllImport(DLL_NAME)]
        public static extern bool CorsairUnsubscribeFromEvents();
        [DllImport(DLL_NAME)]
        public static extern bool CorsairSubscribeForEvents(CorsairEventHandler onEvent, IntPtr context);
        //[DllImport(DLL_NAME)]
        //public static extern bool CorsairGetBoolPropertyValue(int deviceIndex, CorsairDevicePropertyId propertyId, bool* propertyValue);
        //[DllImport(DLL_NAME)]
        //public static extern bool CorsairGetInt32PropertyValue(int deviceIndex, CorsairDevicePropertyId propertyId, int* propertyValue);
        [DllImport(DLL_NAME)]
        public static extern bool CorsairRegisterKeypressCallback(KeyPressedCallback callback, IntPtr context);
        [DllImport(DLL_NAME)]
        public static extern bool CorsairSetLayerPriority(int priority);
        [DllImport(DLL_NAME)]
        public static extern bool CorsairReleaseControl(CorsairAccessMode accessMode);
        [DllImport(DLL_NAME)]
        public static extern CorsairError CorsairGetLastError();
        [DllImport(DLL_NAME)]
        public static extern bool CorsairRequestControl(CorsairAccessMode accessMode);
        [DllImport(DLL_NAME)]
        public static extern CorsairLedId CorsairGetLedIdForKeyName(char keyName);
        [DllImport(DLL_NAME)]
        public static extern bool CorsairSetLedsColorsBufferByDeviceIndex(int deviceIndex, int size, CorsairLedColor[] ledsColors);
        [DllImport(DLL_NAME)]
        public static extern bool CorsairSetLedsColorsFlushBuffer();
        [DllImport(DLL_NAME)]
        public static extern bool CorsairSetLedsColorsFlushBufferAsync(SetLedsColorsCallback callback, IntPtr context);
    }
}
