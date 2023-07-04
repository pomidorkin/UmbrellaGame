using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEnabler : MonoBehaviour
{
    [SerializeField] BoxCollider2D topUmbrellaCollider;
    [SerializeField] PowerUpController powerUpController;

    public void EnableCollider()
    {
        if (!powerUpController.GetIsInvulnerable())
        {
            topUmbrellaCollider.enabled = true;
        }
    }

    public void DisableCollider()
    {
        topUmbrellaCollider.enabled = false;
    }
}
