using Scriptable_Objects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.PatronsUIStuff
{
    public class RecipeUIControl : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI recipeName;
        [SerializeField] private TextMeshProUGUI waterParticlesGoalNumberText;
        [SerializeField] private TextMeshProUGUI beerParticlesGoalNumberText;
        [SerializeField] private TextMeshProUGUI bubbleParticlesGoalNumberText;
        [SerializeField] private Image image;

        public void ChangeRecipeInfo(Recipe newRecipe)
        {
            recipeName.text = newRecipe.RecipeName;
            waterParticlesGoalNumberText.text = newRecipe.WaterGoal.ToString();
            beerParticlesGoalNumberText.text = newRecipe.BeerGoal.ToString();
            bubbleParticlesGoalNumberText.text = newRecipe.BubbleGoal.ToString();
            image.sprite = newRecipe.RecipeUITexture;
        }
    }
}