using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action OnActionPress;
    [SerializeField] private KeyCode interactionKeyCode = KeyCode.E;

    void Update()
    {
        if (Input.GetKeyDown(interactionKeyCode))
        {
            OnActionPress?.Invoke();
        }
    }


}
