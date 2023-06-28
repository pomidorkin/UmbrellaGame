using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavingData
{
    public bool firstStart = true;
    public int coins = 0;
    public int highScore = 0;
    public bool disableAddsPurchased = false;
    public float soundsVolume = 1f;
    public float musicVolume = 1f;
}
