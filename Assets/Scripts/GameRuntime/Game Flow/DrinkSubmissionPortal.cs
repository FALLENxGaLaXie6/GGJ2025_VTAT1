using System;
using System.Collections;
using Events;
using Scriptable_Objects;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GameRuntime.Game_Flow
{
    public class DrinkSubmissionPortal : MonoBehaviour
    {
        [SerializeField] private float waitTimeToKillDrinkParticleSystem = 1.5f;
        [SerializeField] private ParticleSystem goodDrinkServedParticleSystem;
        [SerializeField] private ParticleSystem badDrinkServedParticleSystem;
        [SerializeField] private VoidEvent _successfulDrinkMadeEvent;
        [SerializeField] private VoidEvent _failedDrinkMadeEvent;

        private Recipe _currentRecipe;
        private InputActions _InputActions;

        private bool _cupIsInScoringArea = false;

        private int _cupColliderCount = 0; // Counter for cup colliders

        private int _numBeerParticles = 0;
        private int _numWaterParticles = 0;
        private int _numBubblesParticles = 0;

        private float _lastSubmitTime = -1f; // Tracks the last time a drink was submitted
        private const float SubmitCooldown = 0.5f; // Cooldown duration in seconds


        private void Awake()
        {
            // Initialize the InputActions
            _InputActions = new InputActions();
        }

        private void OnEnable()
        {
            //_InputActions.Faucet.SubmitDrink.started += AttemptSubmitDrink;
        }

        private void OnDisable()
        {
            //_InputActions.Faucet.SubmitDrink.started -= AttemptSubmitDrink;
        }

        public void OnGoodDrinkServed()
        {
            Debug.LogWarning("Good drink served!");
            goodDrinkServedParticleSystem.Play();
            //StartCoroutine(WaitToKillGoodDrinkServedParticleSystem());
        }

        public void OnBadDrinkServed()
        {
            Debug.LogWarning("Bad drink served!");
            badDrinkServedParticleSystem.Play();
            //StartCoroutine(WaitToKillBadDrinkServedParticleSystem());
        }


        private IEnumerator WaitToKillGoodDrinkServedParticleSystem()
        {
            yield return new WaitForSeconds(waitTimeToKillDrinkParticleSystem);
        }

        private IEnumerator WaitToKillBadDrinkServedParticleSystem()
        {
            yield return new WaitForSeconds(waitTimeToKillDrinkParticleSystem);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && Time.time >= _lastSubmitTime + SubmitCooldown)
            {
                _lastSubmitTime = Time.time; // Update the last submit time
                AttemptSubmitDrink();
            }
        }

        private void AttemptSubmitDrink()
        {
            if (!_cupIsInScoringArea || !_currentRecipe) return;

            Debug.LogWarning("Trying to submit hoe!");
            // Check if the drink made is within the recipe's feasible range'
            if (_numBeerParticles < _currentRecipe.GetMinFeasibleBeer() ||
                _numBeerParticles > _currentRecipe.GetMaxFeasibleBeer() ||
                _numWaterParticles < _currentRecipe.GetMinFeasibleWater() ||
                _numWaterParticles > _currentRecipe.GetMaxFeasibleWater() ||
                _numBubblesParticles < _currentRecipe.GetMinFeasibleBubbles() ||
                _numBubblesParticles > _currentRecipe.GetMaxFeasibleBubbles())
            {
                _failedDrinkMadeEvent?.Raise();
                return;
            }

            _successfulDrinkMadeEvent?.Raise();
        }

        private void AttemptSubmitDrink(InputAction.CallbackContext context)
        {
            Debug.LogWarning("Trying to submit hoe!");
            int i = 0;
            if (!_cupIsInScoringArea || _currentRecipe == null) return;

            // Check if the drink made is within the recipe's feasible range'
            if (_numBeerParticles < _currentRecipe.GetMinFeasibleBeer() ||
                _numBeerParticles > _currentRecipe.GetMaxFeasibleBeer() ||
                _numWaterParticles < _currentRecipe.GetMinFeasibleWater() ||
                _numWaterParticles > _currentRecipe.GetMaxFeasibleWater() ||
                _numBubblesParticles < _currentRecipe.GetMinFeasibleBubbles() ||
                _numBubblesParticles > _currentRecipe.GetMaxFeasibleBubbles())
            {
                _failedDrinkMadeEvent?.Raise();
                return;
            }

            _successfulDrinkMadeEvent?.Raise();

            // Play a sound effect or animation for the submission confirmation
            // Example: SoundManager.Instance.PlaySoundEffect("CupSubmissionSuccess");
            // Example: AnimationManager.Instance.PlayAnimation("CupSubmissionSuccess");
        }

        public void SetRecipe(Recipe recipe)
        {
            _currentRecipe = recipe;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.transform.CompareTag("Cup")) return;

            _cupColliderCount++;
            if (!_cupIsInScoringArea)
            {
                _cupIsInScoringArea = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.transform.CompareTag("Cup")) return;

            _cupColliderCount--;
            if (_cupColliderCount <= 0)
            {
                _cupIsInScoringArea = false;
            }
        }

        public void AddToNumBeerParticles(int num)
        {
            _numBeerParticles += num;
        }

        public void AddToNumWaterParticles(int num)
        {
            _numWaterParticles += num;
        }

        public void AddToNumBubblesParticles(int num)
        {
            _numBubblesParticles += num;
        }

        public void RemoveFromNumberBeerParticles(int num)
        {
            _numBeerParticles -= num;
        }

        public void RemoveFromNumberWaterParticles(int num)
        {
            _numWaterParticles -= num;
        }

        public void RemoveFromNumberBubblesParticles(int num)
        {
            _numBubblesParticles -= num;
        }
    }
}