using System;
using System.Linq;
using System.Runtime.InteropServices;
using LibKratos.Native;

namespace LibKratos {
    public class KratosMesh {
        private readonly IntPtr _nativeModelPartInstance;
        public int MaxElementId => NativeModelPart.ModelPartWrapper_GetMaxElementId(_nativeModelPartInstance);
        public int MaxNodeId => NativeModelPart.ModelPartWrapper_GetMaxNodeId(_nativeModelPartInstance);
        public int NumberOfNodes => NativeModelPart.ModelPartWrapper_GetNumberOfNodes(_nativeModelPartInstance);
        public int NumberOfElements => NativeModelPart.ModelPartWrapper_GetNumberOfElements(_nativeModelPartInstance);

        public int NumberOfConditions =>
            NativeModelPart.ModelPartWrapper_GetNumberOfConditions(_nativeModelPartInstance);

        public KratosMesh(IntPtr nativeModelPartInstance) {
            _nativeModelPartInstance = nativeModelPartInstance;
        }

        public KratosNode CreateNode(int id, double x, double y, double z) {
            return new KratosNode(
                NativeModelPart.ModelPartWrapper_CreateNewNode(_nativeModelPartInstance, id, x, y, z));
        }

        public void AddNodes(int[] nodes) {
            NativeModelPart.ModelPartWrapper_AddNodes(_nativeModelPartInstance, nodes, nodes.Length);
        }

        public KratosNode GetNode(int id) {
            return new KratosNode(NativeModelPart.ModelPartWrapper_GetNode(_nativeModelPartInstance, id));
        }

        public KratosNode[] GetNodes() {
            IntPtr pNodes = NativeModelPart.ModelPartWrapper_GetNodes(_nativeModelPartInstance);
            int size = NativeModelPart.ModelPartWrapper_GetNodesCount(_nativeModelPartInstance);
            IntPtr[] unmarshaled = new IntPtr[size];
            Marshal.Copy(pNodes, unmarshaled, 0, size);
            return unmarshaled.Select(x => new KratosNode(x)).ToArray();
        }

        public void RemoveNode(int id) {
            NativeModelPart.ModelPartWrapper_RemoveNode(_nativeModelPartInstance, id);
        }


        public KratosElement CreateElement(string name, int id, int node1, int node2, int node3, int node4) {
            return CreateElement(name, id, new[] {node1, node2, node3, node4});
        }

        public KratosElement CreateElement(string name, int id, int[] nodes) {
            return new KratosElement(
                NativeModelPart.ModelPartWrapper_CreateNewElement(_nativeModelPartInstance, name, id, nodes));
        }

        public void AddElements(int[] elements) {
            NativeModelPart.ModelPartWrapper_AddElements(_nativeModelPartInstance, elements, elements.Length);
        }

        public KratosElement GetElement(int id) {
            return new KratosElement(NativeModelPart.ModelPartWrapper_GetElement(_nativeModelPartInstance, id));
        }

        public KratosElement[] GetElements() {
            IntPtr pElements = NativeModelPart.ModelPartWrapper_GetElements(_nativeModelPartInstance);
            int size = NativeModelPart.ModelPartWrapper_GetNumberOfElements(_nativeModelPartInstance);
            IntPtr[] unmarshaled = new IntPtr[size];
            Marshal.Copy(pElements, unmarshaled, 0, size);
            return unmarshaled.Select(x => new KratosElement(x)).ToArray();
        }

        public void RemoveElement(int id) {
            NativeModelPart.ModelPartWrapper_RemoveElement(_nativeModelPartInstance, id);
        }

        public void CreateCondition(String name, int[] nodeIds) {
            NativeModelPart.ModelPartWrapper_CreateNew2dCondition(_nativeModelPartInstance, name, nodeIds);
        }

        public void AddConditions(int[] conditionIds) {
            NativeModelPart.ModelPartWrapper_AddConditions(_nativeModelPartInstance, conditionIds, conditionIds.Length);
        }

        public KratosCondition GetCondition(int id) {
            return new KratosCondition(NativeModelPart.ModelPartWrapper_GetCondition(_nativeModelPartInstance, id));
        }

        public KratosCondition[] GetConditions() {
            IntPtr pConditions = NativeModelPart.ModelPartWrapper_GetConditions(_nativeModelPartInstance);
            int size = NativeModelPart.ModelPartWrapper_GetNumberOfConditions(_nativeModelPartInstance);
            IntPtr[] unmarshaled = new IntPtr[size];
            Marshal.Copy(pConditions, unmarshaled, 0, size);
            return unmarshaled.Select(x => new KratosCondition(x)).ToArray();
        }

        public void RemoveCondition(int id) {
            NativeModelPart.ModelPartWrapper_RemoveCondition(_nativeModelPartInstance, id);
        }
    }
}