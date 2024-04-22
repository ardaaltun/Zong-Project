using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private bool alreadyPicked;
    [SerializeField] private Transform handPosition;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickSFX, dropSFX;
    private void Update()
    {
        RaycastHit hit;
        var hitInfo = Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, rayDistance, layerMask);

        Debug.DrawRay(cam.transform.position, cam.transform.forward * rayDistance, Color.yellow);
        if(hitInfo)
        {
            if (!alreadyPicked && hit.collider.CompareTag("Object"))
                UIManager.instance.PickUpText(hitInfo);
            else if(alreadyPicked && hit.collider.CompareTag("Box"))
                UIManager.instance.DropText(hitInfo);

            if(Input.GetKeyDown(KeyCode.E))
            {
                if (!alreadyPicked)
                    PickUpItem(hit);
                else
                    DropItem(hit);
            }
        }
        else
        {
            UIManager.instance.PickUpText(hitInfo);
            UIManager.instance.DropText(hitInfo);
        }

        if (Input.GetKeyDown(KeyCode.Tab)) UIManager.instance.Inventory(!UIManager.instance.inventory.gameObject.activeInHierarchy);
    }

    private void PickUpItem(RaycastHit hit)
    {
        audioSource.clip = pickSFX;
        audioSource.Play();
        hit.collider.gameObject.transform.SetParent(handPosition);
        hit.collider.gameObject.transform.localPosition = Vector3.zero;
        hit.collider.gameObject.GetComponent<Object>().Interact();
        alreadyPicked = true;
        UIManager.instance.inventory.AddItem();
        UIManager.instance.Inventory(true);
    }

    private void DropItem(RaycastHit hit)
    {
        audioSource.clip = dropSFX;
        audioSource.Play();
        GameObject obj = handPosition.GetChild(0).gameObject;
        obj.transform.SetParent(hit.collider.transform);
        obj.GetComponent<Object>().ResetObject(); //the start position, we simply reset the position
        hit.collider.gameObject.GetComponent<Box>().Interact();
        UIManager.instance.inventory.RemoveItem();
        alreadyPicked = false;
    }
}
