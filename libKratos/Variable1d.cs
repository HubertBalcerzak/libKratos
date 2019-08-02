using System;
using LibKratos.Native;

namespace LibKratos {
    public class Variable1d : IVariable {
        internal readonly IntPtr NativeVariable;
        internal readonly VariableType VariableType;
        public string Name { get; }

        private Variable1d(IntPtr nativeVariable, string name, VariableType variableType) {
            NativeVariable = nativeVariable;
            Name = name;
            VariableType = variableType;
        }


        public static Variable1d FromName(string variableName) {
            if (NativeVariables.Variable_Has1dVar(variableName))
                return new Variable1d(NativeVariables.Variable_Get1dVar(variableName), variableName,
                    VariableType.Standard);
            if (NativeVariables.Variable_HasVariableComponent(variableName))
                return new Variable1d(NativeVariables.Variable_GetVarComponent(variableName), variableName,
                    VariableType.Component);
            return null;
        }

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