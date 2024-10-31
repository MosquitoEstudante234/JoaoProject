using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public float interactionDistance = 3f; 
    public GameObject interactionPanel; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckDoorInteraction();
        }
    }

    void CheckDoorInteraction()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.CompareTag("Door"))
            {
                interactionPanel.SetActive(true);
            }
        }
    }
}
