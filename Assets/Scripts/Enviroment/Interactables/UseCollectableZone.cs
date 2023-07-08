using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCollectableZone : Interactable
{
    [SerializeField] Collectable collectable;

    public override void Action()
    {
        //Debug.Log(typeof(collectable.type));
        int i = 0;
        if (GameManager.Instance.Collectacles.TryGetValue(collectable, out i))
        {
            if(i > 0) {
                GameManager.Instance.Collectacles[collectable] -= 1;
                Debug.Log("Action");
            }
            
        }
    }
}
