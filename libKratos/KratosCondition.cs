using System;
using System.Linq;
using System.Runtime.InteropServices;
using LibKratos.Native;

namespace LibKratos {
    /// <summary>
    /// Wrapper over native Kratos Condition class
    /// </summary>
    public class KratosCondition {
        private readonly IntPtr _nativeInstance;
        public int Id { get; }

        internal KratosCondition(IntPtr nativeInstance) {
            _nativeInstance = nativeInstance;
            Id = NativeCondition.Condition_Id(nativeInstance);
        }


        /// <returns>Array of <see cref="KratosNode"/> in this condition</returns>
        public KratosNode[] GetNodes() {
            IntPtr pNodes = NativeCondition.Condition_Nodes(_nativeInstance);
            int size = 3; //TODO support different condition sizes
            IntPtr[] unmarshaled = new IntPtr[size];
            Marshal.Copy(pNodes, unmarshaled, 0, size);
            return unmarshaled.Select(x => new KratosNode(x)).ToArray();
        }

        /// <summary>
        /// Checks whether condition has initialized 1-dimensional variable. <seealso cref="HasVariable3d"/>
        /// </summary>
        /// <param name="variable1d">Variable to check.</param>
        /// <returns>true, if variable is initialized</returns>
        public bool HasVariable1d(Variable1d variable1d) {
            return variable1d.VariableType == VariableType.Standard
                ? NativeCondition.Condition_HasVariable1d(_nativeInstance, variable1d.NativeVariable)
                : NativeCondition.Condition_HasVariableComponent(_nativeInstance, variable1d.NativeVariable);
        }

        /// <summary>
        /// Checks whether condition has initialized 3-dimensional variable. <seealso cref="HasVariable1d"/>
        /// </summary>
        /// <param name="variable3d">variable to check</param>
        /// <returns>true, if variable is initialized</returns>
        public bool HasVariable3d(Variable3d variable3d) {
            return NativeCondition.Condition_HasVariable3d(_nativeInstance, variable3d.NativeVariable);
        }

        /// <summary>
        /// Extracts 1-dimensional variable value. <seealso cref="HasVariable1d"/> <seealso cref="GetVariable3d"/>
        /// </summary>
        /// <param name="variable1d">variable to extract</param>
        /// <returns>variable value</returns>
        public double GetVariable1d(Variable1d variable1d) {
            return variable1d.VariableType == VariableType.Standard
                ? NativeCondition.Condition_GetVariable1d(_nativeInstance, variable1d.NativeVariable)
                : NativeCondition.Condition_GetVariableComponent(_nativeInstance, variable1d.NativeVariable);
        }

        /// <summary>
        /// Extracts 3-dimensional variable value. <seealso cref="HasVariable3d"/> <seealso cref="GetVariable1d"/>
        /// </summary>
        /// <param name="variable3d">variable to extract</param>
        /// <returns>array with 3 variable values in order X Y Z</returns>
        public double[] GetVariable3d(Variable3d variable3d) {
            IntPtr values = NativeCondition.Condition_GetVariable3d(_nativeInstance, variable3d.NativeVariable);
            double[] unmarshalledResults = Utils.Utils.UnmarshalNativeDoubles(values, 3);
            NativeUtilities.Utils_FreeDoubleArray(values);
            return unmarshalledResults;
        }
    }
}