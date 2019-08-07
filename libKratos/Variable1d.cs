using System;
using LibKratos.Native;

namespace LibKratos {
    /// <summary>
    /// Wrapper over Kratos variable. Used as key for simulation result extraction. Obtain instance using <see cref="FromName"/>
    /// <seealso cref="Variable3d"/>
    /// </summary>
    public class Variable1d : IVariable {
        internal readonly IntPtr NativeVariable;
        internal readonly VariableType VariableType;
        public string Name { get; }

        private Variable1d(IntPtr nativeVariable, string name, VariableType variableType) {
            NativeVariable = nativeVariable;
            Name = name;
            VariableType = variableType;
        }

        /// <summary>
        /// Creates 1-dimensional variable key using string name
        /// </summary>
        /// <param name="variableName">Kratos variable name, for example "PRESSURE"</param>
        /// <returns>1-dimensional variable .</returns>
        public static Variable1d FromName(string variableName) {
            if (NativeVariables.Variable_Has1dVar(variableName))
                return new Variable1d(NativeVariables.Variable_Get1dVar(variableName), variableName,
                    VariableType.Standard);
            if (NativeVariables.Variable_HasVariableComponent(variableName))
                return new Variable1d(NativeVariables.Variable_GetVarComponent(variableName), variableName,
                    VariableType.Component);
            return null;
        }

        /// <summary>
        /// Checks whether variable with this name is registered in Kratos
        /// </summary>
        /// <param name="variableName">Name to check</param>
        /// <returns>true, if variable exists and <see cref="FromName"/> can be called.</returns>
        public static bool HasName(string variableName) {
            return NativeVariables.Variable_Has1dVar(variableName) ||
                   NativeVariables.Variable_HasVariableComponent(variableName);
        }
    }

    internal enum VariableType {
        Standard,
        Component
    }
}