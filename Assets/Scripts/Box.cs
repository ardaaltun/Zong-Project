using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour, IInteraction
{
    [SerializeField] private ParticleSystem _particle;

    public void Canvas(bool setVisible)
    {
        //we might need in the future
    }

    public void Interact()
    {

        PlayParticle();
    }

    private void PlayParticle()
    {
        _particle.startColor = transform.GetChild(0).GetComponent<MeshRenderer>().material.color;
        _particle.Play();
    }
}
