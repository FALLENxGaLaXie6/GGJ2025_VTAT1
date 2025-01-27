using TMPro;
using UnityEngine;

namespace UI
{
    public class GameScoreUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _successfulScoreText;
        [SerializeField] private TextMeshProUGUI _failedScoreText;

        private int _successfulDrinksMade = 0;
        private int _failedDrinksMade = 0;

        public void SuccessfulDrinkMade()
        {
            _successfulDrinksMade++;
            _successfulScoreText.text = "Successful Drinks: " + _successfulDrinksMade.ToString();
        }

        public void FailedDrinkMade()
        {
            _failedDrinksMade++;
            _failedScoreText.text = "Failed Drinks: " + _failedDrinksMade.ToString();
        }
    }
}