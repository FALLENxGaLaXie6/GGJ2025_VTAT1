using Sirenix.OdinInspector;
using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "Particle Type - Water Droplet", menuName = "Particle Type", order = 0)]
    public class ParticleTypeData : ScriptableObject
    {
        [field: SerializeField] public Color Color { get; private set; } = Color.blue;
        [field: SerializeField] public GameObject FluidParticle { get; private set;}

        public GameObject SpawnParticle(Vector3 spawnPosition, Quaternion spawnRotation)
        {
            return Instantiate(FluidParticle, spawnPosition, spawnRotation);
        }
    }
}