using System.Collections.Generic;
using System.Numerics;

namespace libKratos.Utils.Oct {
    public class Octree {
        private OctreeInternalNode _node;

        /// <summary>
        /// Initializes QuadTree.
        /// </summary>
        /// <param name="verts">Object vertices projected on a plane</param>
        /// <param name="radius">Radius of the object. Size o subsequent space divisions will depend on it</param>
        /// <param name="maxLevels">Maximum number of space divisions</param>
        /// <seealso cref="Quad.Quadtree"/>
        public Octree(Vector3[] verts, float radius, int maxLevels) {
            CreateOctree(verts, radius, maxLevels);
        }

        /// <summary>
        /// Searches Octree for node closest to given point
        /// </summary>
        /// <param name="vertex">Point to find</param>
        /// <returns>Tuple, containing index of the closest found node and distance to that node from given point.</returns>
        public (int, float) Find(Vector3 vertex) {
            return _node.FindClosest(vertex.X, vertex.Y, vertex.Z);
        }

        /// <summary>
        /// <inheritdoc cref="Find(System.Numerics.Vector3)"/>
        /// </summary>
        /// <param name="x">X coordinate of the point to find</param>
        /// <param name="y">Y coordinate of the point to find</param>
        /// <param name="z">Z coordinate of the point to find</param>
        /// <returns><inheritdoc cref="Find(System.Numerics.Vector3)"/></returns>
        public (int, float) Find(float x, float y, float z) {
            return _node.FindClosest(x, y, z);
        }

        private void CreateOctree(Vector3[] verts, float radius, int maxLevels) {
            LinkedList<IndexedVertex> nodes = new LinkedList<IndexedVertex>();
            for (int i = 0; i < verts.Length; i++) nodes.AddLast(new IndexedVertex(i, verts[i]));

            _node = new OctreeInternalNode();
            _node.Process(nodes, 0, 0, 0, 0, radius, maxLevels);
        }
    }
}