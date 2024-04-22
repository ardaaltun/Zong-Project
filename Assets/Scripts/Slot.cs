using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item item;

    private void Start()
    {
        name = item.name;
        GetComponent<Image>().sprite = item.itemIcon;
    }
}
