using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CorsairWrapper.Corsair
{
	public enum CorsairDeviceType      // contains list of available device types.
	{
		CDT_Unknown = 0,
		CDT_Mouse = 1,
		CDT_Keyboard = 2,
		CDT_Headset = 3,
		CDT_MouseMat = 4,
		CDT_HeadsetStand = 5,
		CDT_CommanderPro = 6,
		CDT_LightingNodePro = 7,
		CDT_MemoryModule = 8,
		CDT_Cooler = 9,
		CDT_Motherboard = 10,
		CDT_GraphicsCard = 11
	};

	public enum CorsairPhysicalLayout  // contains list of available physical layouts for keyboards.
	{
		CPL_Invalid = 0,        // dummy value.

		CPL_US = 1,
		CPL_UK = 2,
		CPL_BR = 3,
		CPL_JP = 4,
		CPL_KR = 5,             // valid values for keyboard.

		CPL_Zones1 = 6,
		CPL_Zones2 = 7,
		CPL_Zones3 = 8,
		CPL_Zones4 = 9          // valid values for mouse.
	};

	public enum CorsairLogicalLayout   // contains list of available logical layouts for keyboards.
	{
		CLL_Invalid = 0,        // dummy value.
		CLL_US_Int = 1,
		CLL_NA = 2,
		CLL_EU = 3,
		CLL_UK = 4,
		CLL_BE = 5,
		CLL_BR = 6,
		CLL_CH = 7,
		CLL_CN = 8,
		CLL_DE = 9,
		CLL_ES = 10,
		CLL_FR = 11,
		CLL_IT = 12,
		CLL_ND = 13,
		CLL_RU = 14,
		CLL_JP = 15,
		CLL_KR = 16,
		CLL_TW = 17,
		CLL_MEX = 18
	};

	public enum CorsairDeviceCaps      // contains list of device capabilities.
	{
		CDC_None = 0x0000, // for devices that do not support any SDK functions.
		CDC_Lighting = 0x0001, // for devices that has controlled lighting.
		CDC_PropertyLookup = 0x0002  // for devices that provide current state through set of properties.
	};

	public enum CorsairAccessMode      // contains list of available SDK access modes.
	{
		CAM_ExclusiveLightingControl = 0
	};

	public enum CorsairError           // contains shared list of all errors which could happen during calling of Corsair* functions.
	{
		CE_Success,                     // if previously called function completed successfully.
		CE_ServerNotFound,              // CUE is not running or was shut down or third-party control is disabled in CUE settings(runtime error).
		CE_NoControl,                   // if some other client has or took over exclusive control (runtime error).
		CE_ProtocolHandshakeMissing,    // if developer did not perform protocol handshake(developer error).
		CE_IncompatibleProtocol,        // if developer is calling the function that is not supported by the server(either because protocol has broken by server or client or because the function is new and server is too old. Check CorsairProtocolDetails for details) (developer error).
		CE_InvalidArguments,            // if developer supplied invalid arguments to the function(for specifics look at function descriptions). (developer error).
	};

	public enum CorsairChannelDeviceType               // contains list of the LED-devices which can be connected to the DIY-device.
	{
		CCDT_Invalid = 0,   // dummy value.
		CCDT_HD_Fan = 1,
		CCDT_SP_Fan = 2,
		CCDT_LL_Fan = 3,
		CCDT_ML_Fan = 4,
		CCDT_Strip = 5,
		CCDT_DAP = 6,
		CCDT_Pump = 7,
		CCDT_QL_Fan = 8,
		CCDT_WaterBlock = 9,
		CCDT_SPPRO_Fan = 10
	};

	public enum CorsairDevicePropertyType
	{
		CDPT_Boolean = 0x1000,
		CDPT_Int32 = 0x2000
	};

	public enum CorsairDevicePropertyId
	{
		CDPI_Headset_MicEnabled = 0x1000, // indicates Mic state (On or Off).
		CDPI_Headset_SurroundSoundEnabled = 0x1001, // indicates Surround Sound state (On or Off).
		CDPI_Headset_SidetoneEnabled = 0x1002, // indicates Sidetone state (On or Off).
		CDPI_Headset_EqualizerPreset = 0x2000  // the number of active equalizer preset (integer, 1 - 5).
	};

	public enum CorsairEventId
	{
		CEI_Invalid, //dummy value
		CEI_DeviceConnectionStatusChangedEvent,
		CEI_KeyEvent
	};

	public struct CorsairChannelDeviceInfo     // contains information about separate LED-device connected to the channel controlled by the DIY-device.
	{
		public CorsairChannelDeviceType type;  // type of the LED-device.
		public int deviceLedCount;         // number of LEDs controlled by LED-device.
	};

	public struct CorsairChannelInfo               // contains information about separate channel of the DIY-device.
	{
		public int totalLedsCount;                 // total number of LEDs connected to the channel.
		public int devicesCount;                   // number of LED-devices (fans, strips, etc.) connected to the channel which is controlled by the DIY device.
		public IntPtr devices;  // array containing information about each separate LED-device connected to the channel controlled by the DIY device. Index of the LED-device in array is same as the index of the LED-device connected to the DIY-device.
	};

	public struct CorsairChannelsInfo          // contains information about channels of the DIY-devices.
	{
		public int channelsCount;              // number of channels controlled by the device.
		public IntPtr channels;   // array containing information about each separate channel of the DIY-device. Index of the channel in the array is same as index of the channel on the DIY-device.
	};

	public struct CorsairDeviceInfo    // contains information about device.
	{
		public CorsairDeviceType type;               // enum describing device type.
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string model;                    // null - terminated device model(like “K95RGB”).
		public CorsairPhysicalLayout physicalLayout; // enum describing physical layout of the keyboard or mouse.
		public CorsairLogicalLayout logicalLayout;   // enum describing logical layout of the keyboard as set in CUE settings.
		public int capsMask;                         // mask that describes device capabilities, formed as logical “or” of CorsairDeviceCaps enum values.
		public int ledsCount;                        // number of controllable LEDs on the device.
		public CorsairChannelsInfo channels;         // public structure that describes channels of the DIY-devices.
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string deviceId;             // null-terminated string that contains unique device identifier that uniquely identifies device at least within session
	};

	public struct CorsairLedPosition   // contains led id and position of led rectangle.Most of the keys are rectangular.In case if key is not rectangular(like Enter in ISO / UK layout) it returns the smallest rectangle that fully contains the key.
	{
		public CorsairLedId ledId;             // identifier of led.
		public double top;
		public double left;
		public double height;
		public double width;                   // values in mm.
	};

	public struct InternalCorsairLedPositions  // contains number of leds and arrays with their positions.
	{
		public int numberOfLed;                // integer value.Number of elements in following array.
		public IntPtr pLedPosition; // array of led positions.
	};

	public struct CorsairLedPositions
    {
		public int numberOfLed;
		public CorsairLedPosition[] pLedPosition;
	}
	[StructLayout(LayoutKind.Sequential)]
	public struct CorsairLedColor      // contains information about led and its color.
	{
		public CorsairLedId ledId;             // identifier of LED to set.
		public int r;                          // red   brightness[0..255].
		public int g;                          // green brightness[0..255].
		public int b;                          // blue  brightness[0..255].
	};

	public struct CorsairProtocolDetails // contains information about SDK and CUE versions.
	{
		public IntPtr sdkVersion;         // null - terminated string containing version of SDK(like “1.0.0.1”). Always contains valid value even if there was no CUE found.
		public IntPtr serverVersion;      // null - terminated string containing version of CUE(like “1.0.0.1”) or NULL if CUE was not found.
		public int sdkProtocolVersion;         // integer number that specifies version of protocol that is implemented by current SDK. Numbering starts from 1. Always contains valid value even if there was no CUE found.
		public int serverProtocolVersion;      // integer number that specifies version of protocol that is implemented by CUE. Numbering starts from 1. If CUE was not found then this value will be 0.
		public bool breakingChanges;           // boolean value that specifies if there were breaking changes between version of protocol implemented by server and client.
	};

	public struct CorsairDeviceConnectionStatusChangedEvent // contains information about some device that is connected or disconnected. When user receives this event, it makes sense to reenumerate device list, because device indices may become invalid at this moment.
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string deviceId; // null-terminated string that contains unique device identifier.
		public bool isConnected;         // true if connected, false if disconnected.
	};

	public struct CorsairKeyEvent // contains information about device where G or M key was pressed/released and the key itself.
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
		public string deviceId; // null-terminated string that contains unique device identifier.
		public CorsairKeyIdEnum keyId;       // G or M key that was pressed/released.
		public bool isPressed;           // true if pressed, false if released.
	};

	public struct CorsairEvent // contains information about event id and event data.
	{
		public CorsairEventId id; // event identifier.
		public IntPtr deviceConnectionStatusChangedEvent; // when id == CEI_DeviceConnectionStatusChangedEvent contains valid pointer to public structure with information about connected or disconnected device.
		public IntPtr keyEvent;
	};
}
