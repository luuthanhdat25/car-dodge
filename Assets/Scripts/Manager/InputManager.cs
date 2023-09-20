using RepeatUtil.DesignPattern.SingletonPattern;
using System;
using UnityEngine;

namespace Manager
{
    public class InputManager : Singleton<InputManager>
    {
        public event EventHandler OnPauseAction;
        
        private float horizontalInputValue;

        private void Update()
        {
            HandleMovementInput();
            HandlePauseGameInput();
        }

        private void HandleMovementInput()
        {
            horizontalInputValue = 0;

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                horizontalInputValue = -1;

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                horizontalInputValue = 1;
        }
        
        private void HandlePauseGameInput()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                OnPauseAction?.Invoke(this, EventArgs.Empty);
        }

        public float GetHorizontalInputValue() => horizontalInputValue;
    }
}