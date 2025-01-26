using Scriptable_Objects;
using UnityEngine;

namespace Faucet
{
    [RequireComponent(typeof(AudioSource))]
    public class FaucetSound : MonoBehaviour
    {
        private AudioSource _audioSource;
        [field: SerializeField] public ParticleTypeData ParticleTypeData { get; private set; }

        private void Awake()
        {
            // Get the AudioSource component
            _audioSource = GetComponent<AudioSource>();
        }

        public void PlayFaucetSound()
        {
            if (_audioSource.isPlaying) return;
            _audioSource.clip = ParticleTypeData.ParticleTypeFaucetSound;
            _audioSource.Play();
        }

        public void StopFaucetSound()
        {
            if (!_audioSource.isPlaying) return;
            _audioSource.Stop();
        }
    }
}