using System;
using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    private bool isMove = false;
    [SerializeField] private Transform player;
    private Animation anim;

    private float speed = 0.03f;
    private void Start()
    {
        instance = this;
        anim = GetComponent<Animation>();
    }

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
            transform.position = Vector3.Lerp( transform.position, player.position, speed);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }

    public void Lose()
    {
        anim.Play("CameraZoom");
        speed = 1f;
        var player = FindObjectOfType<PlayerMovement>();
        player.enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        StartCoroutine(UnZoom(player));
    }

    IEnumerator UnZoom(PlayerMovement player)
    {
        yield return new WaitForSeconds(1.2f);
        player.transform.position = new Vector3(6.35f, 0, 0);
        player.enabled = true;
        speed = 0.03f;

    }
}
