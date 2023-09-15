using System;
using UnityEngine;

namespace Moduler
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }
        private float horizontalInputValue;
        
        private void Awake()
        {
            if (Instance != null) Debug.LogError("InputManager is already initialized");
            Instance = this;
        }

        private void Update()
        {
            horizontalInputValue = 0;
            
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                horizontalInputValue = -1;

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                horizontalInputValue = 1;
        }

        public float GetHorizontalInputValue() => horizontalInputValue;
    }
}