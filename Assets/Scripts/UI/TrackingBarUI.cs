using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TrackingBarUI : MonoBehaviour
    {
        [SerializeField] private Image frontBarImage;
        [SerializeField] private Image backBarImage;

        private float _lerpTimer;
        private float _chipSpeed = 2f;

        private int _currentParticles = 0;
        private int _maxParticles = 100;

        private void Start()
        {
            _currentParticles = 0;
        }

    }
}