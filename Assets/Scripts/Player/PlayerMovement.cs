using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f; 

    private Rigidbody2D rb;
    private Transform _transform;

    private SpriteRenderer sprite;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _transform = transform; 
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.zero;
        Move();
        Rotate();
        
    }
    

    private void Move()
    {
        
        float moveHorizontal = Input.GetAxis("Horizontal"); 
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical); 
        rb.velocity = movement * movementSpeed * Time.deltaTime;
        


    }

    private void Rotate()
    {
        if (rb.velocity.x < 0)
            sprite.flipX = true;
        else if (rb.velocity.x > 0)
            sprite.flipX = false;
    }



}
