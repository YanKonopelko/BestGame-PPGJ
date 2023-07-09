using UnityEngine;


public class Collectable : Interactable
{
    override public void Action()
    {
        Debug.Log(this);
        GameManager.Instance.AddCollectables(this);
        Destroy(gameObject);

    }

}
