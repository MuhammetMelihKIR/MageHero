using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    public enum GameState
    {
        Menü,Play,SlotMachine,Win,Lose
    }
    
    private void Awake()
    {
        
        if(Instance==null)
        {
            Instance = this;
        }
        
    }
    
    

}
