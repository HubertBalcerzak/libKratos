using System.Collections.Generic;
using System.Numerics;

namespace libKratos.Utils.Oct {
    public class Octree {
        private OctreeInternalNode _node;

        public Octree(Vector3[] verts, float radius, int maxLevels) {
            CreateOctree(verts, radius, maxLevels);
        }

        public (int, float) Find(Vector3 vertex) {
            return _node.FindClosest(vertex.X, vertex.Y, vertex.Z);
        }

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