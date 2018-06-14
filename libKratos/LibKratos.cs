using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace LibKratos
{
    public class Kratos
    {

        /// <summary>
        /// Initializes Kratos with model from given file.
        /// </summary>
        /// <param name="path">Path to model file.</param>
        public static void init(String path)
        {
            Native.Init(path);
        }

        /// <summary>
        /// Updates node positions according to given coordinates.
        /// </summary>
        /// <remarks>
        /// Coordinates of first node are (xCoordinates[0], yCoordinates[0], zCoordinates[0]).
        /// </remarks>
        /// <exception cref="System.ArgumentException">Thrown when paramenter arrays differ in length.</exception>
        public static void updateNodePos(float[] xCoordinates, float[] yCoordinates, float[] zCoordinates)
        {
            if (!(xCoordinates.Length == yCoordinates.Length && yCoordinates.Length == zCoordinates.Length))
                throw new ArgumentException("Coordinate arrays must not have different length");

            Native.UpdateNodesPos(xCoordinates, yCoordinates, zCoordinates);
        }

        /// <summary>
        /// Executes simulation. Result can be retrieved with <see cref="getNodesPos(out float[], out float[], out float[])" method./>
        /// </summary>
        public static void calculate() {
            Native.Calculate();
        }

        /// <summary>
        /// Copies internal node coordinates of Kratos model into given arrays.
        /// </summary>
        /// <remarks>
        /// Coordinates of first node are (xCoordinates[0], yCoordinates[0], zCoordinates[0]).
        /// </remarks>
        public static void getNodesPos(out float[] xCoordinates, out float[] yCoordinates, out float[] zCoordinates) {
            IntPtr pxValues = Native.GetXCoordinates();
            IntPtr pyValues = Native.GetYCoordinates();
            IntPtr pzValues = Native.GetZCoordinates();

            int size = Native.GetNodesCount();
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
        public static void getTriangles(out int[] triangles) {
            IntPtr pTriangles = Native.GetTriangles();
            int size = Native.GetTrianglesCount();

            int[] unmarshaled = new int[size * 3];

            Marshal.Copy(pTriangles, unmarshaled, 0, size * 3);

            triangles = unmarshaled;
        }
    }

    public class Native {
        [DllImport("KratosWrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void Init([MarshalAs(UnmanagedType.LPStr)]string path);
        
        //[DllImport("kratosWrapper.dll", CallingConvention = CallingConvention.StdCall)]
        //public static extern void InitFromExisting(float[] xCords, float[] yCords, float[] zCords, int modelSize);

        [DllImport("KratosWrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void UpdateNodesPos(float[] xCoordinates, float[] yCoordinates, float[] zCoordinates);

        [DllImport("KratosWrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void Calculate();

        [DllImport("KratosWrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetXCoordinates();

        [DllImport("KratosWrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetYCoordinates();

        [DllImport("KratosWrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetZCoordinates();

        [DllImport("KratosWrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetNodesCount();

        [DllImport("KratosWrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetTriangles();

        [DllImport("KratosWrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int GetTrianglesCount();
    }
}
