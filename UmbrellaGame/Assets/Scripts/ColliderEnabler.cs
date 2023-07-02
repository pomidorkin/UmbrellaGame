using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEnabler : MonoBehaviour
{
    [SerializeField] BoxCollider2D topUmbrellaCollider;

    public void EnableCollider()
    {
            topUmbrellaCollider.enabled = true;
    }

    public void DisableCollider()
    {
        topUmbrellaCollider.enabled = false;
    }
}
