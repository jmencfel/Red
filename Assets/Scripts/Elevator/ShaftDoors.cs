using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftDoors : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animation doorAnimation;

    private bool isOpen = false;

    public void Open()
    {
        if (!isOpen)
        {
            isOpen = true;
            doorAnimation.Play("OpenElevatorDoors");
        }
    }
    public void Close()
    {
        if (isOpen)
        {
            isOpen = false;
            doorAnimation.Play("CloseElevatorDoors");
        }
    }
    public bool IsAnimationPlaying()
    {
        return doorAnimation.isPlaying;
    }
}
