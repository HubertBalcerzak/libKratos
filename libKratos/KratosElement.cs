using System;

namespace LibKratos {
    public class KratosElement {
        private readonly IntPtr _nativeInstance;

        public KratosElement(IntPtr nativeInstance) {
            _nativeInstance = nativeInstance;
        }
    }
}