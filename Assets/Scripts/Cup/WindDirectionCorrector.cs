using UnityEngine;

public class ParticleControl : MonoBehaviour
{
    private ParticleSystem particleSystem;

    [SerializeField] private Transform target;

    [SerializeField] float attractionForce = 5f;

    private ParticleSystem.Particle[] particles;


    void Start()
    {
        // Get the Particle System component attached to this GameObject
        particleSystem = GetComponent<ParticleSystem>();

        if (target == null)
        {
            Debug.LogError("Target not set for ParticleControl script!");
        }
    }

    void FixedUpdate()
    {
        if (particleSystem == null || target == null) return;

        // Initialize the particle array (only if needed)
        if (particles == null || particles.Length < particleSystem.main.maxParticles)
        {
            particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
        }

        // Get the particles currently active in the system
        int activeParticles = particleSystem.GetParticles(particles);

        // Loop through each particle and adjust its velocity
        for (int i = 0; i < activeParticles; i++)
        {
            // Calculate the direction to the target
            Vector3 directionToTarget = (target.position - particles[i].position).normalized;

            // Set the velocity toward the target
            particles[i].velocity = directionToTarget * attractionForce;
        }

        // Apply the changes back to the particle system
        particleSystem.SetParticles(particles, activeParticles);


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