using System.Collections.Generic;
using System.Numerics;

namespace libKratos.Utils.Quad {
    internal class QuadtreeLeaf: IQuadtreeNode {
        private LinkedList<IndexedVertex2d> _nodes;
        private int _count;

        public void Process(LinkedList<IndexedVertex2d> nodes, int depth, float x, float y, float radius,
            int maxDepth) {
            _nodes = nodes;
            _count = _nodes.Count;
        }

        public (int, float) FindClosest(float x, float y) {
            var minDistance = float.MaxValue;
            var vertex = new Vector2(x, y);
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