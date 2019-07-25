using System;
using System.Runtime.InteropServices;

namespace LibKratos.Native {
    internal class NativeKratos {
        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr CreateInstance();

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void Init(IntPtr intance, [MarshalAs(UnmanagedType.LPStr)] string mdpaPath,
            [MarshalAs(UnmanagedType.LPStr)] string parametersJsonPath);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void InitWithMDPA(IntPtr instance, [MarshalAs(UnmanagedType.LPStr)] string mdpaPath);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void InitWithSettings(IntPtr instance,
            [MarshalAs(UnmanagedType.LPStr)] string parematersJsonPath);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetRootModelPart(IntPtr instance);
        
        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void Calculate(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void DisposeKratos(IntPtr instance);

    }
}