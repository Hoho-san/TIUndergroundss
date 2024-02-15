using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem waterParticles;

    void Start()
    {
        // Get the ParticleSystem component
        waterParticles = GetComponent<ParticleSystem>();
    }

    // Function to stop the water dropping particles
    public void StopWaterParticles()
    {
        // Stop the particle system
        waterParticles.Stop();
    }

    public void PlayWaterPaticles()
    {
        waterParticles.Play();
    }
}