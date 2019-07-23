using System.Collections.Generic;
using System.Numerics;

namespace libKratos.Utils.Quad {
    /// <summary>
    /// Utility class for filtering object vertices before building <see cref="Quadtree"/>
    /// </summary>
    public class VertFilter {
        /// <summary>
        /// Filters vertices based on orientation of triangle faces.
        /// Will return only modes from faces "visible" from perspective defined by <paramref name="direction"/> vector.
        /// For face to be visible, it's nodes must be present in <paramref name="triangles"/> array in clockwise order when looking from given perspective.
        /// </summary>
        /// <param name="vertices">vertices to filter</param>
        /// <param name="triangles">Definition of object faces. It's length must always be a multiple of 3.
        /// First face contains nodes with indexes triangles[0], traingles[1], triangles[2]</param>
        /// <param name="direction">Filtering direction</param>
        /// <returns>
        /// List of <see cref="IndexedVertex2d"/>. Each <see cref="IndexedVertex2d"/> contains index from input <paramref name="vertices"/> array.
        /// </returns>
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