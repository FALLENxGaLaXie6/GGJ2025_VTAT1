using Scriptable_Objects;
using UnityEngine;

namespace UI
{
    public class RecipeProgressTrackingUIController : MonoBehaviour
    {
        [SerializeField] private TrackingBarUI beerTrackingBarUI;
        [SerializeField] private TrackingBarUI bubbleTrackingBarUI;
        [SerializeField] private TrackingBarUI waterTrackingBarUI;

        public void OnNewRecipeGiven(Recipe newRecipe)
        {
            beerTrackingBarUI.SetMaxParticles(newRecipe.BeerGoal);
            bubbleTrackingBarUI.SetMaxParticles(newRecipe.BubbleGoal);
            waterTrackingBarUI.SetMaxParticles(newRecipe.WaterGoal);
        }
    }
}