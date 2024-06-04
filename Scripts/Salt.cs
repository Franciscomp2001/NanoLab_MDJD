using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salt : MonoBehaviour
{
    public ParticleSystem SaltParticles;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Liquido")
        {
            SaltParticles.Play();
        }
    }
}
