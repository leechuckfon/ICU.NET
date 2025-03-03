using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Corsair.NET.Corsair
{
    public static class CorsairSDK
    {
        const uint CORSAIR_DEVICE_COUNT_MAX = 64;
        const uint CORSAIR_DEVICE_LEDCOUNT_MAX = 512;

        public static CorsairError RegisterSomething(string deviceId, CorsairKeyEventConfiguration configuration)
        {
            return InternalCorsairSDK.CorsairConfigureKeyEvent(deviceId, ref configuration);
        }

        public static CorsairError CorsairConnect(CorsairSessionStateChangedHandler handler)
        {
            return InternalCorsairSDK.CorsairConnect(handler, IntPtr.Zero);
        }

        public static CorsairError CorsairDisconnect()
        {
            return InternalCorsairSDK.CorsairDisconnect();
        }


        public static IEnumerable<CorsairDeviceInfo> GetDevices()
        {
            var filter = new CorsairDeviceFilter
            {
                deviceTypeMask = (uint)CorsairDeviceType.CDT_All
            };

            var devices = new CorsairDeviceInfo[CORSAIR_DEVICE_COUNT_MAX];
            int size = default;

            var response = InternalCorsairSDK.CorsairGetDevices(ref filter, CORSAIR_DEVICE_COUNT_MAX, devices, ref size);

            return devices.Take(size);
        }

        public static CorsairError CorsairSubscribeForEvents(CorsairEventHandler eventHandler)
        {
            return InternalCorsairSDK.CorsairSubscribeForEvents(eventHandler, IntPtr.Zero);
        }

        public static CorsairSessionDetails CorsairGetSessionDetails()
        {
            var devices = new CorsairSessionDetails();
            InternalCorsairSDK.CorsairGetSessionDetails(devices);

            return devices;
        }

        public static IEnumerable<CorsairLedPosition> CorsairGetLedPositions(string deviceId)
        {
            var result = new CorsairLedPosition[CORSAIR_DEVICE_LEDCOUNT_MAX];

            int size = default;

            InternalCorsairSDK.CorsairGetLedPositions(deviceId, CORSAIR_DEVICE_LEDCOUNT_MAX, result, ref size);

            return result.Take(size);
        }

        public static CorsairLedColor[] CorsairGetLedColors(string deviceId, CorsairLedPosition[] ledPositions = null)
        {
            if (ledPositions is null)
            {
                ledPositions = CorsairGetLedPositions(deviceId).ToArray();
            }

            var ledColors = ledPositions.Select(x => x.ledId).Distinct().Select(x => new CorsairLedColor { id = x }).ToArray();
            var error = InternalCorsairSDK.CorsairGetLedColors(deviceId, (uint)ledColors.Length, ledColors);

            return ledColors;
        }

        public static CorsairDeviceInfo CorsairGetDeviceInfo(string deviceIndex, CorsairDeviceInfo info)
        {
            var pointer = InternalCorsairSDK.CorsairGetDeviceInfo(deviceIndex, info);
            return info;
        }

        public static CorsairError CorsairSetLedsColors(string deviceId, CorsairLedColor[] ledsColors)
        {
            return InternalCorsairSDK.CorsairSetLedColors(deviceId, ledsColors.Length, ledsColors);
        }

        public static CorsairError CorsairUnsubscribeFromEvents()
        {
            return InternalCorsairSDK.CorsairUnsubscribeFromEvents();
        }
        public static CorsairError CorsairSubscribeForEvents(CorsairEventHandler onEvent, IntPtr context)
        {
            return InternalCorsairSDK.CorsairSubscribeForEvents(onEvent, IntPtr.Zero);
        }
    }
}
