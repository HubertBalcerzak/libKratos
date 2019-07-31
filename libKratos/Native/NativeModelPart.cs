using System;
using System.Runtime.InteropServices;

namespace LibKratos.Native {
    internal class NativeModelPart {
        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void
            ModelPartWrapper_UpdateNodePos(IntPtr instance, int nodeId, float x, float y, float z);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ModelPartWrapper_GetXCoordinates(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ModelPartWrapper_GetYCoordinates(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ModelPartWrapper_GetZCoordinates(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int ModelPartWrapper_GetNodesCount(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ModelPartWrapper_GetTriangles(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int ModelPartWrapper_GetTrianglesCount(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int ModelPartWrapper_EnableSurfaceStressResults(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ModelPartWrapper_GetSurfaceStress(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern bool ModelPartWrapper_HasSubmodelPart(IntPtr instance,
            [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ModelPartWrapper_GetSubmodelPart(IntPtr instance,
            [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void ModelPartWrapper_RetrieveResults(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void ModelPartWrapper_RecreateProcessedMesh(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ModelPartWrapper_CreateSubmodelPart(IntPtr instance,
            [MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ModelPartWrapper_CreateNewNode(IntPtr instance, int id, double x, double y,
            double z);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ModelPartWrapper_CreateNewElement(IntPtr instance,
            [MarshalAs(UnmanagedType.LPStr)] string name,
            int id, [MarshalAs(UnmanagedType.LPArray)] int[] nodeIds);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ModelPartWrapper_CreateNew2dCondition(IntPtr instance,
            [MarshalAs(UnmanagedType.LPStr)] string name,
            [MarshalAs(UnmanagedType.LPArray)] int[] nodeIds);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void ModelPartWrapper_RemoveNode(IntPtr instance, int id);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void ModelPartWrapper_RemoveElement(IntPtr instance, int id);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void ModelPartWrapper_RemoveCondition(IntPtr instance, int id);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void ModelPartWrapper_AddNodes(IntPtr instance,
            [MarshalAs(UnmanagedType.LPArray)] int[] nodeIds,
            int nodeCount);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void ModelPartWrapper_AddElements(IntPtr instance,
            [MarshalAs(UnmanagedType.LPArray)] int[] elementIds,
            int nodeCount);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void ModelPartWrapper_AddConditions(IntPtr instance,
            [MarshalAs(UnmanagedType.LPArray)] int[] conditionIds,
            int conditionCount);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int ModelPartWrapper_GetMaxElementId(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int ModelPartWrapper_GetMaxNodeId(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ModelPartWrapper_GetNode(IntPtr instance, int id);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ModelPartWrapper_GetNodes(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int ModelPartWrapper_GetNumberOfNodes(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ModelPartWrapper_GetElement(IntPtr instance, int id);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ModelPartWrapper_GetElements(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int ModelPartWrapper_GetNumberOfElements(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ModelPartWrapper_GetCondition(IntPtr instance, int id);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr ModelPartWrapper_GetConditions(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int ModelPartWrapper_GetNumberOfConditions(IntPtr instance);

        [DllImport("KratosCSharpWrapperCore.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern void ModelPartWrapper_DisposeModelPartWrapper(IntPtr instance);
    }
}