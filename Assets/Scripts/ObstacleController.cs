using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
   [Range(0,1)]
   [SerializeField] private float decreaseSizeConstant = 0.5f;
   
   public float decSizeNum => decreaseSizeConstant;

   public void Disappear()
   {
      gameObject.SetActive(false);
   }
}
