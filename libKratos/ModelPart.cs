using System;
using System.Runtime.InteropServices;
using LibKratos.Native;

namespace LibKratos {
    public class ModelPart : IDisposable {
        private readonly IntPtr _nativeInstance;

        /// <summary>
        /// Allows direct interaction and modification of internal Kratos mesh
        /// </summary>
        public readonly KratosMesh KratosMesh;

        internal ModelPart(IntPtr nativeInstance) {
            _nativeInstance = nativeInstance;
            KratosMesh = new KratosMesh(nativeInstance);
        }


        /// <summary>
        /// Sets Kratos DISPLACEMENT variable for node with given id, so that its final position is equal to given xyz coordinates.
        /// </summary>
        public void UpdateNodePos(int nodeId, float x, float y, float z) {
            NativeModelPart.ModelPartWrapper_UpdateNodePos(_nativeInstance, nodeId, x, y, z);
        }


        /// <summary>
        /// Copies internal node coordinates of Kratos model into given arrays.
        /// </summary>
        /// <remarks>
        /// Coordinates of first node are (xCoordinates[0], yCoordinates[0], zCoordinates[0]).
        /// Remember to call <see cref="RetrieveResults"/> after each simulation.
        /// </remarks>
        /// <seealso cref="RetrieveResults"/>
        public void GetNodesPos(out float[] xCoordinates, out float[] yCoordinates, out float[] zCoordinates) {
            IntPtr pxValues = NativeModelPart.ModelPartWrapper_GetXCoordinates(_nativeInstance);
            IntPtr pyValues = NativeModelPart.ModelPartWrapper_GetYCoordinates(_nativeInstance);
            IntPtr pzValues = NativeModelPart.ModelPartWrapper_GetZCoordinates(_nativeInstance);

            int size = NativeModelPart.ModelPartWrapper_GetNodesCount(_nativeInstance);
            float[] xResult = new float[size];
            float[] yResult = new float[size];
            float[] zResult = new float[size];

            Marshal.Copy(pxValues, xResult, 0, size);
            Marshal.Copy(pyValues, yResult, 0, size);
            Marshal.Copy(pzValues, zResult, 0, size);

            xCoordinates = xResult;
            yCoordinates = yResult;
            zCoordinates = zResult;
        }


        /// <summary>
        /// Copies triangles of Kratos model into given array. Result length will always be a multiple of 3.
        /// </summary>
        public void GetTriangles(out int[] triangles) {
            IntPtr pTriangles = NativeModelPart.ModelPartWrapper_GetTriangles(_nativeInstance);
            int size = NativeModelPart.ModelPartWrapper_GetTrianglesCount(_nativeInstance);

            int[] unmarshaled = new int[size * 3];

            Marshal.Copy(pTriangles, unmarshaled, 0, size * 3);

            triangles = unmarshaled;
        }

        /// <summary>
        /// Enables collecting of Von Misses stress variable after each simulation.
        /// It can be then retrieved using <see cref="GetSurfaceStress"/> method
        /// </summary>
        public void EnableSurfaceStressResults() {
            NativeModelPart.ModelPartWrapper_EnableSurfaceStressResults(_nativeInstance);
        }


        /// <summary>
        /// Retrieves Von Misses stress values from last simulation.
        /// Before first invocation <see cref="EnableSurfaceStressResults"/> must be called.
        ///  Returns one float for every triangle in the same order, as in <see cref="GetTriangles"/>.
        /// Remeber to call <see cref="RetrieveResults"/> after each simulation.
        /// </summary>
        /// <param name="surfaceStresses">Results array.</param>
        /// <seealso cref="RetrieveResults"/>
        public void GetSurfaceStress(out float[] surfaceStresses) {
            IntPtr pReactions = NativeModelPart.ModelPartWrapper_GetSurfaceStress(_nativeInstance);
            int size = NativeModelPart.ModelPartWrapper_GetTrianglesCount(_nativeInstance);
            float[] unmarshaled = new float[size];
            Marshal.Copy(pReactions, unmarshaled, 0, size);
            surfaceStresses = unmarshaled;
        }

        /// <summary>
        /// Retrieves and stores simulation results like node positions or surface stresses. You should call this method
        /// after <see cref="Kratos.Calculate"/> and before <see cref="GetNodesPos"/> or <see cref="GetSurfaceStress"/>
        /// </summary>
        public void RetrieveResults() {
            NativeModelPart.ModelPartWrapper_RetrieveResults(_nativeInstance);
        }

        /// <summary>
        /// Creates empty Kratos submodel part. It's contents can be modified using <see cref="KratosMesh"/>
        /// </summary>
        /// <param name="name">Name of the new part. Must be uniqe.</param>
        /// <returns>Created submodel part.</returns>
        /// <seealso cref="HasSubmodelPart"/>
        /// <seealso cref="CreateSubModelPart"/>;
        public ModelPart CreateSubModelPart(string name) {
            return new ModelPart(NativeModelPart.ModelPartWrapper_CreateSubmodelPart(_nativeInstance, name));
        }

        /// <summary>
        /// Deletes and regenerates surface mesh. Useful after making changes with <see cref="KratosMesh"/>
        /// </summary>
        public void RecreateProcessedMesh() {
            NativeModelPart.ModelPartWrapper_RecreateProcessedMesh(_nativeInstance);
        }

        /// <summary>
        /// Checks if submodel part with given name exists
        /// </summary>
        /// <param name="name">Part name to check</param>
        /// <returns>true, if submodel part with this name exists</returns>
        public bool HasSubmodelPart(string name) {
            return NativeModelPart.ModelPartWrapper_HasSubmodelPart(_nativeInstance, name);
        }

        /// <summary>
        /// Returns existing submodel part
        /// </summary>
        /// <param name="name">Part name to find</param>
        /// <returns>Submodel part with given name</returns>
        /// <seealso cref="HasSubmodelPart"/>
        /// <seealso cref="CreateSubModelPart"/>
        public ModelPart GetSubmodelPart(string name) {
            return new ModelPart(NativeModelPart.ModelPartWrapper_GetSubmodelPart(_nativeInstance, name));
        }

        public void Dispose() {
            NativeModelPart.ModelPartWrapper_DisposeModelPartWrapper(_nativeInstance);
        }
    }
}