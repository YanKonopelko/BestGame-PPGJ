using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject PressECanvas;
    public Player player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {         
            player = collision.GetComponent<Player>();
            PressECanvas.SetActive(true);
            player.OnActionPress += Action;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            PressECanvas.SetActive(false);
            player.OnActionPress -= Action;
            player = null; 
        }
    }

    public virtual void Action()
    {
        Debug.Log("Action");
    }
}
