using System;
using System.Runtime.InteropServices;

namespace LibKratos.Native {
    public class NativeCondition {
        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Condition_Id(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr Condition_Nodes(IntPtr instance);
        
        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool Condition_HasVariable1d(IntPtr instance, IntPtr variable);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool Condition_HasVariableComponent(IntPtr instance, IntPtr variable);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool Condition_HasVariable3d(IntPtr instance, IntPtr variable);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double Condition_GetVariable1d(IntPtr instance, IntPtr variable);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double Condition_GetVariableComponent(IntPtr instance, IntPtr variable);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr Condition_GetVariable3d(IntPtr instance, IntPtr variable);
    }
}