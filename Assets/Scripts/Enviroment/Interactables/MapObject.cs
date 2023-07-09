using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : Interactable
{
    override public void Action()
    {
        //GameManager.Instance.OpenMap();
        Debug.Log("Map");
    }
}
