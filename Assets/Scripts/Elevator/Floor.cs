[System.Serializable]
public struct Floor 
{
    public uint Number;
    public float Height;
    public System.Collections.Generic.List<ElevatorButton> Buttons;
    public ShaftDoors Doors;
}
