using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask layerMask;
    void Update()
    {
        RaycastHit hit;
        var hitInfo = Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, rayDistance, layerMask);

        if(hitInfo)
        {
            Debug.Log(hit.collider.name);
            Debug.DrawRay(cam.transform.position, cam.transform.forward * rayDistance, Color.yellow);
        }
    }
}
