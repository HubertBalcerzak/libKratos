using System;
using System.Runtime.InteropServices;

namespace LibKratos.Native {
    public class NativeCondition {
        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Condition_Id(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr Condition_Nodes(IntPtr instance);
    }
}