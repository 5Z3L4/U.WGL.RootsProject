using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEditor;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    public static ComboSystem Instance { get; private set; }
    public float StreakLength;
    public int CurrentStreak = 0;
    public int ScoreMultiplier = 1;
    public List<int> MultiplierThresholds = new();
    [SerializeField] private GameObject _midPointPos;
    [SerializeField] private TMP_Text _comboTextLeft;
    [SerializeField] private TMP_Text _comboTextRight;
    [SerializeField] private float _timer;
    private TMP_Text _currentComboText;
    private int _currentThresholdIndex;
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
        _currentComboText = _comboTextLeft;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0 && CurrentStreak > 0)
        {
            ResetStreak();
        }
    }

    public void IncreaseStreak()
    {
        ResetCounter();
        CurrentStreak++;
        if (_currentThresholdIndex != MultiplierThresholds.Count-1 && CurrentStreak >= MultiplierThresholds[_currentThresholdIndex])
        {
            ScoreMultiplier++;
            if (_currentThresholdIndex < MultiplierThresholds.Count)
            {
                _currentThresholdIndex++;
            }
        }
        ChangeComboTextObject();
        var sequence = DOTween.Sequence()
            .Append(_currentComboText.DOFade(1, 0.1f))
            .Append(_currentComboText.transform.DOScale(new Vector3(1 + 0.2f, 1 + 0.2f, 1 + 0.2f), .1f))
            .Append(_currentComboText.transform.DOScale(1, .1f));
        sequence.Play();
        _currentComboText.text = $"COMBO {CurrentStreak} \n x{ScoreMultiplier}";
    }

    private void ResetCounter()
    {
        _timer = StreakLength;
    }

    private void ResetStreak()
    {
        CurrentStreak = 0;
        _currentThresholdIndex = 0;
        ScoreMultiplier = 1;
        var sequence = DOTween.Sequence()
            .Append(_currentComboText.transform.DOScale(new Vector3(1 - 0.2f, 1 - 0.2f, 1 - 0.2f), .1f))
            .Append(_currentComboText.DOFade(0, 0.1f));
        sequence.Play();
        _currentComboText.text = $"COMBO {CurrentStreak} \n x{ScoreMultiplier}";
    }

    private void ChangeComboTextObject()
    {
        var sequence = DOTween.Sequence()
            .Append(_currentComboText.transform.DOScale(new Vector3(1 - 0.2f, 1 - 0.2f, 1 - 0.2f), .1f))
            .Append(_currentComboText.DOFade(0, 0.1f));
        sequence.Play();
        _currentComboText = _currentComboText == _comboTextLeft ? _comboTextRight : _comboTextLeft;
    }
}
