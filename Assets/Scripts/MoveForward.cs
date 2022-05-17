using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoSingleton<MoveForward>
{
    [Range(0,50)]
    [SerializeField] private float speed;

    private float _initSpeed;
    
    private bool _finish = false;

    private void Awake()
    {
        _initSpeed = speed;
        
        LevelManager.Instance.AddMethodFail(StopMove);
        LevelManager.Instance.AddMethodFinish(StopMove);

        TapToStartController.Instance.AddMethodTapToStart(StartMove);

        speed = 0;
    }

    private void Update()
    {
        if (_finish) return;
        
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }

    private void StartMove()
    {
        speed = _initSpeed;
    }

    private void StopMove()
    {
        _finish = true;
    }
    
    public void SetSpeed(float percent)
    {
        var newSpeed = _initSpeed * percent;

        LeanTween.value(speed, newSpeed, 0.3f).setOnUpdate(val =>
        {
            speed = val;
        });
    }
}
