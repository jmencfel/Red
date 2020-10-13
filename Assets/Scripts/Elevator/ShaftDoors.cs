using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftDoors : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animation doorAnimation;

    public void Open()
    {
        doorAnimation.Play("OpenElevatorDoors");
    }
    public void Close()
    {
        doorAnimation.Play("CloseElevatorDoors");
    }
    public bool IsAnimationPlaying()
    {
        return doorAnimation.isPlaying;
    }
}
