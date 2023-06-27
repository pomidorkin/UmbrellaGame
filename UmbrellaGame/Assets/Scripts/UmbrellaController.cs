using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UmbrellaController : MonoBehaviour
{
    [SerializeField] UmbrellaMovement umbrellaMovement;
    private Rigidbody2D rigidbody;
    //[SerializeField] bool test = false;
    [SerializeField] Button leftButton;
    [SerializeField] GameObject openedUmbrella;
    [SerializeField] GameObject closedUmbrella;
    [SerializeField] Animator animator;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    public void ToggleUmbrellaClosed()
    {
        if (umbrellaMovement.opened)
        {
            rigidbody.velocity = new Vector2(0,0);
            rigidbody.simulated = true;
            openedUmbrella.SetActive(false);
            closedUmbrella.SetActive(true);
            animator.Play("ClosingAnim");
        }
        else
        {
            openedUmbrella.SetActive(true);
            closedUmbrella.SetActive(false);
            rigidbody.simulated = false;
            animator.Play("OpeningAnim");
        }
        umbrellaMovement.opened = !umbrellaMovement.opened;
    }

    /*private void Update()
    {
        if (test)
        {
            test = false;
            ToggleUmbrellaClosed();
        }
    }*/
}
