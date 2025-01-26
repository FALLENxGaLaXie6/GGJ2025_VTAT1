using UnityEngine;

namespace Audio
{
    public class MenuAudioManager : MonoBehaviour
    {
        private static MenuAudioManager _instance;

        private void Awake()
        {
            // Check if an instance already exists
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject); // Destroy duplicate
                return;
            }

            // Set this instance as the singleton
            _instance = this;

            // Prevent this object from being destroyed between scenes
            DontDestroyOnLoad(gameObject);
        }
    }
}