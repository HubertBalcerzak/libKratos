using System.Numerics;

namespace libKratos.Utils.Oct {
    public class IndexedVertex {
        public int Index;
        public Vector3 Vertex;

        public IndexedVertex(int index, Vector3 vertex) {
            Index = index;
            Vertex = vertex;
            
        }
    }
}