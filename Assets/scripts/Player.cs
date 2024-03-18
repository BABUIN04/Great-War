using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Interactable interactableObject;
    public Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (interactableObject != null && Input.GetKeyDown(KeyCode.E))
        {
            interactableObject.Interact();
            Debug.Log("interact");
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        anim.SetFloat("horizontalmove", Mathf.Abs(moveHorizontal));
        anim.SetFloat("verticalmove", Mathf.Abs(moveVertical));

        transform.Translate(movement * Speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "interactable")
        {
            interactableObject = collision.gameObject.GetComponent<Interactable>();
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "interactable")
        {
            interactableObject = null;
        }
    }
}
