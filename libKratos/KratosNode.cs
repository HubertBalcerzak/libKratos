using System;

namespace LibKratos {
    public class KratosNode {
        private readonly IntPtr _nativeInstance;

        internal KratosNode(IntPtr nativeInstance) {
            _nativeInstance = nativeInstance;
        }
    }
}