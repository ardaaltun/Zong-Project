using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour, IInteraction
{
    [SerializeField] private GameObject canvas;

    public void Canvas(bool setVisible)
    {
        canvas.SetActive(setVisible);
    }

    public void Interact()
    {
        Canvas(false);
        Debug.Log("You interacted");
    }

    public void ResetObject()
    {
        transform.position = new Vector3(1.62f, 0.25f, 0f);
        transform.localEulerAngles = new Vector3(0f, -90f, 0f);
        canvas.SetActive(true);
    }
}
