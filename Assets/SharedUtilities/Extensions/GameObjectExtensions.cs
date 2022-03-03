using System.Collections.Generic;
using UnityEngine;

namespace Psyfer.Utilities
{
    public static class GameObjectExtensionMethods
    {
        public static void SetLayerRecursively(this GameObject gameObject, int layer)
        {
            gameObject.layer = layer;
            foreach (Transform t in gameObject.transform)
                t.gameObject.SetLayerRecursively(layer);
        }

        public static void SetRenderersRecursively(this GameObject gameObject, bool enabled)
        {
            Renderer[] renderers = gameObject.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
                renderer.enabled = enabled;
        }

        public static void SetCollisionRecursively(this GameObject gameObject, bool enabled)
        {
            Collider[] colliders = gameObject.GetComponentsInChildren<Collider>();
            foreach (Collider collider in colliders)
                collider.enabled = enabled;
        }

        public static T[] GetComponentsInChildrenWithTag<T>(this GameObject gameObject, string tag) where T : Component
        {
            List<T> results = new();

            if (gameObject.CompareTag(tag))
                results.Add(gameObject.GetComponent<T>());

            foreach (Transform t in gameObject.transform)
                results.AddRange(t.gameObject.GetComponentsInChildrenWithTag<T>(tag));

            return results.ToArray();
        }

        public static IEnumerable<GameObject> GetChildrenOnly(this GameObject go)
        {
            if (go != null)
            {
                foreach (Transform tr in go.transform)
                    yield return tr.gameObject;
            }
        }

        public static void DeleteChildrenOnly(this GameObject go)
        {
            foreach (var child in GetChildrenOnly(go))
                Object.Destroy(child);
        }

        public static GameObject AddChild(this GameObject parent, GameObject prefab)
        {
            GameObject go = GameObject.Instantiate<GameObject>(prefab);
            go.transform.SetParent(parent.transform);
            return go;
        }

        public static T AddChild<T>(this GameObject parent, T prefab) where T : Component
        {
            T go = GameObject.Instantiate<T>(prefab);
            go.transform.SetParent(parent.transform);
            return go;
        }

        public static T AddComponent<T>(this Component c) where T : Component
        {
            return c.gameObject.AddComponent<T>();
        }

        public static T GetOrAddComponent<T>(this GameObject go) where T : Component
        {
            var ac = go.GetComponent<T>();
            if (ac == null)
            {
                ac = go.AddComponent<T>();
            }
            return ac;
        }

        public static T GetOrAddComponent<T>(this Component c) where T : Component
        {
            var ac = c.gameObject.GetComponent<T>();
            if (ac == null)
            {
                ac = c.gameObject.AddComponent<T>();
            }
            return ac;
        }
    }
}