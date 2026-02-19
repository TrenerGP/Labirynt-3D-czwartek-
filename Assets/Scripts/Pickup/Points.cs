using UnityEngine;

public class Points : PickUp
{
    public int points=1;

    public override void Picked()
    {
        GameManager.instance.AddPoints(points);
        base.Picked();
    }
}
