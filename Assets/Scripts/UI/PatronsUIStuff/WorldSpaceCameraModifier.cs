using System;
using UnityEngine;

namespace UI.PatronsUIStuff
{
    public class WorldSpaceCameraModifier : MonoBehaviour
    {
        private Canvas _canvas;
        private void Awake()
        {
            _canvas = GetComponent<Canvas>();

        }

        private void Start()
        {
            _canvas.worldCamera = Camera.main;
        }
    }
}