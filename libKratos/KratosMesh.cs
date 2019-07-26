using System;
using System.Runtime.InteropServices;
using LibKratos.Native;

namespace LibKratos {
    public class KratosMesh {
        private readonly IntPtr _nativeModelPartInstance;
        public int MaxElementId => NativeModelPart.GetMaxElementId(_nativeModelPartInstance);
        public int MaxNodeId => NativeModelPart.GetMaxNodeId(_nativeModelPartInstance);
        public int NumberOfNodes => NativeModelPart.GetNumberOfNodes(_nativeModelPartInstance);
        public int NumberOfElements => NativeModelPart.GetNumberOfElements(_nativeModelPartInstance);
        public int NumberOfConditions => NativeModelPart.GetNumberOfConditions(_nativeModelPartInstance);

        public KratosMesh(IntPtr nativeModelPartInstance) {
            _nativeModelPartInstance = nativeModelPartInstance;
        }

        public void CreateNode(int id, double x, double y, double z) {
            NativeModelPart.CreateNewNode(_nativeModelPartInstance, id, x, y, z);
        }

        public void AddNodes(int[] nodes) {
            NativeModelPart.AddNodes(_nativeModelPartInstance, nodes, nodes.Length);
        }

        public KratosNode GetNode(int id) {
            throw new NotImplementedException();
        }

        public KratosNode[] GetNodes() {
            throw new NotImplementedException();
        }

        public void RemoveNode(int id) {
            NativeModelPart.RemoveNode(_nativeModelPartInstance, id);
        }


        public void CreateElement(string name, int id, int node1, int node2, int node3, int node4) {
            CreateElement(name, id, new[] {node1, node2, node3, node4});
        }

        public void CreateElement(string name, int id, int[] nodes) {
            NativeModelPart.CreateNewElement(_nativeModelPartInstance, name, id, nodes);
        }

        public void AddElements(int[] elements) {
            NativeModelPart.AddElements(_nativeModelPartInstance, elements, elements.Length);
        }

        public KratosElement GetElement(int id) {
            throw new NotImplementedException();
        }

        public KratosElement[] GetElements() {
            throw new NotImplementedException();
        }

        public void RemoveElement(int id) {
            NativeModelPart.RemoveElement(_nativeModelPartInstance, id);
        }

        public void CreateCondition() {
            throw new NotImplementedException();
        }

        public void AddConditions() {
            throw new NotImplementedException();
        }

        public void GetCondition() {
            throw new NotImplementedException();
        }

        public void GetConditions() {
            throw new NotImplementedException();
        }

        public void RemoveCondition() {
            throw new NotImplementedException();
        }
    }
}