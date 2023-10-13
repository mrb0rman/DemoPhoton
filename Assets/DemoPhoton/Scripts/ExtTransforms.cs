using UnityEngine;

namespace DemoPhoton.Scripts
{
    public static class ExtTransforms
    {
        public static void DestroyChildren(this Transform t, bool destroyImmediately = false)
        {
            foreach (Transform child in t)
            {
                if (destroyImmediately)
                {
                    MonoBehaviour.DestroyImmediate(child.gameObject);
                }
                else
                {
                    MonoBehaviour.Destroy(child.gameObject);
                }
            }
        }
    }
}