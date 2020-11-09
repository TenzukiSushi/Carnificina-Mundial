using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private float currentSpeed;

    private Rigidbody2D rb;
    private Vector2 axis;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        axis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift)) currentSpeed = runSpeed;
        else currentSpeed = walkSpeed;
    }

    private void FixedUpdate()
    {
        rb.velocity = axis * currentSpeed;
    }
}
