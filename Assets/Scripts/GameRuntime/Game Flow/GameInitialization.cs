﻿using System;
using System.Collections.Generic;
using Events;
using Scriptable_Objects;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameRuntime.Game_Flow
{
    public class GameInitialization : MonoBehaviour
    {
        [ListDrawerSettings(ShowFoldout = true, DraggableItems = true, ShowIndexLabels = true)] [SerializeField]
        private List<Recipe> possibleInitialRecipes;

        [SerializeField] private RecipeEvent recipeChosenEvent;

        private Recipe _initialRecipe;

        private void Start()
        {
            _initialRecipe = possibleInitialRecipes[Random.Range(0, possibleInitialRecipes.Count)];
            recipeChosenEvent?.Raise(_initialRecipe);
        }
    }
}