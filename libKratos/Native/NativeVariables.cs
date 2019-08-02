using System;
using System.Runtime.InteropServices;

namespace LibKratos.Native {
    public class NativeVariables {
        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool Variable_Has1dVar([MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool Variable_Has3dVar([MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool Variable_HasVariableComponent([MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr Variable_Get1dVar([MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr Variable_Get3dVar([MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr Variable_GetVarComponent([MarshalAs(UnmanagedType.LPStr)] string name);
    }
}