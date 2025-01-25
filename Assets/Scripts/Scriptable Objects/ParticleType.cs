using Sirenix.OdinInspector;
using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "Particle Type - Water Droplet", menuName = "Particle Type", order = 0)]
    public class ParticleType : ScriptableObject
    {
        [field: SerializeField] public Color Color { get; private set; } = Color.blue;
    }
}