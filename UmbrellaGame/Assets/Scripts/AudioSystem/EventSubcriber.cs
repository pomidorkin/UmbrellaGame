using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSubcriber : MonoBehaviour
{
    [SerializeField] AudioVisualizerManager visualizerManager;
    private void OnEnable()
    {
        visualizerManager.OnPeakReachedAction += Handler;
    }

    private void OnDisable()
    {
        visualizerManager.OnPeakReachedAction -= Handler;
    }

    private void Handler()
    {
    }
}
