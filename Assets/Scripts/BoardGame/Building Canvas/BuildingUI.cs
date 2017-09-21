using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUI : MonoBehaviour
{

    public Transform itemsParent;   // The parent object of all the items

    public GameObject inventoryUI;

    Build build;    // Our current inventory

    BuildSlot[] slots;  // List of all the slots

    private void Awake()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
    void Start()
    {
        build = Build.instance;
        //build.onItemChangedCallback += UpdateUI;    // Subscribe to the onItemChanged callback

        // Populate our slots array
        slots = itemsParent.GetComponentsInChildren<BuildSlot>();
    }


    void Update()
    {
        if (Input.GetButtonDown("Inventory")) //add button (i)
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < build.items.Count)
            {
                slots[i].AddItem(build.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}