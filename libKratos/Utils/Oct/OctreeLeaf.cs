using System.Collections.Generic;
using System.Numerics;

namespace libKratos.Utils.Oct {
    internal class OctreeLeaf : IOctreeNode {
        private LinkedList<IndexedVertex> _nodes;
        private int _count;

        public void Process(LinkedList<IndexedVertex> nodes, int depth, float x, float y, float z, float radius,
            int maxDepth) {
            _nodes = nodes;
            _count = _nodes.Count;
        }

        public (int, float) FindClosest(float x, float y, float z) {
            var minDistance = float.MaxValue;
            var vertex = new Vector3(x, y, z);
            var minIndex = -1;

            foreach (var node in _nodes) {
                var magnitude = (node.Vertex - vertex).Length();
                if (magnitude < minDistance) {
                    minIndex = node.Index;
                    minDistance = magnitude;
                }
            }

            return (minIndex, minDistance);
        }

        public int GetCount() {
            return _count;
        }
    }
}