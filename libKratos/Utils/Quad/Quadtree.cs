using System.Collections.Generic;
using System.Numerics;

namespace libKratos.Utils.Quad {
    /// <summary>
    /// QuadTree implementation
    /// </summary>
    public class Quadtree {
        private QuadtreeInternalNode _node;

        /// <summary>
        /// Initializes QuadTree.
        /// </summary>
        /// <param name="verts">Object vertices projected on a plane</param>
        /// <param name="radius">Radius of the object. Size o subsequent space divisions will depend on it</param>
        /// <param name="maxLevels">Maximum number of space divisions</param>
        /// <seealso cref="VertFilter"/>
        public Quadtree(Vector2[] verts, float radius, int maxLevels) {
            CreateQuadtree(verts, radius, maxLevels);
        }

        /// <summary>
        /// Initializes QuadTree
        /// </summary>
        /// <param name="verts">Object vertices projected on a plane</param>
        /// <param name="radius">Radius of the object. Size o subsequent space divisions will depend on it</param>
        /// <param name="maxLevels">Radius of the object. Size o subsequent space divisions will depend on it</param>
        public Quadtree(LinkedList<IndexedVertex2d> verts, float radius, int maxLevels) {
            CreateQuadTreeWithList(verts, radius, maxLevels);
        }

        /// <summary>
        /// Searches Quadtree for node closest to given point
        /// </summary>
        /// <param name="vertex">Point to find</param>
        /// <returns>Tuple, containg index of the closest found node and distance to that node from given point.</returns>
        public (int, float) Find(Vector2 vertex) {
            return _node.FindClosest(vertex.X, vertex.Y);
        }

        /// <summary>
        /// <inheritdoc cref="Find(System.Numerics.Vector2)"/>
        /// </summary>
        /// <param name="x">X coordinate of the point to find</param>
        /// <param name="y">Y coordinate of the point to find</param>
        /// <returns><inheritdoc cref="Find(System.Numerics.Vector2)"/></returns>
        public (int, float) Find(float x, float y) {
            return _node.FindClosest(x, y);
        }

        private void CreateQuadtree(Vector2[] verts, float radius, int maxLevels) {
            LinkedList<IndexedVertex2d> nodes = new LinkedList<IndexedVertex2d>();
            for (int i = 0; i < verts.Length; i++) nodes.AddLast(new IndexedVertex2d(i, verts[i]));

            _node = new QuadtreeInternalNode();
            _node.Process(nodes, 0, 0, 0, radius, maxLevels);
        }

        private void CreateQuadTreeWithList(LinkedList<IndexedVertex2d> nodes, float radius, int maxLevels) {
            _node = new QuadtreeInternalNode();
            _node.Process(nodes, 0, 0, 0, radius, maxLevels);
        }
    }
}