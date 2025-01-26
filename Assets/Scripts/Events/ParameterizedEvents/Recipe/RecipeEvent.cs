using Scriptable_Objects;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "New Recipe Event", menuName = "Game Events/Recipe Event", order = 0)]
    public class RecipeEvent : BaseGameEvent<Recipe> {}
}