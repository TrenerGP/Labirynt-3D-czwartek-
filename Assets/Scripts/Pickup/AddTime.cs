using UnityEngine;

public class AddTime : PickUp
{
    public int time;

    public override void Picked()
    {
        GameManager.instance.AddTime(time);
        base.Picked();
    }
}
