using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    public static ComboSystem Instance { get; private set; }
    public float StreakLength;
    public int CurrentStreak = 0;
    public bool IsStreakOngoing;
    [SerializeField] private float _timer;
    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    private void Start()
    {
        _timer = StreakLength;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            IncreaseStreak();
        }
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            ResetStreak();
        }
    }

    public void IncreaseStreak()
    {
        IsStreakOngoing = true;
        ResetCounter();
        CurrentStreak++;
        print(CurrentStreak);
    }

    private void ResetCounter()
    {
        _timer = StreakLength;
    }

    private void ResetStreak()
    {
        CurrentStreak = 0;
        IsStreakOngoing = false;
    }
}
