using System.Collections.Generic;

namespace libKratos.Utils.Oct {
    internal class OctreeInternalNode : IOctreeNode {
        private IOctreeNode[] subTrees = new IOctreeNode[8];
        private int _count;
        private float _x;
        private float _y;
        private float _z;
        private float _radius;


        public int GetCount() {
            return _count;
        }

        public void Process(LinkedList<IndexedVertex> nodes, int depth, float x, float y, float z, float radius,
            int maxDepth) {
            _x = x;
            _y = y;
            _z = z;
            _radius = radius;
            _count = nodes.Count;

            LinkedList<IndexedVertex>[] lists = new LinkedList<IndexedVertex>[8];
            for (int i = 0; i < 8; i++) lists[i] = new LinkedList<IndexedVertex>();

            foreach (var node in nodes) {
                var current = node.Vertex;
                lists[GetSubtreeIndex(current.X, current.Y, current.Z)].AddLast(node);
            }



            for (int i = 0; i < 8; i++) {
                if (depth < maxDepth && lists[i].Count > 1) subTrees[i] = new OctreeInternalNode();
                else subTrees[i] = new OctreeLeaf();
                
                subTrees[i].Process(lists[i], depth + 1, GetX(i), GetY(i), GetZ(i),
                    radius / 2, maxDepth);
            }
        }

        public (int, float) FindClosest(float x, float y, float z) {
            var subtree = subTrees[GetSubtreeIndex(x, y, z)];
            if (subtree.GetCount() > 0) return subtree.FindClosest(x, y, z);
            else return FindClosestHere(x, y, z);
        }

        private (int, float) FindClosestHere(float x, float y, float z) {
            int closestIndex = -1;
            float minDistance = float.MaxValue;
            for (int i = 0; i < 8; i++) {
                if (subTrees[i].GetCount() > 0) {
                    var res = subTrees[i].FindClosest(x, y, z);
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
            if (i % 4 == 1 || i % 4 == 2) return _x - _radius / 2f;
            return _x + _radius / 2f;
        }

        private float GetY(int i) {
            i++;
            if (i < 5) return _y + _radius / 2f;
            return _y - _radius / 2f;
        }

        private float GetZ(int i) {
            i++;
            if (i % 2 == 0) return _z + _radius / 2f;
            return _z - _radius / 2f;
        }

        private int GetSubtreeIndex(float targetX, float targetY, float targetZ) {
            if (targetY >= _y) {
                if (targetX >= _x) {
                    if (targetZ >= _z) return 3;
                    return 2;
                }
                else {
                    if (targetZ >= _z) return 1;
                    return 0;
                }
            }
            else {
                if (targetX > _x) {
                    if (targetZ >= _z) return 7;
                    return 6;
                }
                else {
                    if (targetZ >= _z) return 5;
                    return 4;
                }
            }
        }
    }
}