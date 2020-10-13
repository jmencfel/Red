using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [Header("References")]
    [SerializeField] private Text timeText;
    [SerializeField] private Text jumpsText;
    [SerializeField] private Text floorText;

    private int totalJumps = 0;
    private float timeSinceStart = 0;
    private int currentFloor = 0;
    private const string prefix_jumps = "Jumps: ";
    private const string prefix_time = "Time: ";
    private const string prefix_floor = "Floor: ";
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
    }
    private void Update()
    {       
        UpdateTimer();
    }
    public void UpdateTimer()
    {
        timeSinceStart += Time.deltaTime;
        timeText.text = prefix_time + (int)timeSinceStart;
    }
    public void IncreaseJumps()
    {
        totalJumps++;
        jumpsText.text = prefix_jumps + totalJumps;
    }
    public void SetFloor(int floor)
    {
        floorText.text = prefix_floor + floor;
    }
    public void CalculateFloor(float height)
    {
        if(height > 0 && height < 4.35f)
        {
            currentFloor = 0;
        }
        else if (height > 5 && height < 7.55f)
        {
            currentFloor = 1;
        }
        else if (height > 8.7f && height < 10f)
        {
            currentFloor = 2;
        }
        else if (height > 10.80f)
        {
            currentFloor = 3;
        }
        floorText.text = prefix_floor + currentFloor;
    }

}
