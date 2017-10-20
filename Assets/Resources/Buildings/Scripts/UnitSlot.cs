using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnitSlot : MonoBehaviour {

    #region Variables
    Vector3 SpawnLengthFromBuilding = new Vector3(0, 0, 2);
    Vector3 buildingPos;
    UnitUI unitUI;
    ChooseUnit item;
    Transform Cost;
    //Sprite/image for building inventory
    Transform childImage;
    //Reference
    UnitSlot unitSlot;
    #endregion
    public void UIPics(string name)
    {
        ItemManager itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();
        if (name == "Chest")
        {
            if (this.name == "InventorySlot")
                item = itemManager.Items[1];
            if (this.name == "InventorySlot (1)")
                item = itemManager.Items[1];
            if (this.name == "InventorySlot (2)")
                item = itemManager.Items[0];
            if (this.name == "InventorySlot (3)")
                item = itemManager.Items[0];
            if (this.name == "InventorySlot (4)")
                item = itemManager.Items[0];
            if (this.name == "InventorySlot (5)")
                item = itemManager.Items[0];
            if (this.name == "InventorySlot (6)")
                item = itemManager.Items[0];
            if (this.name == "InventorySlot (7)")
                item = itemManager.Items[0];
        }
        else if (name == "Pants")
        {
            if (this.name == "InventorySlot")
                item = itemManager.Items[2];
            if (this.name == "InventorySlot (1)")
                item = itemManager.Items[2];
            if (this.name == "InventorySlot (2)")
                item = itemManager.Items[0];
            if (this.name == "InventorySlot (3)")
                item = itemManager.Items[0];
            if (this.name == "InventorySlot (4)")
                item = itemManager.Items[0];
            if (this.name == "InventorySlot (5)")
                item = itemManager.Items[0];
            if (this.name == "InventorySlot (6)")
                item = itemManager.Items[0];
            if (this.name == "InventorySlot (7)")
                item = itemManager.Items[0];
        }
        else if (name == "Helmet")
        {
            if (this.name == "InventorySlot")
                item = itemManager.Items[1];
            if (this.name == "InventorySlot (1)")
                item = itemManager.Items[2];
            if (this.name == "InventorySlot (2)")
                item = itemManager.Items[0];
            if (this.name == "InventorySlot (3)")
                item = itemManager.Items[0];
            if (this.name == "InventorySlot (4)")
                item = itemManager.Items[0];
            if (this.name == "InventorySlot (5)")
                item = itemManager.Items[0];
            if (this.name == "InventorySlot (6)")
                item = itemManager.Items[0];
            if (this.name == "InventorySlot (7)")
                item = itemManager.Items[0];
        }
        item.unitSlot = this;
        childImage = this.gameObject.transform.GetChild(0);
        Image pic = childImage.GetComponentInChildren<Image>();
        pic.sprite = item.icon;
        //If "Build" don't have a image, it will show nothing
        if (item.name == "Empty" || item.IsEnaled == false)
        {
            pic.enabled = false;
        }
    }
    public void PointerEnter()
    {
        //On Mouse Hover on items in Build inventory, it will show information about the item cost and name of item
        Cost = this.gameObject.transform.GetChild(1);
        Text costTxt = Cost.GetComponentInChildren<Text>();
        costTxt.text = item.Cost.ToString() + " " + item.name;
        if (item.name == "Empty" || item.IsEnaled == false)
            costTxt.enabled = false;
        else
            costTxt.enabled = true;
    }
    public void PointerExit()
    {
        //When mouse will move away from item, it will disable information text
        Cost = this.gameObject.transform.GetChild(1);
        Text costTxt = Cost.GetComponentInChildren<Text>();
        costTxt.enabled = false;
    }
    public void unitSelection(int loadingTime, GameObject unit)
    {
        StartCoroutine(UnitTimeIEnumerator(loadingTime, unit, buildingPos));
    }
    public void BuildingPos(Vector3 buildingPosSend)
    {
        buildingPos = buildingPosSend + SpawnLengthFromBuilding;
    }
    public void UseItem()
    {
        //When the UI buttons are clicked, it will go to ChooseBuilding(item), and execute Use
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
    IEnumerator UnitTimeIEnumerator(int timer, GameObject unit, Vector3 spawnPos)
    {
        yield return new WaitForSeconds(timer);
        Instantiate(unit, spawnPos, Quaternion.identity).name = unit.name;
    }
}