using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WorldToScreenCoin : MonoSingleton<WorldToScreenCoin>
{
    [SerializeField] private CoinPool coinPool;
    
    [Space]
    [SerializeField] private Transform coinImage;
    [SerializeField] private Transform objPos;

    private const float AnimTime = 0.2f;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }
    
    public void CollectableCoin()
    {
        var receivedPos = _camera.WorldToScreenPoint(objPos.position);
        var go = coinPool.GetPooledObject();

        go.transform.position = receivedPos;

        go.transform.DOMove(coinImage.position, AnimTime).OnComplete(() =>
        {
            CoinManager.Instance.IncreaseCoin();
            
            go.SetActive(false);
        });

    }

    private void GetCoinFromPool()
    {
        
    }
}
