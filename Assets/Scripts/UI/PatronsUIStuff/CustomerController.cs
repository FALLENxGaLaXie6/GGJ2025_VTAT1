using System.Collections;
using System.Collections.Generic;
using Events;
using Scriptable_Objects;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI.PatronsUIStuff
{
    public class CustomerController : MonoBehaviour
    {
        public bool IsActiveCustomer { get; private set; }



        private static readonly int EnterBarIndex = Animator.StringToHash("enterBar");
        private static readonly int LeaveBarIndex = Animator.StringToHash("leaveBar");
        [SerializeField] private Animator animator;
        [field: SerializeField] public CustomerSFXData CustomerSfxData { get; private set; }


        private void SetIsActiveCustomer(bool isActiveCustomer) => IsActiveCustomer = isActiveCustomer;


        public void EnterBar()
        {
            SetIsActiveCustomer(true);
            animator.SetTrigger(EnterBarIndex);
            CustomerSfxData.PlayIntroAudioClip(GetComponent<AudioSource>());
        }

        public void OnGoodDrinkMade()
        {
            if (!IsActiveCustomer) return;
            CustomerSfxData.PlayGoodDrinkAudioClip(GetComponent<AudioSource>());
        }

        public void OnBadDrinkMade()
        {
            if (!IsActiveCustomer) return;
            CustomerSfxData.PlayBadDrinkAudioClip(GetComponent<AudioSource>());
        }

        public void ExitBar()
        {
            SetIsActiveCustomer(false);
            animator.SetTrigger(LeaveBarIndex);
        }
    }
}