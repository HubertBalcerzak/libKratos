using System.Collections.Generic;
using System.Numerics;

namespace libKratos.Utils.Quad {
    public class Quadtree {
        private QuadtreeInternalNode _node;

        public Quadtree(Vector2[] verts, float radius, int maxLevels) {
            CreateQuadtree(verts, radius, maxLevels);
        }

        public Quadtree(LinkedList<IndexedVertex2d> verts, float radius, int maxLevels) {
            CreateQuadTreeWithList(verts, radius, maxLevels);
        }

        public (int, float) Find(Vector2 vertex) {
            return _node.FindClosest(vertex.X, vertex.Y);
        }

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

        private void CreatQuadTree(LinkedList<IndexedVertex2d> verts, float radius, int maxLevels) {
            _node = new QuadtreeInternalNode();
            _node.Process(verts, 0, 0, 0, radius, maxLevels);
        }
    }
}