using System;
using LibKratos.Native;

namespace LibKratos {
    /// <summary>
    /// Provides translation between surface Ids used in <see cref="ModelPart"/> class and
    /// kratos Ids used in <see cref="KratosMesh"/> class.
    /// </summary>
    public class IdTranslator {
        private readonly IntPtr _nativeInstance;

        internal IdTranslator(IntPtr nativeInstance) {
            _nativeInstance = nativeInstance;
        }

        /// <summary>
        /// Translates surface node id to internal Kratos id.
        /// </summary>
        /// <param name="surfaceId">Surface id to translate</param>
        /// <returns>Kratos id of the same node or -1 when node does not exist.
        /// Can be used for operations in <see cref="KratosMesh"/> class</returns>
        public int GetKratosId(int surfaceId) {
            return NativeIdTranslator.Translator_GetKratosId(_nativeInstance, surfaceId);
        }

        /// <summary>
        /// Translates Kratos node id to surface node id. Node must be on the surface of current model part.
        /// </summary>
        /// <param name="kratosId">Kratos node id to translate</param>
        /// <returns>Surface node id or -1 when node does not exist.
        /// Can be used for operations in <see cref="ModelPart"/> class</returns>
        public int GetSurfaceId(int kratosId) {
            return NativeIdTranslator.Translator_GetSurfaceId(_nativeInstance, kratosId);
        }

        /// <summary>
        /// Checks whether node with this surface id exists in current model part.
        /// </summary>
        /// <param name="surfaceId">Id to check</param>
        /// <returns>true, if node exists</returns>
        public bool HasKratosId(int surfaceId) {
            return NativeIdTranslator.Translator_HasKratosId(_nativeInstance, surfaceId);
        }

        /// <summary>
        /// Checks whether node with this Kratos id exists in current model part.
        /// </summary>
        /// <param name="kratosId">Id to check</param>
        /// <returns>true, if node exists</returns>
        public bool HasSurfaceId(int kratosId) {
            return NativeIdTranslator.Translator_HasSurfaceId(_nativeInstance, kratosId);
        }
    }
}