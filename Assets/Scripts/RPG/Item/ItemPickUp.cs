using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{

    public Item item;

    public override void Interact()
    {
        base.Interact(); //Goes back into Interact, and execute code in Interact
        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up item" + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);  //Use singleton to get the item
        if (wasPickedUp)
            Destroy(gameObject);
    }
}