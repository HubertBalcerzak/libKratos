using System;
using System.Runtime.InteropServices;
using LibKratos.Native;

namespace LibKratos {
    public class ModelPart : IDisposable {
        private readonly IntPtr _nativeInstance;
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
        /// </remarks>
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
        /// </summary>
        /// <param name="surfaceStresses">Results array.</param>
        public void GetSurfaceStress(out float[] surfaceStresses) {
            IntPtr pReactions = NativeModelPart.ModelPartWrapper_GetSurfaceStress(_nativeInstance);
            int size = NativeModelPart.ModelPartWrapper_GetTrianglesCount(_nativeInstance);
            float[] unmarshaled = new float[size];
            Marshal.Copy(pReactions, unmarshaled, 0, size);
            surfaceStresses = unmarshaled;
        }

        public void RetrieveResults() {
            NativeModelPart.ModelPartWrapper_RetrieveResults(_nativeInstance);
        }

        public ModelPart CreateSubModelPart(string name) {
            return new ModelPart(NativeModelPart.ModelPartWrapper_CreateSubmodelPart(_nativeInstance, name));
        }

        public void RecreateProcessedMesh() {
            NativeModelPart.ModelPartWrapper_RecreateProcessedMesh(_nativeInstance);
        }

        public bool HasSubmodelPart(string name) {
            return NativeModelPart.ModelPartWrapper_HasSubmodelPart(_nativeInstance, name);
        }

        public ModelPart GetSubmodelPart(string name) {
            return new ModelPart(NativeModelPart.ModelPartWrapper_GetSubmodelPart(_nativeInstance, name));
        }

        public void Dispose() {
            NativeModelPart.ModelPartWrapper_DisposeModelPartWrapper(_nativeInstance);
        }
    }
}