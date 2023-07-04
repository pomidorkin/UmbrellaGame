using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorationsController : MonoBehaviour
{
    [SerializeField] GameObject[] decorations;

    public void ActivateRandomDecoration()
    {
        foreach (GameObject item in decorations)
        {
            item.SetActive(false);
        }
        int rnd = Random.Range(0, decorations.Length);
        decorations[rnd].SetActive(true);
    }
}
