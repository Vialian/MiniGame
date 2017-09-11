using UnityEngine;

public class InventoryUI : MonoBehaviour {

    public Transform itemsParent;   // The parent object of all the items

    public GameObject inventoryUI;

    Inventory inventory;    // Our current inventory

    InventorySlot[] slots;  // List of all the slots

    private void Awake()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;    // Subscribe to the onItemChanged callback

        // Populate our slots array
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }


    void Update () {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
	}

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i<inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}