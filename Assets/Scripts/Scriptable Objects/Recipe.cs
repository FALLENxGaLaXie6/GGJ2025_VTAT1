using System;
using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "Drink Recipe", menuName = "Recipes/Drink Recipe", order = 0)]
    public class Recipe : ScriptableObject
    {
        [field: SerializeField] public string RecipeName { get; private set; } = "IPA Beer";

        [field: SerializeField, Range(0, 40), Tooltip("Optimal number of bubble particles in recipe.")]
        public int BubbleGoal { get; private set; } = 5;
        [field: SerializeField, Range(0, 100), Tooltip("It's a variation as a percentage.")]
        public float BubbleVariationPercentage { get; private set; } = 15f;

        [field: SerializeField, Range(0, 40), Tooltip("Optimal number of beer in recipe.")]
        public int BeerGoal { get; private set; } = 5;
        [field: SerializeField, Range(0, 100), Tooltip("It's a variation as a percentage.")]
        public float BeerVariationPercentage { get; private set; } = 15f;

        [field: SerializeField, Range(0, 40), Tooltip("Optimal number of beer in recipe.")]
        public int WaterGoal { get; private set; } = 5;
        [field: SerializeField, Range(0, 100), Tooltip("It's a variation as a percentage.")]
        public float WaterVariationPercentage { get; private set; } = 15f;

        [field: SerializeField] public Sprite RecipeUITexture { get; private set; }


        /// <summary>
        /// Comments for test commit
        /// </summary>
        /// <returns></returns>
        public int GetMaxFeasibleBubbles()
        {
            float bubbleVariation = BubbleVariationPercentage / 100f;
            return (int) Math.Ceiling(BubbleGoal * (1 + bubbleVariation));
        }

        public int GetMinFeasibleBubbles()
        {
            float bubbleVariation = BubbleVariationPercentage / 100f;
            return (int) Math.Floor(BubbleGoal * (1 - bubbleVariation));
        }

        public int GetMaxFeasibleBeer()
        {
            float beerVariation = BeerVariationPercentage / 100f;
            return (int) Math.Ceiling(BeerGoal * (1 + beerVariation));
        }

        public int GetMinFeasibleBeer()
        {
            float beerVariation = BeerVariationPercentage / 100f;
            return (int) Math.Floor(BeerGoal * (1 - beerVariation));
        }

        public int GetMaxFeasibleWater()
        {
            float waterVariation = WaterVariationPercentage / 100f;
            return (int) Math.Ceiling(WaterGoal * (1 + waterVariation));
        }

        public int GetMinFeasibleWater()
        {
            float waterVariation = WaterVariationPercentage / 100f;
            return (int)Math.Floor(WaterGoal * (1 - waterVariation));
        }
    }
}