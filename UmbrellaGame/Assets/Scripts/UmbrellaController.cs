using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UmbrellaController : MonoBehaviour
{
    [SerializeField] UmbrellaMovement umbrellaMovement;
    private Rigidbody2D rigidbody;
    //[SerializeField] bool test = false;
    [SerializeField] GameResetter gameResetter;
    //[SerializeField] Button leftButton;
    [SerializeField] GameObject openedUmbrella;
    [SerializeField] GameObject closedUmbrella;
    [SerializeField] Animator animator;
    [SerializeField] PlaySoundOnStart openingSound;
    [SerializeField] ColliderEnabler colliderEnabler;
    private Vector3 initialPos;

    // Buttons Images
    [SerializeField] GameObject[] umbrellaOpenedImages;
    [SerializeField] GameObject[] umbrellaClosedImages;

    private void OnEnable()
    {
        gameResetter.OnGameReset += ResetUmbrellaPosition;
    }

    private void OnDisable()
    {
        gameResetter.OnGameReset -= ResetUmbrellaPosition;
    }
    void Start()
    {
        initialPos = gameObject.transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
    }
    public void ToggleUmbrellaClosed()
    {
        if (umbrellaMovement.opened)
        {
            //rigidbody.gravityScale = 1f; // Commented out for testing
            rigidbody.drag = 0f;
            openedUmbrella.SetActive(false);
            closedUmbrella.SetActive(true);
            animator.Play("ClosingAnim");
            umbrellaMovement.ChangeClampValues(false);
            SetButtonImageToClosed(true);
        }
        else
        {
            openedUmbrella.SetActive(true);
            closedUmbrella.SetActive(false);
            colliderEnabler.DisableCollider();
            rigidbody.velocity = new Vector2(0, 0);
            //rigidbody.gravityScale = 0f; // Commented out for testing
            rigidbody.drag = 9.8f;
            animator.Play("OpeningAnim");
            umbrellaMovement.ChangeClampValues(true);
            openingSound.PlaySound();
            SetButtonImageToClosed(false);
        }
        umbrellaMovement.opened = !umbrellaMovement.opened;
    }

    private void SetButtonImageToClosed(bool val)
    {
        foreach (GameObject image in umbrellaOpenedImages)
        {
            image.SetActive(val);
        }
        foreach (GameObject image in umbrellaClosedImages)
        {
            image.SetActive(!val);
        }
    }

    public void ResetUmbrellaPosition()
    {
        gameObject.transform.position = initialPos;
        rigidbody.velocity = new Vector2(0, 0);
        rigidbody.drag = 9.8f;
        rigidbody.gravityScale = 1f;
        animator.Play("OpeningAnim");
        umbrellaMovement.opened = true;
        openedUmbrella.SetActive(true);
        closedUmbrella.SetActive(false);
        SetButtonImageToClosed(false);
    }

    public void DisableMovement()
    {
        rigidbody.velocity = new Vector2(0, 0);
        rigidbody.gravityScale = 0f;
    }

    public void EnableMovement()
    {
        rigidbody.velocity = new Vector2(0, 0);
        //rigidbody.gravityScale = 0f;
        rigidbody.drag = 9.8f;
        rigidbody.gravityScale = 1f;
        animator.Play("OpeningAnim");
        umbrellaMovement.opened = true;
        openedUmbrella.SetActive(true);
        closedUmbrella.SetActive(false);
    }
}
