using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RadioButtonSystem : MonoBehaviour
{
    [SerializeField] private ToggleGroup toggleGroup;
    [SerializeField] Toggle[] toggles;
    private int controlId;

    private void OnEnable()
    {
        foreach (Toggle toggleItem in toggles)
        {
            toggleGroup.UnregisterToggle(toggleItem);
        }
        foreach (Toggle toggleItem in toggles)
        {
            toggleGroup.RegisterToggle(toggleItem);
        }
        
        controlId = SaveManager.Instance.State.controlId;
        toggles[controlId - 1].isOn = true;
        toggleGroup.NotifyToggleOn(toggles[controlId - 1], false);
    }

    public void SetControlID(int id)
    {
        controlId = id;
    }

    public void Submit()
    {
        SaveManager.Instance.State.controlId = controlId;
        SaveManager.Instance.Save();
    }
}
