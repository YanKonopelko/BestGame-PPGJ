using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]private GameObject PressECanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {         
            PressECanvas.SetActive(true);
            Player.OnActionPress += Action;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            PressECanvas.SetActive(false);
            Player.OnActionPress -= Action;

        }
    }

    public virtual void Action()
    {
        Debug.Log("Action");
    }
}
