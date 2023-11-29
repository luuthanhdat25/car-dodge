using System;
using TMPro;
using UnityEngine;

namespace Moduler.UI
{
    public class MainGameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private void Start() => ScoreManager.Instance.OnScoreChanged += ScoreManager_OnScoreChange;

        private void ScoreManager_OnScoreChange(int i) => scoreText.text = "Score: " + i;
    }
}