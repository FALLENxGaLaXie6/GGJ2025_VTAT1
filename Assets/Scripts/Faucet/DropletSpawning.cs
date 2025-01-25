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


        private InputActions _inputActions;
        private Coroutine _spawnCoroutine;

        private void Awake() =>
            // Initialize the InputActions
            _inputActions = new InputActions();

        private void OnEnable()
        {
            // Enable the InputActions
            _inputActions.Enable();

            // Subscribe to the button hold action
            _inputActions.Faucet.SpewWater.started += OnSpewWaterButtonPressed;
            _inputActions.Faucet.SpewWater.canceled += OnSpewWaterButtonReleased;
        }


        private void OnDisable()
        {
            // Disable the InputActions
            _inputActions.Disable();

            // Subscribe to the button hold action
            _inputActions.Faucet.SpewWater.started -= OnSpewWaterButtonPressed;
            _inputActions.Faucet.SpewWater.canceled -= OnSpewWaterButtonReleased;
        }

        private void OnSpewWaterButtonPressed(InputAction.CallbackContext obj)
        {
            // Start spawning objects
            _spawnCoroutine = StartCoroutine(SpawnObjects());
        }

        private void OnSpewWaterButtonReleased(InputAction.CallbackContext obj)
        {
            // Stop spawning objects
            if(_spawnCoroutine == null) return;

            StopCoroutine(_spawnCoroutine);
            _spawnCoroutine = null;

        }

        private IEnumerator SpawnObjects()
        {
            while (true)
            {
                // Spawn the object
                GameObject droplet = Instantiate(dropletPrefab, spawnPoint.position, spawnPoint.rotation);

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