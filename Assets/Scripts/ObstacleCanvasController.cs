using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObstacleCanvasController : MonoBehaviour
{
    private ObstacleController _obstacleController;
    
    [Space]
    [SerializeField] private TextMeshProUGUI infoTest;

    private void Awake()
    {
        _obstacleController = transform.parent.GetComponent<ObstacleController>();
    }

    private void Start()
    {
        SetInfoText();
    }

    private void SetInfoText()
    {
        infoTest.text = _obstacleController.decSizeNum + "x";
    }
}
