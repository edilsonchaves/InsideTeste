using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesEffect : MonoBehaviour
{
    public ParticleSystem[] particlesSystem;
    public void CestaPartcileSystem()
    {
        foreach(ParticleSystem particle in particlesSystem)
        {
            particle.Play(true);
        }
    }
}
