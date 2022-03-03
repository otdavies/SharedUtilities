using UnityEngine;

namespace Psyfer.Utilities
{
    public static class VectorExtensionMethods
    {
        /// Useful V2 -> V3 conversion functions ------
        public static Vector2 xy(this Vector3 v) => new(v.x, v.y);
        public static Vector3 WithX(this Vector3 v, float x) => new(x, v.y, v.z);
        public static Vector3 WithY(this Vector3 v, float y) => new(v.x, y, v.z);
        public static Vector3 WithZ(this Vector3 v, float z) => new(v.x, v.y, z);
        public static Vector2 WithX(this Vector2 v, float x) => new(x, v.y);
        public static Vector2 WithY(this Vector2 v, float y) => new(v.x, y);
        public static Vector3 WithZ(this Vector2 v, float z) => new(v.x, v.y, z);
        /// -------------------------------------------

        /// <summary>
        /// Multiples two vectors component-wise.
        /// </summary>
        public static Vector3 Multiply(this Vector3 v, Vector3 other) => new(v.x * other.x, v.y * other.y, v.z * other.z);

        /// <summary>
        /// The absolute value of the vector.
        /// </summary>
        public static Vector3 Abs(this Vector3 a) => new(Mathf.Abs(a.x), Mathf.Abs(a.y), Mathf.Abs(a.z));

        /// <summary> 
        /// Is the vector greater or equal to the other vector?
        /// </summary>
        public static bool IsGEqual(this Vector3 local, Vector3 other) => local.x >= other.x && local.y >= other.y && local.z >= other.z;

        /// <summary>
        /// Is the vector less or equal to the other vector?
        /// </summary>
        public static bool IsLEqual(this Vector3 local, Vector3 other) => local.x <= other.x && local.y <= other.y && local.z <= other.z;
    }
}