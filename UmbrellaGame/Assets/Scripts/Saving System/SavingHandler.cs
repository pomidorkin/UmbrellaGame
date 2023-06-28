using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingHandler : MonoBehaviour
{
    public SaveManager saveManager;
    // Start is called before the first frame update
    void Start()
    {
        saveManager = SaveManager.Instance;
        SaveManager.Instance.Load();
    }
}
