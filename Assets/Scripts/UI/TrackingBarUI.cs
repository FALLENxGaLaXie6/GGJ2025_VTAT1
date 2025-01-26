using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class TrackingBarUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMeshProParticleTracker;
        [SerializeField] private Image frontBarImage;
        [SerializeField] private Image backBarImage;
        [SerializeField] private float chipSpeed = 2f;

        private float _lerpTimer;

        private int _currentParticles;
        private int _maxParticles = 15;

        private void Start()
        {
            _currentParticles = 0;
        }

        private void Update()
        {
            _currentParticles = Mathf.Clamp(_currentParticles, 0, _maxParticles + 50);
            UpdateTrackingBarUI();
        }

        private void UpdateNumberParticlesText()
        {
            textMeshProParticleTracker.text = _currentParticles.ToString();
        }

        private void UpdateTrackingBarUI()
        {
            float fillFront = frontBarImage.fillAmount;
            float fillBack = backBarImage.fillAmount;
            float particlesFraction = _currentParticles / (float)_maxParticles;

            if (fillBack > particlesFraction)
            {
                frontBarImage.fillAmount = particlesFraction;
                backBarImage.color = Color.red;
                _lerpTimer += Time.deltaTime;
                float percentComplete = _lerpTimer / chipSpeed;
                percentComplete = percentComplete * percentComplete;
                backBarImage.fillAmount = Mathf.Lerp(fillBack, particlesFraction, percentComplete);
            }

            if (fillFront < particlesFraction)
            {
                backBarImage.color = Color.green;
                backBarImage.fillAmount = particlesFraction;
                _lerpTimer += Time.deltaTime;
                float percentComplete = _lerpTimer / chipSpeed;
                percentComplete = percentComplete * percentComplete;
                frontBarImage.fillAmount = Mathf.Lerp(fillFront, backBarImage.fillAmount, percentComplete);
            }
        }

        public void RemoveParticles(int numberRemoved)
        {
            _currentParticles -= numberRemoved;
            _lerpTimer = 0f;
            UpdateNumberParticlesText();
        }

        public void AddParticles(int numberAdded)
        {
            _currentParticles += numberAdded;
            _lerpTimer = 0f;
            UpdateNumberParticlesText();
        }

        public void SetMaxParticles(int maxParticles) => _maxParticles = maxParticles;
    }
}