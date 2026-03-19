using UnityEngine;

public class SpeedBoost : PickUp
{
    public int speed = 2;
    public int time = 10;

    public override void Picked()
    {
        GameManager.instance.GiveSpeedBoost(time, speed);
        base.Picked();
    }
}
