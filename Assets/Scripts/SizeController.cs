using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using DG.Tweening;
using UnityEngine;

public class SizeController : MonoSingleton<SizeController>
{
    [SerializeField] private Transform obj;
    [SerializeField] private Transform player;

    private Vector3 _scale;
    
    private Action _changeSizeAction;
    
    private float _size;

    private const float SetSizeAnimTime = 0.3f;
    
    private void Awake()
    {
        _scale = obj.localScale;

        LevelManager.Instance.AddMethodFinish(GetCoinFinal);
    }

    public void ChangeSize(float percent = 0.25f)
    {
        if (percent > 0)
            ObjectUpParticleController.Instance.PlayParticle(true);
        
        var objPos = obj.localPosition;
        var playerPos = player.localPosition;
        
        _size += percent;

        if (_size <= -1)
        {
            LevelManager.Instance.OnAction(ActionType.Fail);

            _size = -1;
        }

        var endScale = _scale + Vector3.up * _size;
        
        obj.DOScale(endScale, SetSizeAnimTime).OnComplete(() =>
        {
            if (endScale.y == 0)
            {
                obj.gameObject.SetActive(false);
            }
        });

        objPos.y = (1 + _size) / 2;
        playerPos.y = 1 + _size;

        obj.DOLocalMove(objPos, SetSizeAnimTime);
        player.DOLocalMove(playerPos, SetSizeAnimTime);

    }

    private void GetCoinFinal()
    {
        StartCoroutine(GetCoinFinalCoroutine());
    }

    private IEnumerator GetCoinFinalCoroutine()
    {
        var gainedCoin = (int) ((1 + _size) * 10);
        
        yield return new WaitForSeconds(0.5f);
        for (var i = 0; i < gainedCoin; i++)
        {
            ChangeSize(-0.1f);

            WorldToScreenCoin.Instance.CollectableCoin();
            
            yield return new WaitForSeconds(0.1f);
        }
        
        ResetSize();
    }

    private void ResetSize()
    {
        _size = -1;
        
        ChangeSize(0);
    }
}
