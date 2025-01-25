using UnityEngine;

public class VacuumRotationCorrector : MonoBehaviour
{

public float vacuumForce = 40f; // Adjust the strength of the vacuum force
    [SerializeField] private Transform cupTransform; // Reference to the cup's transform

    private void OnTriggerStay2D(Collider2D other)
    {
        // Ensure the object has a Rigidbody2D
        if (other.attachedRigidbody != null)
        {
            // Calculate the direction towards the cup
            Vector2 directionToCup = (Vector2)(cupTransform.position - other.transform.position);
            directionToCup.Normalize();

            // Apply a force towards the cup
            other.attachedRigidbody.AddForce(directionToCup * vacuumForce);
        }
    }

}