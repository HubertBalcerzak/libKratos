using System;
using System.Runtime.InteropServices;

namespace LibKratos.Native {
    public class NativeIdTranslator {
        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool Translator_HasKratosId(IntPtr instance, int surfaceId);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool Translator_HasSurfaceId(IntPtr instance, int kratosId);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Translator_GetSurfaceId(IntPtr instance, int kratosId);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Translator_GetKratosId(IntPtr instance, int surfaceId);
    }
}