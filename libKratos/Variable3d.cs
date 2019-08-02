using System;
using LibKratos.Native;

namespace LibKratos {
    public class Variable3d : IVariable {
        internal readonly IntPtr NativeVariable;
        public string Name { get; }

        private Variable3d(IntPtr nativeVariable, string name) {
            NativeVariable = nativeVariable;
            Name = name;
        }

        public static Variable3d FromName(string variableName) {
            return HasName(variableName)
                ? new Variable3d(NativeVariables.Variable_Get3dVar(variableName), variableName)
                : null;
        }

        public static bool HasName(string variableName) {
            return NativeVariables.Variable_Has3dVar(variableName);
        }
    }
}