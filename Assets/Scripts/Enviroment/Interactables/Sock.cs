
public class Sock : Collectable
{
    public override void Action()
    {
        base.Action();
        GameManager.Instance.Win();
    }

}
