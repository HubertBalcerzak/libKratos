using System;
using System.Linq;
using System.Runtime.InteropServices;
using LibKratos.Native;

namespace LibKratos {
    public class KratosCondition {
        private readonly IntPtr _nativeInstance;
        public int Id { get; }

        internal KratosCondition(IntPtr nativeInstance) {
            _nativeInstance = nativeInstance;
            Id = NativeCondition.Condition_Id(nativeInstance);
        }

        public KratosNode[] GetNodes() {
            IntPtr pNodes = NativeCondition.Condition_Nodes(_nativeInstance);
            int size = 3; //TODO support different condition sizes
            IntPtr[] unmarshaled = new IntPtr[size];
            Marshal.Copy(pNodes, unmarshaled, 0, size);
            return unmarshaled.Select(x => new KratosNode(x)).ToArray();
        }
    }
}