using System.Collections;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    private bool isMove = false;
    [SerializeField] private Transform player;
    private Animation anim;

    private float speed = 0.015f;
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
        //var player = FindObjectOfType<PlayerMovement>();
        player.gameObject.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.GetComponent<Player>().StartStone();
        transform.position = player.transform.position;
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);

        anim.Play("CameraZoom");
        speed = 1f;

        StartCoroutine(UnZoom(player.GetComponent<PlayerMovement>()));
    }

    IEnumerator UnZoom(PlayerMovement player)
    {
        yield return new WaitForSeconds(1.2f);
        player.transform.position = new Vector3(6.35f, 0, 0);
        player.enabled = true;
        speed = 0.015f;

    }
}
