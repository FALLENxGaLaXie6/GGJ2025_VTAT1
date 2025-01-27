using System.Collections;
using System.Collections.Generic;
using Events;
using Scriptable_Objects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UI.PatronsUIStuff
{
    public class CustomersOverallController : MonoBehaviour
    {
        [SerializeField] private float waitBetweenCustomers = 4f;
        [SerializeField] private float gameStartPauseTime = 3f;

        [ListDrawerSettings(ShowFoldout = true, DraggableItems = true, ShowIndexLabels = true)] [SerializeField]
        private List<Recipe> possibleInitialRecipes;

        [ListDrawerSettings(ShowFoldout = true, DraggableItems = true, ShowIndexLabels = true)] [SerializeField]
        private List<CustomerController> customerControllers;

        [SerializeField] private RecipeEvent recipeChosenEvent;

        private Recipe _currentRecipe;
        private CustomerController _currentCustomer;

        private void Start()
        {
            _currentRecipe = possibleInitialRecipes[Random.Range(0, possibleInitialRecipes.Count)];
            StartCoroutine(GameStartPause());
        }

        private IEnumerator GameStartPause()
        {
            yield return new WaitForSeconds(gameStartPauseTime);
            recipeChosenEvent?.Raise(_currentRecipe);
            _currentCustomer = customerControllers[Random.Range(0, customerControllers.Count)];
            _currentCustomer.EnterBar();
        }

        public void OnDrinkSubmitted()
        {
            _currentCustomer.ExitBar();

            StartCoroutine(NewCustomerOrder());
        }

        private IEnumerator NewCustomerOrder()
        {
            yield return new WaitForSeconds(waitBetweenCustomers);
            _currentCustomer = customerControllers[Random.Range(0, customerControllers.Count)];
            _currentCustomer.EnterBar();
            _currentRecipe = possibleInitialRecipes[Random.Range(0, possibleInitialRecipes.Count)];
            recipeChosenEvent?.Raise(_currentRecipe);
        }
    }
}