using UnityEngine;

public class IOS : MonoBehaviour //IOS - Interactable Objects Scanning 
{
    [SerializeField] Camera cam;

    private bool look = false;

    private Collider currentObject;

    void Update()
    { 
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hit, 10, 9))
        {
            if (!look)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                currentObject = hit.collider;

                if (interactable != null)
                {
                    Debug.Log("Creating infoItemTab for " + hit.collider.name);

                    interactable.OnFocus();

                    look = true;
                }
            }
            else
            {
                

                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (Input.GetButtonDown("PickUp") && PlayerManager.instance.ingame == false)
                {
                    Debug.Log("destroing infoItemTab (pickup item) " + hit.collider.name);

                    look = false;

                    interactable.OnClick(transform);
                }
                
                if (interactable == null /*|| hit.collider.name != currentObject.name wtf*/)
                {
                    Debug.Log("destroing infoItemTab (move mouse) " + hit.collider.name);
                    //Debug.Log("You're not looking at " +  + " already")

                    currentObject.GetComponent<Interactable>().OnOut();

                    look = false;
                }
            }
        }
    }
}
