using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{

   public bool OnTable;
   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.gameObject.CompareTag("Player"))
      {
         OnTable = true;
         Debug.Log(OnTable);
      }

  
   }
}
