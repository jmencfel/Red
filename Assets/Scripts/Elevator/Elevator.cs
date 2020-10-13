using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] List<Floor> floors;
    [SerializeField] private float elevatorSpeed=5.0f;

    [SerializeField] private uint currentFloorNumber = 0;
    [SerializeField] private uint destinationFloorNumber = 0;
    private void Start()
    {
        foreach(Floor f in floors)
        {
            foreach (ElevatorButton b in f.Buttons)
            {
                b.SetValues(f.Number, f.Height, f.Doors);
                b.onInteract += CallElevator;
            }
        }
    }

    private void CallElevator(uint floor, float height, ShaftDoors shaftDoors)
    {
        StartCoroutine(CallElevatorCoroutine(floor, height, shaftDoors));      
    }    
    IEnumerator CallElevatorCoroutine(uint floor, float height, ShaftDoors shaftDoors)
    {
        //wait for doors to close on the current floor
        yield return StartCoroutine(ClosePreviousElevatorDoors());
        destinationFloorNumber = floor;
        //if elevator is already on the current floor, just open the doors
        if (currentFloorNumber == floor)
        {
            Debug.Log("Elevator is on the current floor. Opening doors!");
            shaftDoors.Open();
        }
        else
        {
            //wait for elevator to arrive
            yield return StartCoroutine(GetToDestination(height, shaftDoors));
            shaftDoors.Open();
        }
        
        Debug.Log("Please Enter");
    }
    IEnumerator GetToDestination(float height, ShaftDoors shaftDoors)
    {
        Vector3 desiredPosition = new Vector3(transform.position.x, height, transform.position.z);
        while (Vector3.Distance(transform.position, desiredPosition)>0.10f)
        {
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, elevatorSpeed*Time.deltaTime);
            yield return null;
        }
        GameController.instance.SetFloor((int)destinationFloorNumber);
        currentFloorNumber = destinationFloorNumber;        
    }

    private IEnumerator ClosePreviousElevatorDoors()
    {
        var currentFloor =  floors.FirstOrDefault(x => x.Number == currentFloorNumber);
        currentFloor.Doors.Close();
        while(currentFloor.Doors.IsAnimationPlaying())
        {
            yield return null;
        }
    }
    

    
}
