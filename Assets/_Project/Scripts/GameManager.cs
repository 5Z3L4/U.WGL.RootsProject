using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Score = 0;
    public static event Action ScoreIncreased;

    public static void IncreasePoints(int multiplier)
    {
        Score += multiplier;
        ScoreIncreased?.Invoke();
    }
    
    public static void ResetScore()
    {
        Score = 0;
    }
}
