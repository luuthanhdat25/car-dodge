using System;
using TMPro;
using UnityEngine;

namespace Moduler.UI
{
    public class MainGameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI scoreText;

        private void Start() => ScoreCounter.Instance.OnVehiclePassed += ScoreCounter_OnVehiclePassed;

        private void ScoreCounter_OnVehiclePassed(object sender, EventArgs e) => UpdateScore();

        private void UpdateScore()
        {
            scoreText.text = "Score: " + ScoreCounter.Instance.GetScore().ToString();
        }
    }
}