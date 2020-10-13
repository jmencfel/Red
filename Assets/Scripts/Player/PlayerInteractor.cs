using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float MaxInteractionDistance = 2.0f;
    private Interactable target;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Interact();
        }
    }

    private void Interact()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, MaxInteractionDistance))
        {
            target = hit.transform.gameObject.GetComponent<ElevatorButton>();
            if (target != null)
            {
                target.Interact();
            }

        }
    }
}
