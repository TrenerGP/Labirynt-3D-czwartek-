using UnityEngine;

public class Freeze : PickUp
{
    public int time;

    public override void Picked()
    {
        GameManager.instance.FreezeTime(time);
        base.Picked();
    }
}


