using Audio.Runtime.AudioEvents;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Audio.Runtime.AudioComponents
{
    [RequireComponent(typeof(AudioSource))]
    public class BlokAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [InlineEditor][SerializeField] private AudioEvent bonkedAudioEvent;
        [InlineEditor][SerializeField] private AudioEvent blokImpactAudioEvent;
        [InlineEditor][SerializeField] private AudioEvent blokDestroyedAudioEvent;
        [InlineEditor][SerializeField] private AudioEvent blokSpawnAudioEvent;
        
        public void PlayBonkSound()
        {
            if (!bonkedAudioEvent)
            {
                Debug.LogWarning("Bonked audio event not set up!");
                return;
            }
            if (!audioSource)
            {
                Debug.LogWarning("Audio source not set up!");
                return;
            }
            bonkedAudioEvent.Play(audioSource);
        }

        public void PlayDestroySound()
        {
            if (!blokDestroyedAudioEvent)
            {
                Debug.LogWarning("Blok destroyed audio event not set up!");
                return;
            }
            if (!audioSource)
            {
                Debug.LogWarning("Audio source not set up!");
                return;
            }
            blokDestroyedAudioEvent.Play(audioSource);
        }
        
        public void PlaySpawnAudioEvent()
        {
            if (!blokSpawnAudioEvent)
            {
                Debug.LogWarning("Blok spawned audio event not set up!");
                return;
            }
            if (!audioSource)
            {
                Debug.LogWarning("Audio source not set up!");
                return;
            }
            blokSpawnAudioEvent.Play(audioSource);
        }

        public void PlayImpactSound()
        {
            if (!blokImpactAudioEvent)
            {
                Debug.LogWarning("Blok impact audio event not set up!");
                return;
            }
            if (!audioSource)
            {
                Debug.LogWarning("Audio source not set up!");
                return;
            }
            blokImpactAudioEvent.Play(audioSource);
        }
    }
}