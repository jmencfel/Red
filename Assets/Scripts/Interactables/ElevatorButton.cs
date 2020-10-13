using System;
using UnityEngine;

public class ElevatorButton : Interactable
{
    [HideInInspector] public uint floor;
    [HideInInspector] public float height;
    [HideInInspector] public ShaftDoors door;
    public Action<uint, float, ShaftDoors> onInteract;

    public override void Interact()
    {
        onInteract?.Invoke(floor, height, door); 
        base.Interact();
    }
}
