using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private GameObject pickupText, dropText;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        pickupText = transform.GetChild(0).gameObject;
        dropText = transform.GetChild(1).gameObject;
    }

    public void PickUpText(bool setVisible)
    {
        pickupText.SetActive(setVisible);
    }
    public void DropText(bool setVisible)
    {
        dropText.SetActive(setVisible);
    }
}
