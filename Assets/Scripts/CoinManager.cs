using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoSingleton<CoinManager>
{
    public int coin;

    private void Awake()
    {
        if (GetCoin() == 0)
        {
            SetCoin();
        }
        else
        {
            coin = GetCoin();
        }
    }

    private void SetCoin()
    {
        PlayerPrefs.SetInt("Coin", coin);
    }

    private int GetCoin()
    {
       return PlayerPrefs.GetInt("Coin");
    }

    public void IncreaseCoin(int x = 1)
    {
        coin += x;
        
        SetCoin();

        UIController.Instance.SetCoinInfo(coin);
    }
}
