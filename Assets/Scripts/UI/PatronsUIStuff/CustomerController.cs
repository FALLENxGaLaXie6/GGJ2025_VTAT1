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
        [SerializeField] private float gameStartPauseTime = 3f;

        private static readonly int EnterBarIndex = Animator.StringToHash("enterBar");
        private static readonly int LeaveBarIndex = Animator.StringToHash("leaveBar");
        [SerializeField] private Animator animator;


        [ListDrawerSettings(ShowFoldout = true, DraggableItems = true, ShowIndexLabels = true)] [SerializeField]
        private List<Recipe> possibleInitialRecipes;

        [SerializeField] private RecipeEvent recipeChosenEvent;

        private Recipe _initialRecipe;

        private void Start()
        {
            _initialRecipe = possibleInitialRecipes[Random.Range(0, possibleInitialRecipes.Count)];

            StartCoroutine(GameStartPause());
        }

        private IEnumerator GameStartPause()
        {
            yield return new WaitForSeconds(gameStartPauseTime);
            recipeChosenEvent?.Raise(_initialRecipe);
            EnterBar();
        }
        
        private void EnterBar()
        {
            animator.SetTrigger(EnterBarIndex);
        }

        private void ExitBar()
        {
            animator.SetTrigger(LeaveBarIndex);
        }
    }
}