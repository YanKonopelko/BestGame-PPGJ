using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
            GameManager.Instance.Lose();
    }
}
