using System;
using System.Runtime.InteropServices;

namespace LibKratos.Native {
    public class NativeUtilities {
        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void Utils_FreeDoubleArray(IntPtr array);
    }
}