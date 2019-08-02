using System;
using System.Linq;
using System.Runtime.InteropServices;
using LibKratos.Native;

namespace LibKratos {
    /// <summary>
    /// Provides tools for internal kratos mesh modifications. Note, that Ids used here are native for Kratos and
    /// different from those used in <see cref="ModelPart"/> class. 
    /// </summary>
    public class KratosMesh {
        private readonly IntPtr _nativeModelPartInstance;

        /// <summary>
        /// Highest current element id in whole Kratos model. <see cref="MaxElementId"/> + 1 can be safely used as new element id.
        /// </summary>
        /// <seealso cref="CreateElement(string,int,int[])"/>
        /// <seealso cref="CreateCondition"/>
        public int MaxElementId => NativeModelPart.ModelPartWrapper_GetMaxElementId(_nativeModelPartInstance);

        /// <summary>
        /// Highest current node id in whole Kratos model. <see cref="MaxNodeId"/> + 1 can be safely used as new node id.
        /// </summary>
        /// <seealso cref="CreateNode"/>
        public int MaxNodeId => NativeModelPart.ModelPartWrapper_GetMaxNodeId(_nativeModelPartInstance);

        /// <summary>
        /// Number of nodes in this model part
        /// </summary>
        public int NumberOfNodes => NativeModelPart.ModelPartWrapper_GetNumberOfNodes(_nativeModelPartInstance);

        /// <summary>
        /// Number of elements in this model part
        /// </summary>
        public int NumberOfElements => NativeModelPart.ModelPartWrapper_GetNumberOfElements(_nativeModelPartInstance);

        /// <summary>
        /// Number of conditions in this model part
        /// </summary>
        public int NumberOfConditions =>
            NativeModelPart.ModelPartWrapper_GetNumberOfConditions(_nativeModelPartInstance);

        public KratosMesh(IntPtr nativeModelPartInstance) {
            _nativeModelPartInstance = nativeModelPartInstance;
        }

        /// <summary>
        /// Creates and adds new node to the model part.
        /// </summary>
        /// <param name="id">Id of the new node. Must be unique in the whole model. <seealso cref="MaxNodeId"/></param>
        /// <param name="x">X coordinate of the new node</param>
        /// <param name="y">Y coordinate od the new node</param>
        /// <param name="z">Z coordinate of the new node</param>
        /// <returns>Created <see cref="KratosNode"/></returns>
        public KratosNode CreateNode(int id, double x, double y, double z) {
            return new KratosNode(
                NativeModelPart.ModelPartWrapper_CreateNewNode(_nativeModelPartInstance, id, x, y, z));
        }

        /// <summary>
        /// Adds nodes to this model part. They must already exist in the model.
        /// </summary>
        /// <param name="nodes">Ids of nodes to add</param>
        public void AddNodes(int[] nodes) {
            NativeModelPart.ModelPartWrapper_AddNodes(_nativeModelPartInstance, nodes, nodes.Length);
        }

        /// <summary>
        /// Searches this model part for node with given Kratos id.
        /// </summary>
        /// <param name="id">Kratos id of node to find. Note, that this is different from ids used in <see cref="ModelPart"/> class</param>
        /// <returns><see cref="KratosNode"/> with given id</returns>
        public KratosNode GetNode(int id) {
            return new KratosNode(NativeModelPart.ModelPartWrapper_GetNode(_nativeModelPartInstance, id));
        }

        /// <returns>All nodes in this model part</returns>
        public KratosNode[] GetNodes() {
            IntPtr pNodes = NativeModelPart.ModelPartWrapper_GetNodes(_nativeModelPartInstance);
            int size = NativeModelPart.ModelPartWrapper_GetNodesCount(_nativeModelPartInstance);
            IntPtr[] unmarshaled = new IntPtr[size];
            Marshal.Copy(pNodes, unmarshaled, 0, size);
            return unmarshaled.Select(x => new KratosNode(x)).ToArray();
        }

        /// <summary>
        /// Removes node from model part
        /// </summary>
        /// <param name="id">Id of the node to remove. Note, that this is different from ids used in <see cref="ModelPart"/> class</param>
        public void RemoveNode(int id) {
            NativeModelPart.ModelPartWrapper_RemoveNode(_nativeModelPartInstance, id);
        }

