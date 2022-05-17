using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    private Transform coin;

    private const float TurnSpeed = 100;
    private void Awake()
    {
        coin = transform.GetChild(0);
    }

    private void Update()
    {
        var turnRatio = Vector3.up * Time.deltaTime * TurnSpeed;
        coin.Rotate(turnRatio);
    }

    public void UseObject()
    {
        gameObject.SetActive(false);
    }
}
