using RepeatUtil.DesignPattern.SingletonPattern;
using System;
using UnityEngine;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        public event EventHandler OnGamePaused;
        public event EventHandler OnGameUnpaused;
        public event EventHandler OnGameOver; 

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
        //private float timePlayGameCounter;
        private bool isGamePause = false;

        [SerializeField] private float vehicleSpeed = 5f;
        [SerializeField] private float roadScrollSpeed = 0f;
        [SerializeField] private float spawnSpeed = 1.5f;
        [SerializeField] private float playerMoveSpeed = 2f;
        
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
            float deltaTime = Time.deltaTime;
            switch (state) {
                case State.WaitingToStart:
                    waitingToStartTimer -= deltaTime;
                    roadScrollSpeed -= deltaTime/20;
                    if (waitingToStartTimer <= 0)
                    {
                        state = State.CountdownToStart;
                    }
                    break;
                
                case State.CountdownToStart:
                    countdownToStartTimer -= deltaTime;
                    roadScrollSpeed -=deltaTime/50;
                    if (countdownToStartTimer <= 0)
                    {
                        state = State.GamePlaying;
                    }
                    break;
                case State.GamePlaying:
                    vehicleSpeed += deltaTime/20;
                    if(roadScrollSpeed > -0.5f) roadScrollSpeed -= deltaTime/150;
                    if(spawnSpeed > 0.3f) spawnSpeed -= deltaTime/60;
                    playerMoveSpeed += deltaTime/30;
                    break;
                case State.GameOver:
                    Debug.Log("Game Over");
                    break;
            }
        }

        public void GameOver()
        {
            state = State.GameOver;
            OnGameOver?.Invoke(this, EventArgs.Empty);
        }

        public bool IsGamePlaying() => state == State.GamePlaying;
        
        public bool IsCountDownToStartIsActive() => state == State.CountdownToStart;
        
        public bool IsGameOver() => state == State.GameOver;

        public float GetCountdownToStartTimer() => countdownToStartTimer;
        
        public float GetVehicleSpeed() => vehicleSpeed;
        
        public float GetRoadScrollSpeed() => roadScrollSpeed;
        
        public float GetSpawnSpeed() => spawnSpeed;
        
        public float GetPlayerMoveSpeed() => playerMoveSpeed;
    }
}