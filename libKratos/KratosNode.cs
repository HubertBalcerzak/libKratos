using System;
using System.Runtime.InteropServices;
using LibKratos.Native;

namespace LibKratos {
    //TODO coordinate modification

    /// <summary>
    /// Wrapper around native Node class.
    /// </summary>
    public class KratosNode {
        private readonly IntPtr _nativeInstance;

        /// <summary>
        /// Native kratos node Id. Different from those used in <see cref="ModelPart"/> class.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Current node X position, including DISPLACEMENT variable.
        /// Updated instantly after calling <see cref="ModelPart.UpdateNodePos"/> or <see cref="Kratos.Calculate"/>
        /// </summary>
        public double X => NativeNode.Node_X(_nativeInstance);

        /// <summary>
        /// Current node Y position, including DISPLACEMENT variable.
        /// Updated instantly after calling <see cref="ModelPart.UpdateNodePos"/> or <see cref="Kratos.Calculate"/>
        /// </summary>
        public double Y => NativeNode.Node_Y(_nativeInstance);

        /// <summary>
        /// Current node Z position, including DISPLACEMENT variable.
        /// Updated instantly after calling <see cref="ModelPart.UpdateNodePos"/> or <see cref="Kratos.Calculate"/>
        /// </summary>
        public double Z => NativeNode.Node_Z(_nativeInstance);

        /// <summary>
        /// Initial node X position. Will not change with DISPLACEMENT variable.
        /// </summary>
        public double X0 => NativeNode.Node_X0(_nativeInstance);

        /// <summary>
        /// Initial node X position. Will not change with DISPLACEMENT variable.
        /// </summary>
        public double Y0 => NativeNode.Node_Y0(_nativeInstance);

        /// <summary>
        /// Initial node X position. Will not change with DISPLACEMENT variable.
        /// </summary>
        public double Z0 => NativeNode.Node_Z0(_nativeInstance);

        internal KratosNode(IntPtr nativeInstance) {
            _nativeInstance = nativeInstance;
            Id = NativeNode.Node_Id(nativeInstance);
        }

        public bool HasVariable1d(Variable1d variable1d) {
            return variable1d.VariableType == VariableType.Standard
                ? NativeNode.Node_HasVariable1d(_nativeInstance, variable1d.NativeVariable)
                : NativeNode.Node_HasVariableComponent(_nativeInstance, variable1d.NativeVariable);
        }

        public bool HasVariable3d(Variable3d variable3d) {
            return NativeNode.Node_HasVariable3d(_nativeInstance, variable3d.NativeVariable);
        }

        public double GetVariable1d(Variable1d variable1d) {
            return variable1d.VariableType == VariableType.Standard
                ? NativeNode.Node_GetVariable1d(_nativeInstance, variable1d.NativeVariable)
                : NativeNode.Node_GetVariableComponent(_nativeInstance, variable1d.NativeVariable);
        }

        public double[] GetVariable3d(Variable3d variable3d) {
            IntPtr values = NativeNode.Node_GetVariable3d(_nativeInstance, variable3d.NativeVariable);
            double[] unmarshalledResults = Utils.Utils.UnmarshalNativeDoubles(values, 3);
            NativeUtilities.Utils_FreeDoubleArray(values);
            return unmarshalledResults;
        }
    }
}