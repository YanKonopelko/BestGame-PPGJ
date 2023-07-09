using System.Collections;
using UnityEngine;

public class Patient : MonoBehaviour
{
    [SerializeField] private PatientState curState = PatientState.sad;

    enum PatientState
    {
        sad,
        happy
    }

    public void ChangeState()
    {
        curState = PatientState.happy;
        StartCoroutine(Rotate());
        //PlaySound
        //Flash(Вспышка)
        //ChangeParticles
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player>() != null)
        {
            GameManager.Instance.Lose();
        }
    }

    IEnumerator Rotate()
    {
        yield return new WaitForSeconds(2);
        GetComponent<SpriteRenderer>().flipX = true;
        GetComponent<BoxCollider2D>().offset = new Vector2(0.26f, -0.0278267f);
    }
}
