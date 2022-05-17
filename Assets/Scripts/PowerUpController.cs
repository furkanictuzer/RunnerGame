using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    [SerializeField] private ParticleSystem speedParticle;

    private const float PowerUpTime = 5;

    private void Awake()
    {
        ParticleActivity(false);

        LevelManager.Instance.AddMethodFail(CloseParticle);
        LevelManager.Instance.AddMethodFinish(CloseParticle);
    }

    public void PowerUp()
    {
        StartCoroutine(PowerUpCoroutine());
    }

    private void CloseParticle()
    {
        speedParticle.Stop();
    }

    private IEnumerator PowerUpCoroutine()
    {
        MoveForward.Instance.SetSpeed(2);
        
        ParticleActivity(true);
        
        yield return new WaitForSeconds(PowerUpTime);

        MoveForward.Instance.SetSpeed(1);
        
        ParticleActivity(false);
    }
    
    private void ParticleActivity(bool activity)
    {
        switch (activity)
        {
            case true:
                speedParticle.Play();
                break;
            case false:
                speedParticle.Stop();
                break;
        }
    }
}
