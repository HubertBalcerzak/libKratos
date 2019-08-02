using System;
using System.Runtime.InteropServices;

namespace LibKratos.Native {
    public class NativeNode {
        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Node_Id(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double Node_X(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double Node_Y(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double Node_Z(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double Node_X0(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double Node_Y0(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double Node_Z0(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool Node_HasVariable1d(IntPtr instance, IntPtr variable);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool Node_HasVariableComponent(IntPtr instance, IntPtr variable);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool Node_HasVariable3d(IntPtr instance, IntPtr variable);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double Node_GetVariable1d(IntPtr instance, IntPtr variable);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double Node_GetVariableComponent(IntPtr instance, IntPtr variable);

        /// <summary>
        /// Returned array must be deleted manually via <see cref="NativeUtilities.Utils_FreeDoubleArray"/>
        /// </summary>
        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr Node_GetVariable3d(IntPtr instance, IntPtr variable);
    }
}