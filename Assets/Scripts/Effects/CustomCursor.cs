using DG.Tweening;
using UnityEngine;

namespace Effects
{
    public class CustomCursor : MonoBehaviour
    {
        private Camera _camera;

        [SerializeField] private Texture2D customCursorTexture;
        [SerializeField] private ParticleSystem cursorParticleSystem;

        [Header("Tween Settings")]
        [SerializeField] private float scaleMin = 0.8f; // Minimum scale for the cursor
        [SerializeField] private float scaleMax = 1.2f; // Maximum scale for the cursor
        [SerializeField] private float tweenDuration = 0.5f; // Duration for the scale tween

        private Transform cursorTransform;

        private void Start()
        {
            _camera = Camera.main;

            // Set the custom cursor texture
            Cursor.SetCursor(customCursorTexture, Vector2.zero, CursorMode.Auto);

            // Use this GameObject's transform for scaling
            cursorTransform = transform;

            // Start cursor pulsing
            StartCursorTween();
        }

        private void Update()
        {
            // Update the position of the cursor to follow the mouse
            Vector3 mousePos = Input.mousePosition;
            mousePos = _camera.ScreenToWorldPoint(mousePos);
            cursorTransform.position = new Vector3(mousePos.x, mousePos.y, cursorTransform.position.z);

            // Update the particle system's position to follow the cursor
            if (cursorParticleSystem != null)
            {
                cursorParticleSystem.transform.position = cursorTransform.position;
            }
        }

        private void StartCursorTween()
        {
            // Tween the cursor's scale to create a pulsing effect
            cursorTransform.DOScale(Vector3.one * scaleMax, tweenDuration)
                .SetEase(Ease.InOutQuad)
                .SetLoops(-1, LoopType.Yoyo); // Ping-pong loop for pulsing
        }
    }
}