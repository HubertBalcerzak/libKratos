using System;
using LibKratos.Native;

namespace LibKratos {
    /// <summary>
    /// Wrapper over Kratos variable. Used as key for simulation result extraction. Obtain instance using <see cref="FromName"/>
    /// <seealso cref="Variable1d"/>
    /// </summary>
    public class Variable3d : IVariable {
        internal readonly IntPtr NativeVariable;
        public string Name { get; }

        private Variable3d(IntPtr nativeVariable, string name) {
            NativeVariable = nativeVariable;
            Name = name;
        }

        /// <summary>
        /// Creates 3-dimensional variable key using string name
        /// </summary>
        /// <param name="variableName">Kratos variable name, for example "DISPLACEMENT"</param>
        /// <returns>1-dimensional variable .</returns>
        public static Variable3d FromName(string variableName) {
            return HasName(variableName)
                ? new Variable3d(NativeVariables.Variable_Get3dVar(variableName), variableName)
                : null;
        }

        /// <summary>
        /// Checks whether variable with this name is registered in Kratos
        /// </summary>
        /// <param name="variableName">Name to check</param>
        /// <returns>true, if variable exists and <see cref="FromName"/> can be called.</returns>
        public static bool HasName(string variableName) {
            return NativeVariables.Variable_Has3dVar(variableName);
        }
    }
}