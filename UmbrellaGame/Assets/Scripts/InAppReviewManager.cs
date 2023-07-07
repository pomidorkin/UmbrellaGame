using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Play.Review;

public class InAppReviewManager : MonoBehaviour
{
    private ReviewManager _reviewManager;
    private PlayReviewInfo _playReviewInfo;
    int launchCount;

    private void Start()
    {
        launchCount = PlayerPrefs.GetInt("TimesLaunched", 0);
        launchCount++;
        if (launchCount >= 3)
        {
            StartCoroutine(RequestReviews());
            launchCount = 0;
        }
        PlayerPrefs.SetInt("TimesLaunched", launchCount);
        
    }

    IEnumerator RequestReviews()
    {
        _reviewManager = new ReviewManager();

        // Request a ReviewInfo
        var requestFlowOperation = _reviewManager.RequestReviewFlow();
        yield return requestFlowOperation;
        if (requestFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }
        _playReviewInfo = requestFlowOperation.GetResult();

        // Launch In App Review Flow
        var launchFlowOperation = _reviewManager.LaunchReviewFlow(_playReviewInfo);
        yield return launchFlowOperation;
        _playReviewInfo = null; // Reset the object
        if (launchFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            yield break;
        }
        // The flow has finished. The API does not indicate whether the user
        // reviewed or not, or even whether the review dialog was shown. Thus, no
        // matter the result, we continue our app flow.
    }
}
