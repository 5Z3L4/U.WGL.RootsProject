using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public static WaterController Instance { get; set; }
    public bool CanTagEnemy;
    [SerializeField] private ParticleSystem _waterParticles;
    [SerializeField] private ParticleSystem _waterTrailParticles;
    [SerializeField] private ParticleSystem _waterSplashParticles;
    [SerializeField] private int _maxDecreaseStepsCount;
    [SerializeField] private float _delay;
    [SerializeField] private CircleCollider2D _col;
    private float _startingRateOverTime;
    private float _startingRateOverDistance;
    private int _counter;
    private float _waterParticleStartingSize;
    private float _waterTrailParticleStartingSize;
    private float _waterParticlesSizeDecreaseBasedOnStepCounts;
    private float _waterTrailParticlesSizeDecreaseBasedOnStepCounts;
    private float _waterParticlesRateOverTimeDecreaseBasedOnStepCounts;
    private float _waterTrailParticlesRateOverTimeDecreaseBasedOnStepCounts;
    private float _startingColSize;
    private float _colSizeDecrease;
    
    [SerializeField] private RootsManager _rootsManager;

    [SerializeField] private AudioSource _waterDecreasingSound;
    [SerializeField] private AudioSource _waterDisappearSound;

    private void Awake()
    {
        _rootsManager = FindObjectOfType<RootsManager>();
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
        _startingRateOverTime = _waterParticles.emission.rateOverTime.constant;
        _startingRateOverDistance = _waterTrailParticles.emission.rateOverDistance.constant;
        _waterParticleStartingSize = _waterParticles.main.startSize.constant;
        _waterTrailParticleStartingSize = _waterTrailParticles.main.startSize.constant;
        _counter = _maxDecreaseStepsCount;
        _waterParticlesSizeDecreaseBasedOnStepCounts = _waterParticleStartingSize / (_maxDecreaseStepsCount + 1);
        _waterTrailParticlesSizeDecreaseBasedOnStepCounts = _waterTrailParticleStartingSize / (_maxDecreaseStepsCount + 1);
        _waterParticlesRateOverTimeDecreaseBasedOnStepCounts = _startingRateOverTime / (_maxDecreaseStepsCount + 1);
        _waterTrailParticlesRateOverTimeDecreaseBasedOnStepCounts = _startingRateOverDistance / (_maxDecreaseStepsCount + 1);
        _startingColSize = _col.radius;
        _colSizeDecrease = _startingColSize / (_maxDecreaseStepsCount + 1);
    }

    public void DecreaseWater()
    {
        if (_counter > 1)
        {
            ParticleSystem.MainModule waterParticleMain = _waterParticles.main;
            ParticleSystem.MainModule waterTrailParticleMain = _waterTrailParticles.main;
            ParticleSystem.EmissionModule waterParticlesEmission = _waterParticles.emission;
            ParticleSystem.EmissionModule waterTrailParticlesEmission = _waterTrailParticles.emission;
            waterParticlesEmission.rateOverTime = new ParticleSystem.MinMaxCurve(waterParticlesEmission.rateOverTime.constant - _waterParticlesRateOverTimeDecreaseBasedOnStepCounts);
            waterTrailParticlesEmission.rateOverDistance = new ParticleSystem.MinMaxCurve(waterTrailParticlesEmission.rateOverDistance.constant - _waterTrailParticlesRateOverTimeDecreaseBasedOnStepCounts);
            waterParticleMain.startSize = new ParticleSystem.MinMaxCurve(waterParticleMain.startSize.constant - _waterParticlesSizeDecreaseBasedOnStepCounts);
            waterTrailParticleMain.startSize = new ParticleSystem.MinMaxCurve(waterTrailParticleMain.startSize.constant - _waterTrailParticlesSizeDecreaseBasedOnStepCounts);
            _col.radius -= _colSizeDecrease;
            _counter--;
            _waterDecreasingSound.Play();
        }
        else
        {
            CanTagEnemy = false;
            _col.enabled = false;
            StartCoroutine(StartWaterDelay());
            _waterDisappearSound.Play();
        }
    }

    private IEnumerator StartWaterDelay()
    {
        ParticleSystem.EmissionModule waterParticlesEmission = _waterParticles.emission;
        ParticleSystem.EmissionModule waterTrailParticlesEmission = _waterTrailParticles.emission;
        ParticleSystem.MainModule waterParticlesMainModule = _waterParticles.main;
        ParticleSystem.MainModule waterTrailParticlesMainModule = _waterTrailParticles.main;
        waterParticlesEmission.rateOverTime = new ParticleSystem.MinMaxCurve(0);
        waterTrailParticlesEmission.rateOverDistance = new ParticleSystem.MinMaxCurve(0);
        waterParticlesMainModule.startSize = new ParticleSystem.MinMaxCurve(0);
        waterTrailParticlesMainModule.startSize = new ParticleSystem.MinMaxCurve(0);
        _waterSplashParticles.Play();
        yield return new WaitUntil(()=> _rootsManager.Targets.Count == 0);
        yield return new WaitForSeconds(_delay);
        waterParticlesEmission.rateOverTime = new ParticleSystem.MinMaxCurve(_startingRateOverTime);
        waterTrailParticlesEmission.rateOverDistance = new ParticleSystem.MinMaxCurve(_startingRateOverDistance);
        waterParticlesMainModule.startSize = new ParticleSystem.MinMaxCurve(_waterParticleStartingSize);
        waterTrailParticlesMainModule.startSize = new ParticleSystem.MinMaxCurve(_waterTrailParticleStartingSize);
        _counter = _maxDecreaseStepsCount;
        _col.radius = _startingColSize;
        CanTagEnemy = true;
        _col.enabled = true;
        _rootsManager.ChoseRoot();
    }
}
