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
        public static CorsairError CorsairConnect(CorsairSessionStateChangedHandler handler)
        {
            return InternalCorsairSDK.CorsairConnect(handler, IntPtr.Zero);
        }

        public static CorsairError CorsairDisconnect()
        {
            return InternalCorsairSDK.CorsairDisconnect();
        }


        public static IEnumerable<CorsairDeviceInfo> CorsairGetDeviceCount()
        {
            var filter = new CorsairDeviceFilter
            {
                deviceTypeMask = (uint)CorsairDeviceType.CDT_All
            };

            var d = new CorsairDeviceInfo[CORSAIR_DEVICE_COUNT_MAX];

            IntPtr pnt = IntPtr.Zero;
            int p = default;

            var response = InternalCorsairSDK.CorsairGetDevices(ref filter, CORSAIR_DEVICE_COUNT_MAX, d, ref p);

            return d.Take(p);
        }

        public static CorsairSessionDetails CorsairGetSessionDetails()
        {
            var devices = new CorsairSessionDetails();
            InternalCorsairSDK.CorsairGetSessionDetails(devices);

            return devices;
        }

        public static CorsairDeviceInfo CorsairGetDeviceInfo(string deviceIndex, CorsairDeviceInfo info)
        {
            var pointer = InternalCorsairSDK.CorsairGetDeviceInfo(deviceIndex, info);
            return info;
        }

        //public static CorsairLedPositions CorsairGetLedPositionsByDeviceIndex(int deviceIndex)
        //{
        //    var pointer = InternalCorsairSDK.CorsairGetLedPositionsByDeviceIndex(deviceIndex);
        //    var demarshalledInfo = Marshal.PtrToStructure<InternalCorsairLedPositions>(pointer);
        //    MarshalUnmananagedArray2Struct<CorsairLedPosition>(demarshalledInfo.pLedPosition, demarshalledInfo.numberOfLed, out var array);
        //    return new CorsairLedPositions
        //    {
        //        numberOfLed = demarshalledInfo.numberOfLed,
        //        pLedPosition = array
        //    };
        //}

        //public static CorsairLedPositions CorsairGetLedPositions()
        //{
        //    var pointer = InternalCorsairSDK.CorsairGetLedPositions();
        //    var demarshalledInfo = Marshal.PtrToStructure<InternalCorsairLedPositions>(pointer);
        //    MarshalUnmananagedArray2Struct<CorsairLedPosition>(demarshalledInfo.pLedPosition, demarshalledInfo.numberOfLed, out var array);
        //    return new CorsairLedPositions
        //    {
        //        numberOfLed = demarshalledInfo.numberOfLed,
        //        pLedPosition = array
        //    };
        //}

        public static CorsairError CorsairSetLedsColors(int size, CorsairLedColor[] ledsColors)
        {
            //return InternalCorsairSDK.CorsairSetLedsColors(size, ledsColors);
            return CorsairError.CE_Success;
        }

        public static CorsairLedColor[] CorsairGetLedsColorsByDeviceIndex(int deviceIndex, int size, CorsairLedColor[] ledsColors)
        {
            //InternalCorsairSDK.CorsairGetLedsColorsByDeviceIndex(deviceIndex, size, ledsColors);
            return ledsColors;
        }

        public static CorsairLedColor[] CorsairSetLedsColorsAsync(int size, CorsairLedColor[] ledsColors)
        {
            //InternalCorsairSDK.CorsairSetLedsColorsAsync(size, ledsColors, func, IntPtr.Zero);
            return ledsColors;
        }
        public static void MarshalUnmananagedArray2Struct<T>(IntPtr unmanagedArray, uint length, out T[] mangagedArray)
        {
            var size = Marshal.SizeOf(typeof(T));
            mangagedArray = new T[length];

            for (int i = 0; i < length; i++)
            {
                IntPtr ins = new IntPtr(unmanagedArray.ToInt64() + i * size);
                mangagedArray[i] = Marshal.PtrToStructure<T>(ins);
            }
        }

        public static CorsairLedColor[] CorsairGetLedsColors(string deviceId, int size, CorsairLedColor[] ledsColors)
        {
            InternalCorsairSDK.CorsairGetLedColors(deviceId,size, ledsColors);

            return ledsColors;
        }

        public static CorsairError CorsairUnsubscribeFromEvents()
        {
            return InternalCorsairSDK.CorsairUnsubscribeFromEvents();
        }
        public static CorsairError CorsairSubscribeForEvents(CorsairEventHandler onEvent, IntPtr context)
        {
            return InternalCorsairSDK.CorsairSubscribeForEvents(onEvent, IntPtr.Zero);
        }
        //public static bool CorsairRegisterKeypressCallback(KeyPressedCallback callback, IntPtr context)
        //{
        //    return InternalCorsairSDK.CorsairConfigureKeyEvent(callback, IntPtr.Zero);
        //}
        //public static bool CorsairSetLayerPriority(int priority)
        //{
        //    return InternalCorsairSDK.CorsairSetLayerPriority(priority);
        //}
        //public static bool CorsairReleaseControl(CorsairAccessMode accessMode)
        //{
        //    return InternalCorsairSDK.CorsairReleaseControl(accessMode);
        //}
        //public static CorsairError CorsairGetLastError()
        //{
        //    return InternalCorsairSDK.CorsairGetLastError();
        //}
        //public static bool CorsairRequestControl(CorsairAccessMode accessMode)
        //{
        //    return InternalCorsairSDK.CorsairRequestControl(accessMode);
        //}
        //public static CorsairLedId CorsairGetLedIdForKeyName(char keyName)
        //{
        //    return InternalCorsairSDK.CorsairGetLedIdForKeyName(keyName);
        //}
        //public static bool CorsairSetLedsColorsBufferByDeviceIndex(int deviceIndex, int size, CorsairLedColor[] ledsColors)
        //{
        //    return InternalCorsairSDK.CorsairSetLedsColorsBufferByDeviceIndex(deviceIndex, size, ledsColors);
        //}
        //public static bool CorsairSetLedsColorsFlushBuffer()
        //{
        //    return InternalCorsairSDK.CorsairSetLedsColorsFlushBuffer();
        //}
        //public static bool CorsairSetLedsColorsFlushBufferAsync(SetLedsColorsCallback callback)
        //{
        //    return InternalCorsairSDK.CorsairSetLedsColorsFlushBufferAsync(callback, IntPtr.Zero);
        //}
    }
}
