using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Corsair.NET.Corsair
{
    public delegate void CorsairSessionStateChangedHandler(IntPtr context, CorsairSessionStateChanged eventData);
    public delegate void CorsairAsyncCallback(IntPtr context, CorsairError error);
    public delegate void CorsairEventHandler(IntPtr context, CorsairEvent corsairEvent);
    internal class InternalCorsairSDK
    {
        internal const string DLL_NAME = "iCUESDK.x64_2019";

        [DllImport(DLL_NAME)]
        public static extern CorsairError CorsairConnect(CorsairSessionStateChangedHandler onStateChanged, IntPtr context);

        [DllImport(DLL_NAME)]
        public static extern CorsairError CorsairGetSessionDetails([Out] CorsairSessionDetails details);

        [DllImport(DLL_NAME)]
        public static extern CorsairError CorsairDisconnect();

        [DllImport(DLL_NAME)]
        public static extern CorsairError CorsairGetDevices(ref CorsairDeviceFilter filter, uint sizeMax, [In, Out] CorsairDeviceInfo[] devices, ref int size);

        [DllImport(DLL_NAME)]
        public static extern CorsairError CorsairGetLedPositions(string deviceId, uint sizeMax,[In, Out] CorsairLedPosition[] ledPositions,ref int size);

        [DllImport(DLL_NAME)]
        public static extern CorsairError CorsairGetLedColors(string deviceId, uint size,[In,Out] CorsairLedColor[] ledColors);

        [DllImport(DLL_NAME)]
        public static extern CorsairError CorsairSetLedColors(string deviceId, int size, [In, Out] CorsairLedColor[] ledColors);

        [DllImport(DLL_NAME)]
        public static extern CorsairError CorsairSubscribeForEvents(CorsairEventHandler onEvent, IntPtr context);

        [DllImport(DLL_NAME)]
        public static extern CorsairError CorsairConfigureKeyEvent(string deviceId, ref CorsairKeyEventConfiguration config);

        // UNTESTED
        [DllImport(DLL_NAME)]
        public static extern CorsairError CorsairGetDeviceInfo(string deviceId, CorsairDeviceInfo deviceInfo);


        [DllImport(DLL_NAME)]
        public static extern CorsairError CorsairUnsubscribeFromEvents();


        [DllImport(DLL_NAME)]
        public static extern CorsairError CorsairSetLedColorsBuffer(string deviceId, int size, CorsairLedColor[] ledColors);

        [DllImport(DLL_NAME)]
        public static extern CorsairError CorsairSetLedColorsFlushBufferAsync(CorsairAsyncCallback callback, IntPtr context);

    }
}
