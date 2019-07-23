using System.Collections.Generic;

namespace libKratos.Utils.Quad {
    internal interface IQuadtreeNode {
        void Process(LinkedList<IndexedVertex2d> nodes, int depth, float x, float y, float radius,
            int maxDepth);

        (int, float) FindClosest(float x, float y);

        int GetCount();
    }
}