using UnityEngine;


public class Collectable : Interactable
{
    [SerializeField] private GameObject Description;
    override public void Action()
    {
        Debug.Log(this);
        GameManager.Instance.AddCollectables(this);
        Destroy(gameObject);
        //Вывод текста с описанием на он триггер
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            player = collision.GetComponent<Player>();
            PressECanvas.SetActive(true);
            player.OnActionPress += Action;
            Description.SetActive(true);
            //Вывод описания
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            PressECanvas.SetActive(false);
            Description.SetActive(false);
            player.OnActionPress -= Action;
            player = null;
        }
    }
}
