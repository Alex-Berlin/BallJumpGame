using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private ParticleSystem particles;
    private void OnEnable()
    {
        if (gameObject.GetComponent<ParticleSystem>() != null)
        {
            particles = gameObject.GetComponent<ParticleSystem>();
            FindObjectOfType<GroundChecker>().OnGroundTouch += EmitParticles;
            FindObjectOfType<PlayerDeath>().OnDeath += EmitParticles;
        }
    }

    private void EmitParticles()
    {
        if (particles != null)
            particles.Play();
    }
}
