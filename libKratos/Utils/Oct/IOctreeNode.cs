using System.Collections.Generic;

namespace libKratos.Utils.Oct {
    internal interface IOctreeNode {
        void Process(LinkedList<IndexedVertex> nodes, int depth, float x, float y, float z, float radius,
            int maxDepth);

        (int, float) FindClosest(float x, float y, float z);

        int GetCount();
    }
}