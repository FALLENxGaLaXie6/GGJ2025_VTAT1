using UnityEngine;

namespace GameRuntime.Test
{
    public class BallMovement : MonoBehaviour
    {
        public float moveSpeed = 5f; // Speed of the ball
        public float jumpForce = 5f; // Jump to force for the ball
        private Rigidbody _rb;

        void Start()
        {
            // Get the Rigidbody component attached to the ball
            _rb = GetComponent<Rigidbody>();
            if (_rb == null)
            {
                Debug.LogError("Rigidbody component not found. Please add a Rigidbody to the ball.");
            }
        }

        void Update()
        {
            // Get input for horizontal and vertical movement
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            // Move the ball
            Vector3 movement = new Vector3(moveX, 0, moveZ) * (moveSpeed * Time.deltaTime);
            _rb.MovePosition(transform.position + movement);

            // Jump when the space key is pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}