using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Market : MonoBehaviour
{
    [SerializeField] Button disableAdsButton;

    private void Start()
    {
        if (SaveManager.Instance.State.disableAddsPurchased)
        {
            disableAdsButton.interactable = false;
        }
    }

    public void DisableAds()
    {
        if (!SaveManager.Instance.State.disableAddsPurchased)
        {
            SaveManager.Instance.State.disableAddsPurchased = true;
            SaveManager.Instance.Save();
            disableAdsButton.interactable = false;
        }
    }
}
