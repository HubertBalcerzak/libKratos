using System;
using System.Runtime.InteropServices;

namespace LibKratos.Native {
    public class NativeElement {
        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Element_Id(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr Element_Nodes(IntPtr instance);
    }
}