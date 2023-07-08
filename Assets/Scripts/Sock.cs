using UnityEngine;

public class Sock : Collectable
{ 
    override public void Action()
    {
        Debug.Log("Sock");
        GameManager.Instance.AddCollectables(this);
        Destroy(gameObject);

    }

    
}
