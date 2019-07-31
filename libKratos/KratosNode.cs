using System;
using LibKratos.Native;

namespace LibKratos {
    //TODO coordinate modification

    public class KratosNode {
        private readonly IntPtr _nativeInstance;
        public int Id { get; }

        public double X => NativeNode.Node_X(_nativeInstance);
        public double Y => NativeNode.Node_Y(_nativeInstance);
        public double Z => NativeNode.Node_Z(_nativeInstance);
        public double X0 => NativeNode.Node_X0(_nativeInstance);
        public double Y0 => NativeNode.Node_Y0(_nativeInstance);
        public double Z0 => NativeNode.Node_Z0(_nativeInstance);

        internal KratosNode(IntPtr nativeInstance) {
            _nativeInstance = nativeInstance;
            Id = NativeNode.Node_Id(nativeInstance);
        }
    }
}