        /// <summary>
        /// Creates and adds new element to the model part
        /// </summary>
        /// <param name="name"> Kratos element name. For example "TotalLagrangianElement3D4N"</param>
        /// <param name="id">New Element Id. Must be unique in the whole model. <seealso cref="MaxElementId"/></param>
        /// <param name="node1">First node id</param>
        /// <param name="node2">Second node id</param>
        /// <param name="node3">Third node id</param>
        /// <param name="node4">Fourth node id</param>
        /// <returns></returns>
        public KratosElement CreateElement(string name, int id, int node1, int node2, int node3, int node4) {
            return CreateElement(name, id, new[] {node1, node2, node3, node4});
        }

        /// <summary>
        /// Creates and adds new element to the model part
        /// </summary>
        /// <param name="name">Kratos element name. For example "TotalLagrangianElement3D4N"</param>
        /// <param name="id">New element Id. Must be unique in the whole model. <seealso cref="MaxElementId"/></param>
        /// <param name="nodes">Node ids.</param>
        /// <returns>Created Element</returns>
        public KratosElement CreateElement(string name, int id, int[] nodes) { //TODO check array length
            return new KratosElement(
                NativeModelPart.ModelPartWrapper_CreateNewElement(_nativeModelPartInstance, name, id, nodes));
        }

        /// <summary>
        /// Adds elements to this model part. They must already exist in the model.
        /// </summary>
        /// <param name="elements">Element ids to add</param>
        public void AddElements(int[] elements) {
            NativeModelPart.ModelPartWrapper_AddElements(_nativeModelPartInstance, elements, elements.Length);
        }

        ///<summary>
        /// Searches model part for element with given id.
        /// </summary>
        /// <param name="id">Element id to find</param>
        /// <returns>Found element</returns>
        public KratosElement GetElement(int id) {
            return new KratosElement(NativeModelPart.ModelPartWrapper_GetElement(_nativeModelPartInstance, id));
        }

        /// <returns>All elements in the model part</returns>
        public KratosElement[] GetElements() {
            IntPtr pElements = NativeModelPart.ModelPartWrapper_GetElements(_nativeModelPartInstance);
            int size = NativeModelPart.ModelPartWrapper_GetNumberOfElements(_nativeModelPartInstance);
            IntPtr[] unmarshaled = new IntPtr[size];
            Marshal.Copy(pElements, unmarshaled, 0, size);
            return unmarshaled.Select(x => new KratosElement(x)).ToArray();
        }

        /// <summary>
        /// Removes element from this model part.
        /// </summary>
        /// <param name="id">Element id to remove</param>
        public void RemoveElement(int id) {
            NativeModelPart.ModelPartWrapper_RemoveElement(_nativeModelPartInstance, id);
        }

        /// <summary>
        /// Creates new condition and adds it to this model part.
        /// </summary>
        /// <param name="name">Kratos condition name. For example "SurfaceCondition3D3N"</param>
        /// <param name="id">New condition id. Must be unique in the whole model. <seealso cref="MaxElementId"/></param>
        /// <param name="nodeIds">Nodes of the new condition</param>
        public void CreateCondition(String name, int id, int[] nodeIds) {
            NativeModelPart.ModelPartWrapper_CreateNew2dCondition(_nativeModelPartInstance, name, id, nodeIds);
        }


        /// <summary>
        /// Adds conditions to this model part. They must already exist in the model.
        /// </summary>
        /// <param name="conditionIds">Ids of conditions to add</param>
        public void AddConditions(int[] conditionIds) {
            NativeModelPart.ModelPartWrapper_AddConditions(_nativeModelPartInstance, conditionIds, conditionIds.Length);
        }

        /// <summary>
        /// Searches model part for condition with given idd
        /// </summary>
        /// <param name="id">Id to find</param>
        /// <returns>Found condition</returns>
        public KratosCondition GetCondition(int id) {
            return new KratosCondition(NativeModelPart.ModelPartWrapper_GetCondition(_nativeModelPartInstance, id));
        }

        /// <returns>All conditions in this model part</returns>
        public KratosCondition[] GetConditions() {
            IntPtr pConditions = NativeModelPart.ModelPartWrapper_GetConditions(_nativeModelPartInstance);
            int size = NativeModelPart.ModelPartWrapper_GetNumberOfConditions(_nativeModelPartInstance);
            IntPtr[] unmarshaled = new IntPtr[size];
            Marshal.Copy(pConditions, unmarshaled, 0, size);
            return unmarshaled.Select(x => new KratosCondition(x)).ToArray();
        }

        /// <summary>
        /// Removes condition from this model part.
        /// </summary>
        /// <param name="id">Id of the condition to remove</param>
        public void RemoveCondition(int id) {
            NativeModelPart.ModelPartWrapper_RemoveCondition(_nativeModelPartInstance, id);
        }
    }
}