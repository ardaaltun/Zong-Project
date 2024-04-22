using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform weaponsPanel;
    public Transform instrumentsPanel;
    [SerializeField] private AudioSource audioSource;

    private void OnEnable()
    {
        audioSource.Play();
        UIManager.instance.EnableCursor();
    }

    private void OnDisable()
    {
        UIManager.instance.DisableCursor();
    }
    public void AddItem()
    {
        GameObject newObj = Instantiate(objectPrefab, instrumentsPanel);
    }

    public void RemoveItem()
    {
        foreach (Transform t in instrumentsPanel.transform)
            Destroy(t.gameObject);
    }
}
