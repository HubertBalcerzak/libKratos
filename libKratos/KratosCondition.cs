using System;

namespace LibKratos {
    public class KratosCondition {
        private readonly IntPtr _nativeInstance;

        public KratosCondition(IntPtr nativeInstance) {
            _nativeInstance = nativeInstance;
        }
    }
}