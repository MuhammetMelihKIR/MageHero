using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UıManager : MonoBehaviour
{
   public static UıManager Instance;

  
   private void Awake()
   {
      if (Instance==null)
      {
         Instance = this;
      }
   }

 
}
