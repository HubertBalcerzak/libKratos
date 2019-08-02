using System;
using System.Runtime.InteropServices;

namespace LibKratos.Native {
    public class NativeElement {
        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Element_Id(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr Element_Nodes(IntPtr instance);
        
        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool Element_HasVariable1d(IntPtr instance, IntPtr variable);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool Element_HasVariableComponent(IntPtr instance, IntPtr variable);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool Element_HasVariable3d(IntPtr instance, IntPtr variable);
        
        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double Element_GetVariable1d(IntPtr instance, IntPtr variable);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double Element_GetVariableComponent(IntPtr instance, IntPtr variable);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr Element_GetVariable3d(IntPtr instance, IntPtr variable);
    }
}