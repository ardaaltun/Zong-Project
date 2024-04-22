using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private GameObject pickupText, dropText, notification;
    public InventoryManager inventory;
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

    public void EnableCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void DisableCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Inventory(bool enable)
    {
        inventory.gameObject.SetActive(enable);
    }

    private void Start()
    {
        pickupText = transform.GetChild(0).gameObject;
        dropText = transform.GetChild(1).gameObject;
        notification = transform.GetChild(2).gameObject;
    }

    public void PickUpText(bool setVisible)
    {
        pickupText.SetActive(setVisible);
    }
    public void DropText(bool setVisible)
    {
        dropText.SetActive(setVisible);
    }

    public void Notification(string name)
    {
        StartCoroutine(Notify(name));
    }
    IEnumerator Notify(string name)
   {
        notification.GetComponent<TMP_Text>().text = "You have dropped the object in " + name;
        notification.SetActive(true);
        yield return new WaitForSeconds(1f);
        notification.SetActive(false);
    }
}
