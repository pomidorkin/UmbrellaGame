using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class MMFeedbacksSetter : MonoBehaviour
{
    [SerializeField] MMFeedbacks MMFeedbacks;

    private void OnEnable()
    {
        FindObjectOfType<AudioVisualizerManager>().SetMMFeedbacks(MMFeedbacks);
    }
}
