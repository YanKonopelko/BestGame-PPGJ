using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityZone : MonoBehaviour
{
 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            MusicManager.Instance.ChangeMusic(MusicManager.MusicType.InGameMusic);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            MusicManager.Instance.ChangeMusic(MusicManager.MusicType.MainMenuMusic);
        }
    }
    private void Update()
    {
        transform.localPosition = transform.parent.GetChild(0).localPosition;
    }

}
