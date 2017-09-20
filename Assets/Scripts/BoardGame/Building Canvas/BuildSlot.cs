using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildSlot : MonoBehaviour
{

    public Image icon;
    public Button removeButton;

    ChooseBuilding item;
    public void AddItem(ChooseBuilding newItem)
    {
        item = newItem;

        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }
    public void OnRemoveButton()
    {
        Build.instance.Remove(item);
    }
    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }
}