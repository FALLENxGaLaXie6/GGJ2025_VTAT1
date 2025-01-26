using System;
using Scriptable_Objects;
using UnityEngine.Events;

namespace Events
{
    [Serializable]
    public class UnityRecipeEvent : UnityEvent<Recipe> {}
}