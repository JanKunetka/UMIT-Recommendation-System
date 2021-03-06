using UnityEngine;

namespace BoubakProductions.Core
{
    /// <summary>
    /// Turns a MonoBehaviour class, that inherits this into a Singleton.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class MonoSingleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;

        private static bool applicationIsQuitting = false;

        public static T GetInstance()
        {
            if (applicationIsQuitting) { return null; }

            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }

        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
            }
            else if (instance != this as T)
            {
                Destroy(gameObject);
            }
        }

        private void OnApplicationQuit()
        {
            applicationIsQuitting = true;
        }
    }
}