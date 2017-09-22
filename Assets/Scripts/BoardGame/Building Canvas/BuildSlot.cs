using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildSlot : MonoBehaviour
{

    //public Image icon;
    ////public Button removeButton;
    Transform childImage;
    public ChooseBuilding item;
    void Start()
    {
        childImage = this.gameObject.transform.GetChild(0);
        Image pic = childImage.GetComponentInChildren<Image>();
        pic.sprite = item.icon;
    }

    //targetpos = Camera.main.WordToScreenPoint(transform.position);
    public void UseItem()
    {
        if (name != null && item.IsEnaled)
        {
            item.Use();

        }
        else
        {
            Debug.Log("Nothing");
            return;
        }
    }

    //public void AddItem(ChooseBuilding newItem)
    //{
    //    item = newItem;

    //    icon.sprite = item.icon;
    //    icon.enabled = true;
    //    //removeButton.interactable = true;
    //}

    //public void ClearSlot()
    //{
    //    item = null;

    //    icon.sprite = null;
    //    icon.enabled = false;
    //    //removeButton.interactable = false;
    //}
    //public void OnRemoveButton()
    //{
    //    Build.instance.Remove(item);
    //}
    //public void UseItem()
    //{
    //    item.Use();
    //    //Debug.Log(BuildingObject);
    //    //if (item != null)
    //    //{
    //    //    item.Use();
    //    //}
    //}
}