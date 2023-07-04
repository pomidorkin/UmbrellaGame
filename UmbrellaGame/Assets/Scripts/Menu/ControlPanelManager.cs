using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanelManager : MonoBehaviour
{
    public int controlPanelId;
    [SerializeField] GameObject[] controls;
    [SerializeField] UmbrellaMovement umbrellaMovement;
    private void OnEnable()
    {
        controlPanelId = SaveManager.Instance.State.controlId;
        umbrellaMovement.controlId = controlPanelId;
        switch (controlPanelId)
        {
            case 1: // Joystick
                controls[0].SetActive(true);
                controls[1].SetActive(false);
                controls[2].SetActive(false);
                break;
            case 2: // Buttons
                controls[0].SetActive(false);
                controls[1].SetActive(true);
                controls[2].SetActive(true);
                break;
            case 3: // Gyroscope
                controls[0].SetActive(false);
                controls[1].SetActive(false);
                controls[2].SetActive(true);
                break;
            default:
                print("Incorrect intelligence level.");
                break;
        }
    }
}
