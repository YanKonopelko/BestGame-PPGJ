using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f; 

    private Rigidbody2D rb;
    private Transform _transform;

    private SpriteRenderer sprite;
    private SpriteRenderer StoneSprite;
    private bool isMove = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _transform = transform; 
        sprite = GetComponent<SpriteRenderer>();
        StoneSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        StartCoroutine(Walk());

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
        if (rb.velocity != Vector2.zero) {
            isMove = true;
        }
        else
            isMove = false;
    }
    
    IEnumerator Walk()
    {
        yield return new WaitForSeconds(0.4f);
        if(isMove)
            SoundManager.Instance.PlaySound(SoundManager.SoundType.StepSound);
        StartCoroutine(Walk());
    }


    private void Rotate()
    {
        if (rb.velocity.x < 0)
        {
            sprite.flipX = false;
            StoneSprite.flipX = false;
        }
        else if (rb.velocity.x > 0)
        {
            sprite.flipX = true;
            StoneSprite.flipX = true;
        }

    }



}
