using System;
using System.Runtime.InteropServices;

namespace LibKratos {
public class Native {
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
        public static extern void UpdateNodePos(IntPtr instance, int nodeId, float x, float y, float z);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void Calculate(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetXCoordinates(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetYCoordinates(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetZCoordinates(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetNodesCount(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetTriangles(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetTrianglesCount(IntPtr instance);
    }
}