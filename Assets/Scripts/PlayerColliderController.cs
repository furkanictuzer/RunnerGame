using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent?.GetComponent<ObstacleController>() != null)
        {
            var obstacle = other.transform.parent.GetComponent<ObstacleController>();
            
            var decreaseNum = -obstacle.decSizeNum;

            obstacle.Disappear();
            
            SizeController.Instance.ChangeSize(decreaseNum);
        }
        else if (other.GetComponent<CollectableObject>())
        {
            other.GetComponent<CollectableObject>().UseObject();
            
            SizeController.Instance.ChangeSize();
        }
        else if (other.GetComponent<FinishController>())
        {
            LevelManager.Instance.OnAction(ActionType.Finish);
        }
    }
}
