
using System.Numerics;

namespace libKratos.Utils.Quad {
    public class IndexedVertex2d {
        public int Index;
        public Vector2 Vertex;

        public IndexedVertex2d(int index, Vector2 vertex) {
            Index = index;
            Vertex = vertex;
        }
    }
}