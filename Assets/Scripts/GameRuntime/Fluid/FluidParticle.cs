using System;
using Scriptable_Objects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GameRuntime.Fluid
{
    public class FluidParticle : MonoBehaviour
    {
        private static readonly int Color1 = Shader.PropertyToID("_Color");
        [InlineEditor] [field: SerializeField] private ParticleType DefaultParticleType { get; set; }
        private ParticleType ParticleType { get; set; }

        private SpriteRenderer _SpriteRenderer;

        private void Awake()
        {
            _SpriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            // Set the particle type to the default type if none is provided
            ParticleType = DefaultParticleType;
        }

        public void SetParticleType(ParticleType newParticleType)
        {
            ParticleType = newParticleType;
            UpdateParticleColor();
        }

        private void UpdateParticleColor()
        {
            _SpriteRenderer.color = ParticleType.Color;
            Material material = _SpriteRenderer.material;
            material.SetColor(Color1, ParticleType.Color);
        }
    }
}