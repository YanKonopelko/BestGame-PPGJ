using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Action OnActionPress;
    [SerializeField] private KeyCode interactionKeyCode = KeyCode.E;
    private Animation anim;

    private void Start()
    {
        anim = GetComponent<Animation>(); 
    }

    void Update()
    {
        if (Input.GetKeyDown(interactionKeyCode))
        {
            OnActionPress?.Invoke();
        }
    }

    public void StartStone()
    {
        anim.Play("HomlinStone");
    }
}
