using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FinalConfettiController : MonoBehaviour
{
    private List<ParticleSystem> _confetti = new List<ParticleSystem>();

    private void Awake()
    {
        _confetti = GetComponentsInChildren<ParticleSystem>().ToList();

        LevelManager.Instance.AddMethodFinish(Finish);
    }

    private void Start()
    {
        PlayConfetti(false);
    }

    private void Finish()
    {
        PlayConfetti(true);
    }

    private void PlayConfetti(bool play)
    {
        switch (play)
        {
            case true:
                foreach (var con in _confetti)
                    con.Play();
                break;
            case false:
                foreach (var con in _confetti)
                    con.Stop();
                break;
                
        }
    }
}
