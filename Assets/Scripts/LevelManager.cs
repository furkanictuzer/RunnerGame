using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ActionType
{
   Fail,
   Finish
}

public class LevelManager : MonoSingleton<LevelManager>
{
   public int level= 1;

   private Action _fail, _finish;

   private bool _isFinish, _isFail;

   private void Awake()
   {
      if (GetLevel() == 0)
      {
         SetLevel();
      }
      else
      {
         level = GetLevel();
      }
      
      AddMethodFinish(NextLevel);
   }

   private void NextLevel()
   {
      level++;
      
      SetLevel();
   }

   private int GetLevel()
   {
      return PlayerPrefs.GetInt("Level");
   }

   private void SetLevel()
   {
      PlayerPrefs.SetInt("Level", level);
   }
   
   // ReSharper disable Unity.PerformanceAnalysis
   public void OnAction(ActionType actionType)
   {
      if (_isFinish || _isFail)
         return;
      
      switch (actionType)
      {
         case ActionType.Fail:
            _fail?.Invoke();
            _isFail = true;
            break;
         case ActionType.Finish:
            _finish?.Invoke();
            _isFinish = true;
            break;
         default:
            throw new ArgumentOutOfRangeException(nameof(actionType), actionType, null);
      }

      Debug.Log(actionType);
   }

   public void AddMethodFail(params Action[] methods)
   {
      foreach (var method in methods)
         _fail += method;
   }
   
   public void AddMethodFinish(params Action[] methods)
   {
      foreach (var method in methods)
         _finish += method;
   }
}
