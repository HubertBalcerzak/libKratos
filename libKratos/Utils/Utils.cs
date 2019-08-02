using System;
using System.Runtime.InteropServices;

namespace LibKratos.Utils {
    internal class Utils {
        public static float[] UnmarshalNativeFloats(IntPtr array, int size) {
            float[] unmarshaled = new float[size];
            Marshal.Copy(array, unmarshaled, 0, size);
            return unmarshaled;
        }

        public static double[] UnmarshalNativeDoubles(IntPtr array, int size) {
            double[] unmarshaled = new double[size];
            Marshal.Copy(array, unmarshaled, 0, size);
            return unmarshaled;
        }
    }
}