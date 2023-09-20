using RepeatUtil.DesignPattern.SingletonPattern;
using System;
using UnityEngine;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        public event EventHandler OnStateChanged;
        public event EventHandler OnGamePaused;
        public event EventHandler OnGameUnpaused;
        
        private enum State
        {
            WaitingToStart,
            CountdownToStart,
            GamePlaying,
            GameOver,
        }
        
        private State state;
        private float waitingToStartTimer = 1f;
        private float countdownToStartTimer = 3f;
        private bool isGamePause = false;

        private float vehicleSpeed = 5f;
        
        private void Start()
        {
            InputManager.Instance.OnPauseAction += InputManager_OnPauseAction;
        }

        private void InputManager_OnPauseAction(object sender, EventArgs e)
            => TogglePauseGame();

        public void TogglePauseGame()
        {
            isGamePause = !isGamePause;
            if (isGamePause) {
                Time.timeScale = 0;
                OnGamePaused?.Invoke(this, EventArgs.Empty);
            }else {
                Time.timeScale = 1;
                OnGameUnpaused?.Invoke(this, EventArgs.Empty);
            }
        }
    
        private void Update()
        {
            switch (state)
            {
                case State.WaitingToStart:
                    waitingToStartTimer -= Time.deltaTime;
                    if (waitingToStartTimer <= 0)
                    {
                        state = State.CountdownToStart;
                        OnStateChanged?.Invoke(this, EventArgs.Empty);
                    }
                    break;
                
                case State.CountdownToStart:
                    countdownToStartTimer -= Time.deltaTime;
                    if (countdownToStartTimer <= 0)
                    {
                        state = State.GamePlaying;
                        OnStateChanged?.Invoke(this, EventArgs.Empty);
                    }
                    break;
                
                case State.GamePlaying:
                    break;
                case State.GameOver:
                    break;
            }
        }

        public bool IsGamePlaying() => state == State.GamePlaying;
        
        public bool IsCountDownToStartIsActive() => state == State.CountdownToStart;
        
        public bool IsGameOver() => state == State.GameOver;

        public float GetCountdownToStartTimer() => countdownToStartTimer;
        
        public float GetVehicleSpeed() => vehicleSpeed;
    }
}