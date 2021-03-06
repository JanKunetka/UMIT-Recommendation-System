using System.Linq;
using UnityEngine;

namespace BoubakProductions.Core
{
    /// <summary>
    /// Extends the GameObject class with useful methods.
    /// </summary>
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Deletes all of this GameObjects's children.
        /// </summary>
        /// <param name="gObject"></param>
        public static void KillChildren(this GameObject gObject)
        {
            foreach (Transform child in gObject.transform)
            {
                if (child == gObject.transform) continue;
                GameObject.Destroy(child.gameObject);
            }
        }

        /// <summary>
        /// Get the amount of active children this object has.
        /// </summary>
        /// <param name="gObject">The object, who's children will be counted.</param>
        /// <returns>Children count.</returns>
        public static int GetChildCountActive(this GameObject gObject)
        {
            return gObject.transform.Cast<Transform>().Count(child => child.gameObject.activeSelf);
        }
    }
}