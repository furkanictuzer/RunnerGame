using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;

    [SerializeField] private int poolSize;
    
    private Queue<GameObject> _coinPool = new Queue<GameObject>();


    private void Awake()
    {
        for (var i = 0; i < poolSize; i++)
        {
            var obj = Instantiate(coinPrefab, transform, true);

            obj.SetActive(false);

            _coinPool.Enqueue(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        var obj = _coinPool.Dequeue();

        obj.SetActive(true);

        _coinPool.Enqueue(obj);

        return obj;
    }
}
