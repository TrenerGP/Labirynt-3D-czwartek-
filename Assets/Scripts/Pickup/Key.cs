using UnityEngine;

public enum KeyColor
{
    Red,
    Green,
    Blue
}

public class Key : PickUp
{
    public KeyColor color;
    public override void Picked()
    {
        GameManager.instance.AddKey(color);
        base.Picked();
    }
}
