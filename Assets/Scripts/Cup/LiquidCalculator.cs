﻿using System;
using System.Collections.Generic;
using GameRuntime.Fluid;
using Scriptable_Objects;
using Sirenix.OdinInspector;
using UnityEngine;

public class LiquidCalculator : MonoBehaviour
{
    private Collider2D _collider;

    [Header("Particles in Cup")]
    [ShowInInspector, ReadOnly, DictionaryDrawerSettings(KeyLabel = "Particle Type", ValueLabel = "Count")]
    private Dictionary<ParticleType, int> _particlesInCup;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        _particlesInCup = new Dictionary<ParticleType, int>
        {
            { ParticleType.Water, 0 },
            { ParticleType.Beer, 0 },
            { ParticleType.Bubbles, 0 }
        };
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the entering object has a ParticleTypeComponent
        FluidParticle fluidParticle = other.GetComponent<FluidParticle>();
        if (fluidParticle == null) return;

        AddParticle(fluidParticle.ParticleTypeData.ParticleType);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the exiting object has a ParticleTypeComponent
        FluidParticle fluidParticle = other.GetComponent<FluidParticle>();
        if (fluidParticle == null) return;

        RemoveParticle(fluidParticle.ParticleTypeData.ParticleType);

    }
    
    private void AddParticle(ParticleType particleType)
    {
        if (!_particlesInCup.TryGetValue(particleType, out var value)) return;

        _particlesInCup[particleType]++;
        Debug.Log($"Added {particleType}. Total: {_particlesInCup[particleType]}");
    }
    
    private void RemoveParticle(ParticleType particleType)
    {
        if (!_particlesInCup.TryGetValue(particleType, out var value)) return;
        if(value <= 0) return;

        _particlesInCup[particleType]--;
        Debug.Log($"Removed {particleType}. Total: {_particlesInCup[particleType]}");
    }

}