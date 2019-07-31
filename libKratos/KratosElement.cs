using System;

namespace LibKratos {
    public class KratosElement {
        private readonly IntPtr _nativeInstance;

        internal KratosElement(IntPtr nativeInstance) {
            _nativeInstance = nativeInstance;
        }
    }
}