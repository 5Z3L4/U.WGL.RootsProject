using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float AmplitudeGain = 2;
    public float FreuencyGain = 2;
    private bool isShaking;
    private float shakeTimeElapsed;
    private float shakeTime = .2f;

    public CinemachineVirtualCamera _vc;
    public CinemachineBasicMultiChannelPerlin noisePerlin;

    private void Awake()
    {
        noisePerlin = _vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    [ContextMenu("TEST")]
    public void StartShake()
    {
        noisePerlin.m_AmplitudeGain = AmplitudeGain;
        noisePerlin.m_FrequencyGain = FreuencyGain;
        shakeTimeElapsed = 0;
    }

    public void StopShake()
    {
        isShaking = false;
        noisePerlin.m_AmplitudeGain = 0;
        noisePerlin.m_FrequencyGain = 0;
    }

    private void Update()
    {
        shakeTimeElapsed += Time.deltaTime;

        if (shakeTimeElapsed > shakeTime)
        {
            StopShake();
        }
    }
}
