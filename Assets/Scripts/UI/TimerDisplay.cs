using TMPro;
using UnityEngine;

namespace UI
{
    public class TimerDisplay : MonoBehaviour
    {
        // Reference to the TextMeshProUGUI component
        [SerializeField] private TextMeshProUGUI timerText;

        // Elapsed time in seconds
        private float elapsedTime;

        private void Start()
        {
            // Initialize elapsed time
            elapsedTime = 0f;

            // Check if the timerText reference is set
            if (timerText == null)
            {
                Debug.LogError("Timer TextMeshProUGUI reference is not set!");
            }
        }

        private void Update()
        {
            // Increment elapsed time
            elapsedTime += Time.deltaTime;

            // Format and display the timer
            if (!timerText) return;

            timerText.text = FormatTime(elapsedTime);
        }

        // Format time as MM:SS
        private string FormatTime(float time)
        {
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            return $"{minutes:00}:{seconds:00}";
        }
    }
}