using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "Particle Type - Water Droplet", menuName = "Particle Type", order = 0)]
    public class ParticleTypeData : ScriptableObject
    {
        [field: SerializeField] public Color Color { get; private set; } = Color.blue;
        [field: SerializeField] public GameObject FluidParticle { get; private set;}

        [field: SerializeField] public ParticleType ParticleType { get; private set; } = ParticleType.Water;

        public GameObject SpawnParticle(Vector3 spawnPosition, Quaternion spawnRotation)
        {
            return Instantiate(FluidParticle, spawnPosition, spawnRotation);
        }

        public void SubscribeInputBasedOnType(InputActions inputActions, Action<InputAction.CallbackContext> subscriptionActionPressed, Action<InputAction.CallbackContext> subscriptionActionReleased)
        {
            switch (ParticleType)
            {
                case ParticleType.Water:
                    inputActions.Faucet.SpewWater.started += subscriptionActionPressed;
                    inputActions.Faucet.SpewWater.canceled += subscriptionActionReleased;
                    break;
                case ParticleType.Beer:
                    inputActions.Faucet.SpewBeer.started += subscriptionActionPressed;
                    inputActions.Faucet.SpewBeer.canceled += subscriptionActionReleased;
                    break;
                case ParticleType.Bubbles:
                    inputActions.Faucet.SpewBubbles.started += subscriptionActionPressed;
                    inputActions.Faucet.SpewBubbles.canceled += subscriptionActionReleased;
                    break;
            }
        }

        public void UnsubscribeInputBasedOnType(InputActions inputActions, Action<InputAction.CallbackContext> subscriptionActionPressed, Action<InputAction.CallbackContext> subscriptionActionReleased)
        {
            switch (ParticleType)
            {
                case ParticleType.Water:
                    inputActions.Faucet.SpewWater.started -= subscriptionActionPressed;
                    inputActions.Faucet.SpewWater.canceled -= subscriptionActionReleased;
                    break;
                case ParticleType.Beer:
                    inputActions.Faucet.SpewBeer.started -= subscriptionActionPressed;
                    inputActions.Faucet.SpewBeer.canceled -= subscriptionActionReleased;
                    break;
                case ParticleType.Bubbles:
                    inputActions.Faucet.SpewBubbles.started -= subscriptionActionPressed;
                    inputActions.Faucet.SpewBubbles.canceled -= subscriptionActionReleased;
                    break;
            }
        }
    }

    public enum ParticleType
    {
        Water,
        Beer,
        Bubbles
    }

}