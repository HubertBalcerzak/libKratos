using System.Collections.Generic;
using System.Numerics;

namespace libKratos.Utils.Quad {
    public class VertFilter {
        public LinkedList<IndexedVertex2d> Filter(Vector3[] vertices, int[] triangles, Vector3 direction) {
            LinkedList<IndexedVertex2d> result = new LinkedList<IndexedVertex2d>();
            bool[] flags = new bool[vertices.Length];

            for (int i = 0; i < triangles.Length; i += 3) {
                var a = vertices[triangles[i]];
                var b = vertices[triangles[i + 1]];
                var c = vertices[triangles[i + 2]];

                var ab = b - a;
                var bc = c - b;

                var normal = Vector3.Cross(ab, bc);
                if (Vector3.Dot(normal, direction) > 0) {
                    flags[triangles[i]] = true;
                    flags[triangles[i + 1]] = true;
                    flags[triangles[i + 2]] = true;
                }
            }

            for (int i = 0; i < vertices.Length; i++) {
                if (flags[i]) result.AddLast(new IndexedVertex2d(i, new Vector2(vertices[i].X, vertices[i].Y)));
            }

            return result;
        }
    }
}