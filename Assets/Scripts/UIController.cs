using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoSingleton<UIController>
{
    [SerializeField] private Canvas failCanvas, finishCanvas, gameInCanvas;
    [SerializeField] private Canvas tapToStartCanvas;

    [Space] 
    [SerializeField] private TextMeshProUGUI levelInfo;
    [SerializeField] private TextMeshProUGUI coinInfo;

    private const float FinishDelayTime = 5f;
    private const float FailDelayTime = 2f;

    private void Awake()
    {
        LevelManager.Instance.AddMethodFail(Fail);
        LevelManager.Instance.AddMethodFinish(Finish);

        TapToStartController.Instance.AddMethodTapToStart(TapToStart);
    }

    private void Start()
    {
        SetLevelInfo();

        SetCoinInfo(CoinManager.Instance.coin);
    }

    private void TapToStart()
    {
        StartCoroutine(ActivateCanvasCoroutine(tapToStartCanvas, false, 0));
    }

    private void SetLevelInfo()
    {
        levelInfo.text = "Level " + LevelManager.Instance.level;
    }
    
    private void Finish()
    {
        StartCoroutine(ActivateCanvasCoroutine(finishCanvas, true, FinishDelayTime));
    }

    private void Fail()
    {
        StartCoroutine(ActivateCanvasCoroutine(failCanvas, true, FailDelayTime));
        StartCoroutine(ActivateCanvasCoroutine(gameInCanvas, false, 0));
    }

    private static IEnumerator ActivateCanvasCoroutine(Behaviour canvas,bool activity, float delay)
    {
        yield return new WaitForSeconds(delay);

        canvas.enabled = activity;
    }

    public void SetCoinInfo(int coin)
    {
        coinInfo.text = coin.ToString();
    }
}
