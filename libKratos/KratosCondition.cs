using System;

namespace LibKratos {
    public class KratosCondition {
        private readonly IntPtr _nativeInstance;

        internal KratosCondition(IntPtr nativeInstance) {
            _nativeInstance = nativeInstance;
        }
    }
}