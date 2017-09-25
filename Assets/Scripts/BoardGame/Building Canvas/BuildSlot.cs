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
    private GameObject SelectedItem;
    void Start()
    {
        childImage = this.gameObject.transform.GetChild(0);
        Image pic = childImage.GetComponentInChildren<Image>();
        pic.sprite = item.icon;
        if (item.name == "Empty" || item.IsEnaled == false)
        {
            pic.enabled = false;
        }
    }
    public void ItemSelection(GameObject Building)
    {
        Vector3 pos = new Vector3(0, 0, 0);
        Instantiate(Building, pos, Quaternion.identity);
        SelectedItem = Building;

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(item.place);
        }   
        if (item.place && Input.GetMouseButtonDown(0) && SelectedItem != null)
        {
            Debug.Log(SelectedItem.name);
            //Destroy(SelectedItem);
            //RaycastHit hit;
            //Vector3 pos = new Vector3(0, 0, 0);
            ////Debug.Log(SelectedItem.name);
            //Instantiate(SelectedItem, pos, Quaternion.identity);
        }
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