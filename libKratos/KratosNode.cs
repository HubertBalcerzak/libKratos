using System;
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

        /// <summary>
        /// Checks whether node has initialized 1-dimensional variable. <seealso cref="HasVariable3d"/>
        /// </summary>
        /// <param name="variable1d">Variable to check.</param>
        /// <returns>true, if variable is initialized</returns>
        public bool HasVariable1d(Variable1d variable1d) {
            return variable1d.VariableType == VariableType.Standard
                ? NativeNode.Node_HasVariable1d(_nativeInstance, variable1d.NativeVariable)
                : NativeNode.Node_HasVariableComponent(_nativeInstance, variable1d.NativeVariable);
        }

        /// <summary>
        /// Checks whether node has initialized 3-dimensional variable. <seealso cref="HasVariable1d"/>
        /// </summary>
        /// <param name="variable3d">variable to check</param>
        /// <returns>true, if variable is initialized</returns>
        public bool HasVariable3d(Variable3d variable3d) {
            return NativeNode.Node_HasVariable3d(_nativeInstance, variable3d.NativeVariable);
        }

        /// <summary>
        /// Extracts 1-dimensional variable value. <seealso cref="HasVariable1d"/> <seealso cref="GetVariable3d"/>
        /// </summary>
        /// <param name="variable1d">variable to extract</param>
        /// <returns>variable value</returns>
        public double GetVariable1d(Variable1d variable1d) {
            return variable1d.VariableType == VariableType.Standard
                ? NativeNode.Node_GetVariable1d(_nativeInstance, variable1d.NativeVariable)
                : NativeNode.Node_GetVariableComponent(_nativeInstance, variable1d.NativeVariable);
        }

        /// <summary>
        /// Extracts 3-dimensional variable value. <seealso cref="HasVariable3d"/> <seealso cref="GetVariable1d"/>
        /// </summary>
        /// <param name="variable3d">variable to extract</param>
        /// <returns>array with 3 variable values in order X Y Z</returns>
        public double[] GetVariable3d(Variable3d variable3d) {
            IntPtr values = NativeNode.Node_GetVariable3d(_nativeInstance, variable3d.NativeVariable);
            double[] unmarshalledResults = Utils.Utils.UnmarshalNativeDoubles(values, 3);
            NativeUtilities.Utils_FreeDoubleArray(values);
            return unmarshalledResults;
        }
    }
}