using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UmbrellaController : MonoBehaviour
{
    [SerializeField] UmbrellaMovement umbrellaMovement;
    private Rigidbody2D rigidbody;
    [SerializeField] bool test = false;
    [SerializeField] Button leftButton;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void ToggleUmbrellaClosed()
    {
        if (umbrellaMovement.opened)
        {
            rigidbody.velocity = new Vector2(0,0);
            rigidbody.simulated = true;
        }
        else
        {
            rigidbody.simulated = false;
        }
        umbrellaMovement.opened = !umbrellaMovement.opened;
    }

    private void Update()
    {
        if (test)
        {
            test = false;
            ToggleUmbrellaClosed();
        }
    }
}
