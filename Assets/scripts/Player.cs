using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
            moveDirection.x = Input.GetAxisRaw("Horizontal");
        else
            moveDirection.x = 0;

        if (Input.GetAxisRaw("Vertical") != 0)
            moveDirection.y = Input.GetAxisRaw("Vertical");
        else
            moveDirection.y = 0;
        rb.AddForce(moveDirection * speed);
    }
}
