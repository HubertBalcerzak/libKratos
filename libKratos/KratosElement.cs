using System;
using System.Linq;
using System.Runtime.InteropServices;
using LibKratos.Native;

namespace LibKratos {
    public class KratosElement {
        private readonly IntPtr _nativeInstance;
        public int Id { get; }

        internal KratosElement(IntPtr nativeInstance) {
            _nativeInstance = nativeInstance;
            Id = NativeElement.Element_Id(nativeInstance);
        }

        public KratosNode[] GetNodes() {
            IntPtr pNodes = NativeElement.Element_Nodes(_nativeInstance);
            int size = 4; //TODO support for different element sizes
            IntPtr[] unmarshaled = new IntPtr[size];
            Marshal.Copy(pNodes, unmarshaled, 0, size);
            return unmarshaled.Select(x => new KratosNode(x)).ToArray();
        }
    }
}