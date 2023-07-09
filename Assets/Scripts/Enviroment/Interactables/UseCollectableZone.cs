using UnityEngine;

public class UseCollectableZone : Interactable
{
    [SerializeField] Collectable collectable;
    [SerializeField] Patient patient;
    public override void Action()
    {
        //Debug.Log(typeof(collectable.type));
        int i = 0;
        if (GameManager.Instance.Collectacles.TryGetValue(collectable, out i))
        {
            if(i > 0) {
                GameManager.Instance.Collectacles[collectable] -= 1;
                transform.GetChild(0).gameObject.SetActive(true);
                this.enabled = (false);
                patient.ChangeState();
                SoundManager.Instance.PlaySound(SoundManager.SoundType.RewardSound);
            }
            
        }
    }
}
