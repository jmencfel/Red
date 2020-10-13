using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float MaxInteractionDistance = 2.0f;
    [SerializeField] private LayerMask InteractablesLayer;
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
        if (Physics.Raycast(ray, out hit, MaxInteractionDistance, InteractablesLayer))
        {
            target = hit.collider.gameObject.GetComponent<ElevatorButton>();
            if (target != null)
            {
                target.Interact();
            }
            else
            {
                Debug.Log(hit.transform.gameObject.name);
            }

        }
    }
}
