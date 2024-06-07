using UnityEngine;

namespace Gamegaard.Singleton
{
    /// <summary>
    /// Defines a base class for creating a MonoBehaviour singleton pattern in Unity. This class ensures that only one instance of type T exists within the application.
    /// </summary>
    [DisallowMultipleComponent]
    public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviourSingleton<T>
    {
        private static T _instance;

        /// <summary>
        /// Indicates whether an instance of this Singleton already exists within the application.
        /// This property is used to check if the Singleton instance needs to be created or if it already exists, helping manage singleton integrity throughout the application lifecycle.
        /// </summary>
        public static bool HasInstance { get; private set; }

        /// <summary>
        /// Indicates whether the Awake() method of this Singleton has already been called by Unity.
        /// Returns <c>true</c> if already called; otherwise, <c>false</c>.
        /// </summary>
        public static bool IsAwakened { get; private set; }

        /// <summary>
        /// Indicates whether the Start() method of this Singleton has already been called by Unity.
        /// Returns <c>true</c> if already called; otherwise, <c>false</c>.
        /// </summary>
        public static bool IsStarted { get; private set; }

        /// <summary>
        /// Indicates whether the OnDestroy() method of this Singleton has already been called by Unity.
        /// Returns <c>true</c> if already called; otherwise, <c>false</c>.
        /// </summary>
        public static bool IsDestroyed { get; private set; }

        /// <summary>
        /// Provides a globally accessible instance of type T. Checks for an existing instance of T in the scene.
        /// If no instance is found, a new GameObject is created and the T component is attached to it.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (!HasInstance)
                {
                    _instance = FindOrCreateInstance();
                    HasInstance = true;
                }
                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if (!HasInstance)
            {
                _instance = (T)this;
                IsAwakened = true;
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
                return;
            }
        }

        protected virtual void Start()
        {
            if (IsStarted || _instance != this) return;
            IsStarted = true;
        }

        protected virtual void OnDestroy()
        {
            if (IsDestroyed || _instance != this) return;
            IsDestroyed = true;
        }

        private static T FindOrCreateInstance()
        {
            T instance = FindObjectOfType<T>();
            if (instance == null)
            {
                GameObject singletonObject = new GameObject(typeof(T).Name);
                instance = singletonObject.AddComponent<T>();
            }
            return instance;
        }
    }
}