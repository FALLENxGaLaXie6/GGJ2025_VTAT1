using System.Collections;
using System.Collections.Generic;
using GameRuntime.Fluid;
using Scriptable_Objects;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Faucet
{
    public class DropletSpawning : MonoBehaviour
    {
        [ListDrawerSettings(ShowFoldout = true, DraggableItems = true, ShowIndexLabels = true)] [SerializeField]
        private List<ParticleTypeData> possibleParticleTypes;

        private ParticleTypeData _faucetMainParticleType;

        [SerializeField] private FaucetSound faucetSound;

        [SerializeField] private Transform spawnPoint;
        [SerializeField] private GameObject dropletPrefab;
        [SerializeField] float spawnInterval = 0.2f; // Interval in seconds
        [SerializeField] float particleLifetime = 15f; // Lifetime of the particles in seconds

        [SerializeField] float forceAmount = 10f; // Amount of force to apply
        [SerializeField] float coneAngle = 30f; // Angle of the cone in degrees
        [SerializeField] float baseAngleOffset = -15f; // Base angle offset for the faucet direction

        private InputActions _InputActions;
        private Coroutine _SpawnCoroutine;

        private void Awake()
        {
            // Initialize the InputActions
            _InputActions = new InputActions();
        }

        private void Start()
        {
            _faucetMainParticleType = possibleParticleTypes[0];
        }

        private void OnEnable()
        {
            _faucetMainParticleType = possibleParticleTypes[0];
            // Enable the InputActions
            _InputActions.Enable();
            _faucetMainParticleType.SubscribeInputBasedOnType(_InputActions, OnSpewWaterButtonPressed, OnSpewWaterButtonReleased);
        }

        private void OnDisable()
        {
            // Disable the InputActions
            _InputActions.Disable();
            _faucetMainParticleType.UnsubscribeInputBasedOnType(_InputActions, OnSpewWaterButtonPressed, OnSpewWaterButtonReleased);
        }

        private void OnSpewWaterButtonPressed(InputAction.CallbackContext obj)
        {
            // Start spawning objects
            _SpawnCoroutine = StartCoroutine(SpawnObjects());
        }

        private void OnSpewWaterButtonReleased(InputAction.CallbackContext obj)
        {
            // Stop spawning objects
            if (_SpawnCoroutine == null) return;

            StopCoroutine(_SpawnCoroutine);
            _SpawnCoroutine = null;
        }

        private IEnumerator SpawnObjects()
        {
            while (true)
            {
                // Calculate a random angle within the cone, offset by the base angle
                float randomAngle = Random.Range(-coneAngle / 2f, coneAngle / 2f) + baseAngleOffset;
                float radians = randomAngle * Mathf.Deg2Rad;

                // Calculate the random direction based on the angle
                Vector2 randomDirection = new Vector2(Mathf.Sin(radians), -Mathf.Cos(radians)).normalized;

                // Generate a random multiplier for the force amount
                float forceVariation = Random.Range(0.3f, 1.7f); // ±20% variation
                float adjustedForce = forceAmount * forceVariation;

                // Select a random particle type
                ParticleTypeData particleTypeData = possibleParticleTypes[Random.Range(0, possibleParticleTypes.Count)];
                GameObject droplet = particleTypeData.SpawnParticle(spawnPoint.position, spawnPoint.rotation);

                faucetSound.PlayFaucetSound();

                // Apply force to the droplet
                Rigidbody2D rbComponent = droplet.GetComponent<Rigidbody2D>();
                if (rbComponent) rbComponent.AddForce(randomDirection * adjustedForce, ForceMode2D.Impulse);

                // Set particle type if applicable
                FluidParticle fluidParticle = droplet.GetComponent<FluidParticle>();
                if (fluidParticle) fluidParticle.SetParticleType(particleTypeData);

                fluidParticle.StartDestroyAfterLifeTimeCoroutine(fluidParticle, particleLifetime);

                // Wait for the spawn interval
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }
}
