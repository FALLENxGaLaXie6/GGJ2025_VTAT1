using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "Customer SFX Data", menuName = "Customer/Customer SFX Data", order = 0)]
    public class CustomerSFXData : ScriptableObject
    {
        [field: SerializeField] public AudioClip GoodDrinkAudioClip { get; private set; }
        [field: SerializeField] public AudioClip BadDrinkAudioClip { get; private set; }
        [field: SerializeField] public AudioClip IntroAudioClip { get; private set; }


        public void PlayGoodDrinkAudioClip(AudioSource audioSource)
        {
            audioSource.clip = GoodDrinkAudioClip;
            audioSource.Play();
        }

        public void PlayBadDrinkAudioClip(AudioSource audioSource)
        {
            audioSource.clip = BadDrinkAudioClip;
            audioSource.Play();
        }

        public void PlayIntroAudioClip(AudioSource audioSource)
        {
            audioSource.clip = IntroAudioClip;
            audioSource.Play();
        }
    }
}