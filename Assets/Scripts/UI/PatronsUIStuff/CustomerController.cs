using UnityEngine;
using UnityEngine.Serialization;

namespace UI.PatronsUIStuff
{
    public class CustomerController : MonoBehaviour
    {
        private static readonly int EnterBarIndex = Animator.StringToHash("enterBar");
        private static readonly int LeaveBarIndex = Animator.StringToHash("leaveBar");
        [SerializeField] private Animator animator;


        public void EnterBar()
        {
            animator.SetTrigger(EnterBarIndex);
        }

        public void ExitBar()
        {
            animator.SetTrigger(LeaveBarIndex);
        }
    }
}