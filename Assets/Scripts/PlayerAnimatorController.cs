using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator _animator;
    
    private static readonly int Fail = Animator.StringToHash("Fail");
    private static readonly int Win = Animator.StringToHash("Win");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        
        LevelManager.Instance.AddMethodFail(SetFail);
        LevelManager.Instance.AddMethodFinish(SetWin);
    }

    private void SetFail()
    {
        _animator.SetTrigger(Fail);
    }

    private void SetWin()
    {
        _animator.SetTrigger(Win);
    }
}
