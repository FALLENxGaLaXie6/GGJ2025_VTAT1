using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    private ParticleSystem particleSystem;

    void Start()
    {
        // Get the Particle System component attached to this GameObject
        particleSystem = GetComponent<ParticleSystem>();
    }

    void FixedUpdate()
    {
        // Start the particle system when the left mouse button is held down
        if (Input.GetMouseButton(0)) // 0 is the left mouse button
        {
            if (!particleSystem.isPlaying) // Ensure it doesn't restart unnecessarily
            {
                particleSystem.Play();
                
            }
        }

        // Stop the particle system when the left mouse button is released
        if (Input.GetMouseButtonUp(0)) // 0 is the left mouse button
        {
            if (particleSystem.isPlaying) // Ensure it doesn't stop unnecessarily
            {
                particleSystem.Stop();
            }
        }
    }
}