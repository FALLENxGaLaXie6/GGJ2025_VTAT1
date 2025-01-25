using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace Faucet
{
    public class DropletSpawning : MonoBehaviour
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private GameObject dropletPrefab;
        [SerializeField] float spawnInterval = 0.2f; // Interval in seconds
        [SerializeField] float particleLifetime = 15f; // Lifetime of the particles in seconds

        [SerializeField] float forceAmount = 10f; // Amount of force to apply
        [SerializeField] float coneAngle = 30f; // Angle of the cone in degrees


        private InputActions _InputActions;
        private Coroutine _SpawnCoroutine;

        private void Awake()
        {
            // Initialize the InputActions
            _InputActions = new InputActions();
        }


        private void OnEnable()
        {
            // Enable the InputActions
            _InputActions.Enable();

            // Subscribe to the button hold action
            _InputActions.Faucet.SpewWater.started += OnSpewWaterButtonPressed;
            _InputActions.Faucet.SpewWater.canceled += OnSpewWaterButtonReleased;
        }


        private void OnDisable()
        {
            // Disable the InputActions
            _InputActions.Disable();

            // Subscribe to the button hold action
            _InputActions.Faucet.SpewWater.started -= OnSpewWaterButtonPressed;
            _InputActions.Faucet.SpewWater.canceled -= OnSpewWaterButtonReleased;
        }

        private void OnSpewWaterButtonPressed(InputAction.CallbackContext obj)
        {
            // Start spawning objects
            _SpawnCoroutine = StartCoroutine(SpawnObjects());
        }

        private void OnSpewWaterButtonReleased(InputAction.CallbackContext obj)
        {
            // Stop spawning objects
            if(_SpawnCoroutine == null) return;

            StopCoroutine(_SpawnCoroutine);
            _SpawnCoroutine = null;

        }

        private IEnumerator SpawnObjects()
        {
            while (true)
            {
                // Spawn the object
                GameObject droplet = Instantiate(dropletPrefab, spawnPoint.position, spawnPoint.rotation);

                float randomAngle = Random.Range(-coneAngle / 2f, coneAngle / 2f);
                float radians = randomAngle * Mathf.Deg2Rad;
                Vector2 randomDirection = new Vector2(Mathf.Sin(radians), -Mathf.Cos(radians)).normalized;

                // Generate a random multiplier for the force amount
                float forceVariation = Random.Range(0.2f, 1.8f); // ±20% variation
                float adjustedForce = forceAmount * forceVariation;

                Rigidbody2D rbComponent = droplet.GetComponent<Rigidbody2D>();
                if (rbComponent) rbComponent.AddForce(randomDirection * adjustedForce, ForceMode2D.Impulse);

                // Start a coroutine to destroy the particle after its lifetime
                StartCoroutine(DestroyAfterLifetime(droplet, particleLifetime));

                // Wait for the spawn interval
                yield return new WaitForSeconds(spawnInterval);
            }
        }

        private IEnumerator DestroyAfterLifetime(GameObject particle, float lifetime)
        {
            // Wait for the lifetime duration
            yield return new WaitForSeconds(lifetime);

            // Destroy the particle
            Destroy(particle);
        }


    }
}