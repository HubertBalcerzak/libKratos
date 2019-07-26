using System;

namespace LibKratos {
    public class KratosNode {
        private readonly IntPtr _nativeInstance;

        public KratosNode(IntPtr nativeInstance) {
            _nativeInstance = nativeInstance;
        }
    }
}