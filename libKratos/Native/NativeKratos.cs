using System;
using System.Runtime.InteropServices;

namespace LibKratos.Native {
    internal class NativeKratos {
        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr Kratos_CreateInstance();

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void Kratos_Init(IntPtr intance, [MarshalAs(UnmanagedType.LPStr)] string mdpaPath,
            [MarshalAs(UnmanagedType.LPStr)] string parametersJsonPath);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void Kratos_InitWithMDPA(IntPtr instance, [MarshalAs(UnmanagedType.LPStr)] string mdpaPath);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void Kratos_InitWithSettings(IntPtr instance,
            [MarshalAs(UnmanagedType.LPStr)] string parematersJsonPath);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr Kratos_GetRootModelPart(IntPtr instance);
        
        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void Kratos_Calculate(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void Kratos_DisposeKratos(IntPtr instance);

    }
}