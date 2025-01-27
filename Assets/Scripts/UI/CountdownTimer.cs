using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class CountdownTimer : MonoBehaviour
{
    [Header("Timer Settings")]
    [SerializeField] private float countdownDuration = 180f; // Default is 3 minutes (180 seconds)
    [SerializeField] private TextMeshProUGUI timerText;      // Reference to the TextMeshProUGUI component

    [Header("Timer Events")]
    public UnityEvent onTimerEnd; // Event to trigger when the timer ends

    private float remainingTime;
    private bool isRunning;

    private void Start()
    {
        // Initialize the timer
        ResetTimer();
        StartTimer();
    }

    private void Update()
    {
        if (isRunning)
        {
            // Decrease the remaining time
            remainingTime -= Time.deltaTime;

            // Clamp the remaining time to zero
            if (remainingTime <= 0)
            {
                remainingTime = 0;
                isRunning = false;
                onTimerEnd?.Invoke(); // Trigger the event
            }

            // Update the displayed time
            UpdateTimerText();
        }
    }

    // Resets the timer to the default duration
    public void ResetTimer()
    {
        remainingTime = countdownDuration;
        UpdateTimerText();
    }

    // Starts the timer
    public void StartTimer()
    {
        isRunning = true;
    }

    // Pauses the timer
    public void PauseTimer()
    {
        isRunning = false;
    }

    // Updates the timer text
    private void UpdateTimerText()
    {
        if (!timerText) return;

        timerText.text = FormatTime(remainingTime);
    }

    // Formats the time as MM:SS
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return $"{minutes:00}:{seconds:00}";
    }
}