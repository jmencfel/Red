using System;
using UnityEngine;

public class ElevatorButton : Interactable
{
    [HideInInspector] private uint floor;
    [HideInInspector] private float height;
    [HideInInspector] private ShaftDoors door;
    public Action<uint, float, ShaftDoors> onInteract;

    public void SetValues(uint f, float h, ShaftDoors d)
    {
        floor = f;
        height = h;
        door = d;
    }
    public override void Interact()
    {
        onInteract?.Invoke(floor, height, door); 
        base.Interact();
    }
}
