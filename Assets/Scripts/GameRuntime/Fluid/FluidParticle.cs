using System;
using Scriptable_Objects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameRuntime.Fluid
{
    public class FluidParticle : MonoBehaviour
    {
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
    }
}