using UnityEngine;

public class Sock : Interactable
{
    override public void Action()
    {
        Debug.Log("Sock");
        Destroy(gameObject);
    }

    
}
