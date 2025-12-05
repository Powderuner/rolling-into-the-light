using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    
    public bool isGameOver = false;
    public Player playerObject;

    private void Awake()
    {
        instance = this;
    }
}
