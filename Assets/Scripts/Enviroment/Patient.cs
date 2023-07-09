using System.Collections;
using UnityEngine;

public class Patient : MonoBehaviour
{
    [SerializeField] private PatientState curState = PatientState.sad;
    [SerializeField] private AudioClip clip;
    [SerializeField] private SpriteRenderer happySprite;
    enum PatientState
    {
        sad,
        happy
    }
    private void Start()
    {
        StartCoroutine(Sounds());
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
        GetComponent<BoxCollider2D>().offset = new Vector2(1.3f, -0.005971789f);
    }
    IEnumerator Sounds()
    {
        yield return new WaitForSeconds(5);
        if(curState == PatientState.sad)
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
            //SoundManager.Instance.PlaySound(SoundManager.SoundType.BoySound) ;
            StartCoroutine(Sounds());
        }

    }
}
