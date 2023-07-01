using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItweenRotator : MonoBehaviour
{
    private float counter = 0;
    [SerializeField] private float triggerVal = 0;
    private bool triggered = false;

    // Update is called once per frame
    void Update()
    {
        if (counter < triggerVal && !triggered)
        {
            counter += Time.deltaTime;
        }
        else if (counter >= triggerVal && !triggered)
        {
            triggered = true;
            iTween.RotateTo(gameObject, iTween.Hash("z", 5, "time", 3, "islocal", true, "looptype", "pingpong", "easetype", iTween.EaseType.easeInOutQuad));
            iTween.MoveTo(gameObject, iTween.Hash("y", -.5, "time", 6, "islocal", true, "looptype", "pingpong", "easetype", iTween.EaseType.easeInOutQuad));
        }
        
    }
}
