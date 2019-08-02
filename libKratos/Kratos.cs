using System;
using LibKratos.Native;

namespace LibKratos {
    /// <summary>
    /// Instance of Kratos. Before using initialize with <see cref="Init"/>, <see cref="InitWithMdpa"/> or <see cref="InitWithSettings"/>
    /// </summary>
    public class Kratos : IDisposable {
        public ModelPart MainModelPart { get; private set; }

        private readonly IntPtr _nativeInstance;

        public Kratos() {
            _nativeInstance = NativeKratos.Kratos_CreateInstance();
        }

        /// <summary>
        /// Initializes Kratos with model from given .mdpa file and loads parameters file.
        /// </summary>
        /// <param name="mdpaPath">Path to the .mdpa model file.</param>
        /// <param name="parametersJsonPath">Path to the ProjectParameters.json file.</param>
        public void Init(string mdpaPath, string parametersJsonPath) {
            NativeKratos.Kratos_Init(_nativeInstance, mdpaPath, parametersJsonPath);
            MainModelPart = new ModelPart(NativeKratos.Kratos_GetRootModelPart(_nativeInstance));
        }

        /// <summary>
        /// Initializes Kratos with model from given .mdpa file and default parameters.
        /// </summary>
        /// <param name="mdpaPath">Path to the .mdpa model file.</param>
        public void InitWithMdpa(string mdpaPath) {
            NativeKratos.Kratos_InitWithMDPA(_nativeInstance, mdpaPath);
            MainModelPart = new ModelPart(NativeKratos.Kratos_GetRootModelPart(_nativeInstance));
        }


        /// <summary>
        /// Initializes Kratos with given project parameters file. Will load mdpa defined in parameters.
        /// </summary>
        /// <param name="parametersJsonPath">Path to the ProjectParameters.json file.</param>
        public void InitWithSettings(string parametersJsonPath) {
            NativeKratos.Kratos_InitWithSettings(_nativeInstance, parametersJsonPath);
            MainModelPart = new ModelPart(NativeKratos.Kratos_GetRootModelPart(_nativeInstance));
        }


        /// <summary>
        /// Executes simulation and frees all fixed nodes.
        /// </summary>
        /// <seealso cref="ModelPart.RetrieveResults"/>
        /// <seealso cref="ModelPart.GetNodesPos"/>
        /// <seealso cref="ModelPart.GetSurfaceStress"/>
        public void Calculate() {
            NativeKratos.Kratos_Calculate(_nativeInstance);
        }

        public void Dispose() {
            NativeKratos.Kratos_DisposeKratos(_nativeInstance);
        }
    }
}