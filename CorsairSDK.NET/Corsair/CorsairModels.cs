using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Corsair.NET.Corsair
{
    public enum CorsairLedId_Keyboard // contains a list of keyboard leds that belong to CLG_Keyboard group
    {
        CLK_Invalid = 0,
        CLK_Escape = 1,
        CLK_F1 = 2,
        CLK_F2 = 3,
        CLK_F3 = 4,
        CLK_F4 = 5,
        CLK_F5 = 6,
        CLK_F6 = 7,
        CLK_F7 = 8,
        CLK_F8 = 9,
        CLK_F9 = 10,
        CLK_F10 = 11,
        CLK_F11 = 12,
        CLK_F12 = 13,
        CLK_GraveAccentAndTilde = 14,
        CLK_1 = 15,
        CLK_2 = 16,
        CLK_3 = 17,
        CLK_4 = 18,
        CLK_5 = 19,
        CLK_6 = 20,
        CLK_7 = 21,
        CLK_8 = 22,
        CLK_9 = 23,
        CLK_0 = 24,
        CLK_MinusAndUnderscore = 25,
        CLK_EqualsAndPlus = 26,
        CLK_Backspace = 27,
        CLK_Tab = 28,
        CLK_Q = 29,
        CLK_W = 30,
        CLK_E = 31,
        CLK_R = 32,
        CLK_T = 33,
        CLK_Y = 34,
        CLK_U = 35,
        CLK_I = 36,
        CLK_O = 37,
        CLK_P = 38,
        CLK_BracketLeft = 39,
        CLK_BracketRight = 40,
        CLK_CapsLock = 41,
        CLK_A = 42,
        CLK_S = 43,
        CLK_D = 44,
        CLK_F = 45,
        CLK_G = 46,
        CLK_H = 47,
        CLK_J = 48,
        CLK_K = 49,
        CLK_L = 50,
        CLK_SemicolonAndColon = 51,
        CLK_ApostropheAndDoubleQuote = 52,
        CLK_Backslash = 53,
        CLK_Enter = 54,
        CLK_LeftShift = 55,
        CLK_NonUsBackslash = 56,
        CLK_Z = 57,
        CLK_X = 58,
        CLK_C = 59,
        CLK_V = 60,
        CLK_B = 61,
        CLK_N = 62,
        CLK_M = 63,
        CLK_CommaAndLessThan = 64,
        CLK_PeriodAndBiggerThan = 65,
        CLK_SlashAndQuestionMark = 66,
        CLK_RightShift = 67,
        CLK_LeftCtrl = 68,
        CLK_LeftGui = 69,
        CLK_LeftAlt = 70,
        CLK_Space = 71,
        CLK_RightAlt = 72,
        CLK_RightGui = 73,
        CLK_Application = 74,
        CLK_RightCtrl = 75,
        CLK_LedProgramming = 76,
        CLK_Lang1 = 77,
        CLK_Lang2 = 78,
        CLK_International1 = 79,
        CLK_International2 = 80,
        CLK_International3 = 81,
        CLK_International4 = 82,
        CLK_International5 = 83,
        CLK_PrintScreen = 84,
        CLK_ScrollLock = 85,
        CLK_PauseBreak = 86,
        CLK_Insert = 87,
        CLK_Home = 88,
        CLK_PageUp = 89,
        CLK_Delete = 90,
        CLK_End = 91,
        CLK_PageDown = 92,
        CLK_UpArrow = 93,
        CLK_LeftArrow = 94,
        CLK_DownArrow = 95,
        CLK_RightArrow = 96,
        CLK_NonUsTilde = 97,
        CLK_Brightness = 98,
        CLK_WinLock = 99,
        CLK_Mute = 100,
        CLK_Stop = 101,
        CLK_ScanPreviousTrack = 102,
        CLK_PlayPause = 103,
        CLK_ScanNextTrack = 104,
        CLK_NumLock = 105,
        CLK_KeypadSlash = 106,
        CLK_KeypadAsterisk = 107,
        CLK_KeypadMinus = 108,
        CLK_Keypad7 = 109,
        CLK_Keypad8 = 110,
        CLK_Keypad9 = 111,
        CLK_KeypadPlus = 112,
        CLK_Keypad4 = 113,
        CLK_Keypad5 = 114,
        CLK_Keypad6 = 115,
        CLK_Keypad1 = 116,
        CLK_Keypad2 = 117,
        CLK_Keypad3 = 118,
        CLK_KeypadComma = 119,
        CLK_KeypadEnter = 120,
        CLK_Keypad0 = 121,
        CLK_KeypadPeriodAndDelete = 122,
        CLK_VolumeUp = 123,
        CLK_VolumeDown = 124,
        CLK_MR = 125,
        CLK_M1 = 126,
        CLK_M2 = 127,
        CLK_M3 = 128,
        CLK_Fn = 129
    };

    public enum CorsairDeviceType : uint // contains list of available device types
    {
        CDT_Unknown = 0x0000,           // for unknown/invalid devices
        CDT_Keyboard = 0x0001,          // for keyboards
        CDT_Mouse = 0x0002,             // for mice
        CDT_Mousemat = 0x0004,          // for mousemats
        CDT_Headset = 0x0008,           // for headsets
        CDT_HeadsetStand = 0x0010,      // for headset stands
        CDT_FanLedController = 0x0020,  // for DIY-devices like Commander PRO
        CDT_LedController = 0x0040,     // for DIY-devices like Lighting Node PRO
        CDT_MemoryModule = 0x0080,      // for memory modules
        CDT_Cooler = 0x0100,            // for coolers
        CDT_Motherboard = 0x0200,       // for motherboards
        CDT_GraphicsCard = 0x0400,      // for graphics cards
        CDT_Touchbar = 0x0800,          // for touchbars
        CDT_GameController = 0x1000,    // for game controllers
        CDT_All = 0xFFFFFFFF            // for all devices
    };

    public enum CorsairError
    {
        CE_Success = 0,
        CE_NotConnected = 1,
        CE_NoControl = 2,
        CE_IncompatibleProtocol = 3,
        CE_InvalidArguments = 4,
        CE_InvalidOperation = 5,
        CE_DeviceNotFound = 6,
        CE_NotAllowed = 7
    }

    public enum CorsairPhysicalLayout  // contains list of available physical layouts for keyboards.
    {
        CPL_Invalid = 0,
        CPL_US = 1,
        CPL_UK = 2,
        CPL_JP = 3,
        CPL_KR = 4,
        CPL_BR = 5
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

    public enum CorsairAccessLevel // contains list of available SDK access levels
    {
        CAL_Shared = 0,                                         // shared mode (default)
        CAL_ExclusiveLightingControl = 1,                       // exclusive lightings, but shared events
        CAL_ExclusiveKeyEventsListening = 2,                    // exclusive key events, but shared lightings
        CAL_ExclusiveLightingControlAndKeyEventsListening = 3   // exclusive mode
    };

    public enum CorsairChannelDeviceType               // contains list of the LED-devices which can be connected to the DIY-device.
    {
        CCDT_Invalid = 0,
        CCDT_HD_Fan = 1,
        CCDT_SP_Fan = 2,
        CCDT_LL_Fan = 3,
        CCDT_ML_Fan = 4,
        CCDT_QL_Fan = 5,
        CCDT_8LedSeriesFan = 6,
        CCDT_Strip = 7,
        CCDT_DAP = 8,
        CCDT_Pump = 9,
        CCDT_DRAM = 10,
        CCDT_WaterBlock = 11,
        CCDT_QX_Fan = 12,
    };

    public enum CorsairDevicePropertyId
    {
        CDPI_Invalid = 0,                     // dummy value
        CDPI_PropertyArray = 1,               // array of CorsairDevicePropertyId members supported by device
        CDPI_MicEnabled = 2,                  // indicates Mic state (On or Off); used for headset, headset stand
        CDPI_SurroundSoundEnabled = 3,        // indicates Surround Sound state (On or Off); used for headset, headset stand
        CDPI_SidetoneEnabled = 4,             // indicates Sidetone state (On or Off); used for headset (where applicable)
        CDPI_EqualizerPreset = 5,             // the number of active equalizer preset (integer, 1 - 5); used for headset, headset stand
        CDPI_PhysicalLayout = 6,              // keyboard physical layout (see CorsairPhysicalLayout for valid values); used for keyboard
        CDPI_LogicalLayout = 7,               // keyboard logical layout (see CorsairLogicalLayout for valid values); used for keyboard
        CDPI_MacroKeyArray = 8,               // array of programmable G, M or S keys on device
        CDPI_BatteryLevel = 9,                // battery level (0 - 100); used for wireless devices
        CDPI_ChannelLedCount = 10,            // total number of LEDs connected to the channel
        CDPI_ChannelDeviceCount = 11,         // number of LED-devices (fans, strips, etc.) connected to the channel which is controlled by the DIY device
        CDPI_ChannelDeviceLedCountArray = 12, // array of integers, each element describes the number of LEDs controlled by the channel device
        CDPI_ChannelDeviceTypeArray = 13      // array of CorsairChannelDeviceType members, each element describes the type of the channel device
    };

    public enum CorsairEventId
    {
        CEI_Invalid, //dummy value
        CEI_DeviceConnectionStatusChangedEvent,
        CEI_KeyEvent
    };

    public struct CorsairDeviceInfo    // contains information about device.
    {

        public CorsairDeviceType type;               // enum describing device type.
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string id;               // enum describing device type.
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string model;                    // null - terminated device model(like “K95RGB”).
        public int channelCount;                         // mask that describes device capabilities, formed as logical “or” of CorsairDeviceCaps enum values.
        public int ledsCount;                        // number of controllable LEDs on the device.
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string serial;             // null-terminated string that contains unique device identifier that uniquely identifies device at least within session

    };

    public struct CorsairLedPosition   
    {
        public uint ledId;             // identifier of led.
        public double cx;
        public double cy;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct CorsairLedColor      // contains information about led and its color.
    {
        public uint id;             // identifier of LED to set.
        public byte r;                          // red   brightness[0..255].
        public byte g;                          // green brightness[0..255].
        public byte b;                          // blue  brightness[0..255].
        public byte a;

        public void Copy(CorsairLedColor toCopy)
        {
            r = toCopy.r;
            g = toCopy.g;
            b = toCopy.b;
            a = toCopy.a;
        }
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
        public CorsairMacroKeyId keyId;       // G or M key that was pressed/released.
        public bool isPressed;           // true if pressed, false if released.
    };

    public struct CorsairEvent // contains information about event id and event data.
    {
        public CorsairEventId id; // event identifier.
        public IntPtr deviceConnectionStatusChangedEvent; // when id == CEI_DeviceConnectionStatusChangedEvent contains valid pointer to public structure with information about connected or disconnected device.
        public IntPtr keyEvent;
    };

    public struct CorsairSessionStateChanged // contains information about session state and client/server versions
    {
        public CorsairSessionState state;       // new session state which SDK client has been transitioned to
        public CorsairSessionDetails details;   // information about client/server versions
    }

    public enum CorsairSessionState // contains a list of all possible session states
    {
        CSS_Invalid = 0,              // dummy value
        CSS_Closed = 1,               // client not initialized or client closed connection (initial state)
        CSS_Connecting = 2,           // client initiated connection but not connected yet
        CSS_Timeout = 3,              // server did not respond, sdk will try again
        CSS_ConnectionRefused = 4,    // server did not allow connection
        CSS_ConnectionLost = 5,       // server closed connection
        CSS_Connected = 6             // successfully connected
    }

    public struct CorsairSessionDetails // contains information about SDK and iCUE versions
    {
        public CorsairVersion clientVersion;       // version of SDK client (like {4,0,1}). Always contains valid value even if there was no iCUE found. Must comply with the semantic versioning rules.
        public CorsairVersion serverVersion;       // version of SDK server (like {4,0,1}) or empty struct ({0,0,0}) if the iCUE was not found. Must comply with the semantic versioning rules.
        public CorsairVersion serverHostVersion;   // version of iCUE (like {3,33,100}) or empty struct ({0,0,0}) if the iCUE was not found.
    }

    public struct CorsairVersion // contains information about version that consists of three components
    {
        public int major;
        public int minor;
        public int patch;
    }

    public struct CorsairDeviceFilter // contains device search filter
    {
        public uint deviceTypeMask;  // mask that describes device types, formed as logical “or” of CorsairDeviceType enum values
    }

    public struct CorsairKeyEventConfiguration // contains information about key event configuration
    {
        public CorsairMacroKeyId keyId;  // G, M or S key
        public bool isIntercepted;       // flag that defines how key event should behave. If true then iCUE will pass the event to an active exclusive SDK client and stop passing it to the rest SDK clients. If false then iCUE will resume sending it to all SDK clients
    }
}
