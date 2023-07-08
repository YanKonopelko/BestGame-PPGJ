using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool isMove = false;
    [SerializeField] private Transform player;
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            isMove = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            isMove = false;
        }
    }

    private void FixedUpdate()
    {
        if (isMove)
        {
            transform.position = Vector3.Lerp( transform.position, player.position,0.01f);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }
}
