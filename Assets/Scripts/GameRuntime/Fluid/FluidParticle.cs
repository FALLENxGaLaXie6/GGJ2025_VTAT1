using System;
using System.Collections;
using Events;
using Scriptable_Objects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameRuntime.Fluid
{
    public class FluidParticle : MonoBehaviour
    {
        [SerializeField] private IntEvent OnAddBeerParticle;
        [SerializeField] private IntEvent OnAddWaterParticle;
        [SerializeField] private IntEvent OnAddBubblesParticle;

        [SerializeField] private IntEvent OnRemoveBeerParticle;
        [SerializeField] private IntEvent OnRemoveWaterParticle;
        [SerializeField] private IntEvent OnRemoveBubblesParticle;

        private static readonly int Color1 = Shader.PropertyToID("_Color");
        [InlineEditor] [field: SerializeField] private ParticleTypeData DefaultParticleTypeData { get; set; }
        public ParticleTypeData ParticleTypeData { get; private set; }

        private SpriteRenderer _SpriteRenderer;


        private void Awake()
        {
            _SpriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            // Set the particle type to the default type if none is provided
            ParticleTypeData = DefaultParticleTypeData;
        }

        public void SetParticleType(ParticleTypeData newParticleTypeData)
        {
            ParticleTypeData = newParticleTypeData;
            UpdateParticleColor();
        }

        private void UpdateParticleColor()
        {
            _SpriteRenderer.color = ParticleTypeData.Color;
            Material material = _SpriteRenderer.material;
            material.SetColor(Color1, ParticleTypeData.Color);
        }

        public void BroadcastParticleAddition(int numberOfParticles)
        {
            switch (ParticleTypeData.ParticleType)
            {
                case ParticleType.Beer:
                    OnAddBeerParticle?.Raise(numberOfParticles);
                    break;
                case ParticleType.Water:
                    OnAddWaterParticle?.Raise(numberOfParticles);
                    break;
                case ParticleType.Bubbles:
                    OnAddBubblesParticle?.Raise(numberOfParticles);
                    break;
            }
        }

        public void BroadcastParticleRemoval(int numberOfParticles)
        {
            switch (ParticleTypeData.ParticleType)
            {
                case ParticleType.Beer:
                    OnRemoveBeerParticle?.Raise(numberOfParticles);
                    break;
                case ParticleType.Water:
                    OnRemoveWaterParticle?.Raise(numberOfParticles);
                    break;
                case ParticleType.Bubbles:
                    OnRemoveBubblesParticle?.Raise(numberOfParticles);
                    break;
            }
        }

        public void StartDestroyAfterLifeTimeCoroutine(GameObject droplet, float particleLifetime)
        {
            // Destroy the droplet after its lifetime
            StartCoroutine(DestroyAfterLifetime(droplet, particleLifetime));
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