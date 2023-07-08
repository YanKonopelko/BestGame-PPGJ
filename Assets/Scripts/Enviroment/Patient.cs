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
        //PlaySound
        //Flash(Вспышка)
        //ChangeParticles
    }
    
}
