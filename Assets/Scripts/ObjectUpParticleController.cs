using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectUpParticleController : MonoSingleton<ObjectUpParticleController>
{
    [SerializeField] private ParticleSystem objectUpParticle;

    private void Start()
    {
        PlayParticle(false);
    }

    public void PlayParticle(bool play)
    {
        switch (play)
        {
            case true:
                objectUpParticle.Play();
                break;
            case false:
                objectUpParticle.Pause();
                break;
        }
    }
}
