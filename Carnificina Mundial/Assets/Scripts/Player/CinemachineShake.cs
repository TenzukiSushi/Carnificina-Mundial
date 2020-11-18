﻿using UnityEngine;
using Cinemachine;

public class CinemachineShake : MonoBehaviour
{
    public static CinemachineShake Instance { get; private set; }

    private CinemachineVirtualCamera cvCam;
    private float shakeTimer;

    private void Awake()
    {
        Instance = this;
        cvCam = GetComponent<CinemachineVirtualCamera>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cbmcPerlin = cvCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cbmcPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    private void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0)
            {
                CinemachineBasicMultiChannelPerlin cbmcPerlin = cvCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cbmcPerlin.m_AmplitudeGain = 0;
            }
        }
    }
}
