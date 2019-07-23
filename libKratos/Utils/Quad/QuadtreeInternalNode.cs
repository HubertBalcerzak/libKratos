using System.Collections.Generic;

namespace libKratos.Utils.Quad {
    internal class QuadtreeInternalNode : IQuadtreeNode {
        private IQuadtreeNode[] subTrees = new IQuadtreeNode[4];
        private int _count;
        private float _x;
        private float _y;
        private float _radius;


        public int GetCount() {
            return _count;
        }

        public void Process(LinkedList<IndexedVertex2d> nodes, int depth, float x, float y, float radius,
            int maxDepth) {
            _x = x;
            _y = y;
            _radius = radius;
            _count = nodes.Count;

            LinkedList<IndexedVertex2d>[] lists = new LinkedList<IndexedVertex2d>[4];
            for (int i = 0; i < 4; i++) lists[i] = new LinkedList<IndexedVertex2d>();

            foreach (var node in nodes) {
                var current = node.Vertex;
                lists[GetSubtreeIndex(current.X, current.Y)].AddLast(node);
            }


            for (int i = 0; i < 4; i++) {
                if (depth < maxDepth && lists[i].Count > 1) subTrees[i] = new QuadtreeInternalNode();
                else subTrees[i] = new QuadtreeLeaf();

                subTrees[i].Process(lists[i], depth + 1, GetX(i), GetY(i),
                    radius / 2, maxDepth);
            }
        }

        public (int, float) FindClosest(float x, float y) {
            var subtree = subTrees[GetSubtreeIndex(x, y)];
            if (subtree.GetCount() > 0) return subtree.FindClosest(x, y);
            else return FindClosestHere(x, y);
        }

        private (int, float) FindClosestHere(float x, float y) {
            int closestIndex = -1;
            float minDistance = float.MaxValue;
            for (int i = 0; i < 8; i++) {
                if (subTrees[i].GetCount() > 0) {
                    var res = subTrees[i].FindClosest(x, y);
                    if (res.Item2 < minDistance) {
                        minDistance = res.Item2;
                        closestIndex = res.Item1;
                    }
                }
            }

            return (closestIndex, minDistance);
        }

        private float GetX(int i) {
            i++;
            if (i > 2) return _x + _radius / 2f;
            return _x - _radius / 2f;
        }

        private float GetY(int i) {
            i++;
            if (i % 2 == 0) return _y + _radius / 2f;
            return _y - _radius / 2f;
        }

        private int GetSubtreeIndex(float targetX, float targetY) {
            if (targetY >= _y) {
                if (targetX >= _x) return 3;
                return 1;
            }
            else {
                if (targetX >= _x) return 2;
                return 0;
            }
        }
    }
}