using UnityEngine;

namespace Moduler
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        
        private void Awake()
        {
            if (Instance != null) Debug.LogError("InputManager is already initialized");
            Instance = this;
        }
    }
}