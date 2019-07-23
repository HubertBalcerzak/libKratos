using System;
using System.Runtime.InteropServices;

namespace LibKratos {
    public class Kratos {
        private IntPtr _nativeInstance;

        public Kratos() {
            _nativeInstance = Native.CreateInstance();
        }

        /// <summary>
        /// Initializes Kratos with model from given .mdpa file and loads parameters file.
        /// </summary>
        /// <param name="mdpaPath">Path to the .mdpa model file.</param>
        /// <param name="parametersJsonPath">Path to the ProjectParameters.json file.</param>
        public void Init(string mdpaPath, string parametersJsonPath) {
            Native.Init(_nativeInstance, mdpaPath, parametersJsonPath);
        }

        /// <summary>
        /// Initializes Kratos with model from given .mdpa file and default parameters.
        /// </summary>
        /// <param name="mdpaPath">Path to the .mdpa model file.</param>
        public void InitWithMDPA(string mdpaPath) {
            Native.InitWithMDPA(_nativeInstance, mdpaPath);
        }


        /// <summary>
        /// Initializes Kratos with given project parameters file. Will load mdpa defined in parameters.
        /// </summary>
        /// <param name="parametersJsonPath">Path to the ProjectParameters.json file.</param>
        public void InitWithSettings(string parametersJsonPath) {
            Native.InitWithSettings(_nativeInstance, parametersJsonPath);
        }

        /// <summary>
        /// Sets Kratos DISPLACEMENT variable for node with given id, so that its final position is equal to given xyz coordinates.
        /// </summary>
        public void UpdateNodePos(int nodeId, float x, float y, float z) {
            Native.UpdateNodePos(_nativeInstance, nodeId, x, y, z);
        }

        /// <summary>
        /// Executes simulation. Result can be retrieved with <see cref="GetNodesPos" /> and <see cref="GetSurfaceStress"/> methods.
        /// </summary>
        public void Calculate() {
            Native.Calculate(_nativeInstance);
        }

        /// <summary>
        /// Copies internal node coordinates of Kratos model into given arrays.
        /// </summary>
        /// <remarks>
        /// Coordinates of first node are (xCoordinates[0], yCoordinates[0], zCoordinates[0]).
        /// </remarks>
        public void GetNodesPos(out float[] xCoordinates, out float[] yCoordinates, out float[] zCoordinates) {
            IntPtr pxValues = Native.GetXCoordinates(_nativeInstance);
            IntPtr pyValues = Native.GetYCoordinates(_nativeInstance);
            IntPtr pzValues = Native.GetZCoordinates(_nativeInstance);

            int size = Native.GetNodesCount(_nativeInstance);
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
            IntPtr pTriangles = Native.GetTriangles(_nativeInstance);
            int size = Native.GetTrianglesCount(_nativeInstance);

            int[] unmarshaled = new int[size * 3];

            Marshal.Copy(pTriangles, unmarshaled, 0, size * 3);

            triangles = unmarshaled;
        }

        /// <summary>
        /// Enables collecting of Von Misses stress variable after each simulation.
        /// It can be then retrieved using <see cref="GetSurfaceStress"/> method
        /// </summary>
        public void EnableSurfaceStressResults() {
            Native.EnableSurfaceStressResults(_nativeInstance);
        }


        /// <summary>
        /// Retrieves Von Misses stress values from last simulation.
        /// Before first invocation <see cref="EnableSurfaceStressResults"/> must be called.
        ///  Returns one float for every triangle in the same order, as in <see cref="GetTriangles"/>.
        /// </summary>
        /// <param name="surfaceStresses">Results array.</param>
        public void GetSurfaceStress(out float[] surfaceStresses) {
            IntPtr pReactions = Native.GetSurfaceStress(_nativeInstance);
            int size = Native.GetTrianglesCount(_nativeInstance);
            float[] unmarshaled = new float[size];
            Marshal.Copy(pReactions, unmarshaled, 0, size);
            surfaceStresses = unmarshaled;
        }
    }
}