using UnityEngine;

public class Point : MonoBehaviour
{
    public float stayTime;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SecurityGuard>())
            collision.GetComponent<SecurityGuard>().PointReached();
    }
}
