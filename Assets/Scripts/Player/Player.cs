using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action OnActionPress;
    [SerializeField] private KeyCode interactionKeyCode = KeyCode.E;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interactionKeyCode))
        {
            OnActionPress?.Invoke();
        }
    }


}
