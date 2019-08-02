using System;
using System.Linq;
using System.Runtime.InteropServices;
using LibKratos.Native;

namespace LibKratos {
    /// <summary>
    /// Wrapper over native Kratos Element class
    /// </summary>
    public class KratosElement {
        private readonly IntPtr _nativeInstance;
        /// <summary>
        /// Element Id.
        /// </summary>
        public int Id { get; }

        internal KratosElement(IntPtr nativeInstance) {
            _nativeInstance = nativeInstance;
            Id = NativeElement.Element_Id(nativeInstance);
        }

        /// <returns>Array of <see cref="KratosNode"/> in this element</returns>
        public KratosNode[] GetNodes() {
            IntPtr pNodes = NativeElement.Element_Nodes(_nativeInstance);
            int size = 4; //TODO support for different element sizes
            IntPtr[] unmarshaled = new IntPtr[size];
            Marshal.Copy(pNodes, unmarshaled, 0, size);
            return unmarshaled.Select(x => new KratosNode(x)).ToArray();
        }
    }
}