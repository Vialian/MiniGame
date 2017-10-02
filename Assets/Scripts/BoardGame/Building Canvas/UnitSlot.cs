using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnitSlot : MonoBehaviour {

    Transform Cost;
    //Sprite/image for building inventory
    Transform childImage;
    //reference to ChoosBuildidng
    public ChooseUnit item;
    UnitSlot unitSlot;
    private Vector3 buildingPos;
    int i = 2;
    void Start()
    {

        item.unitSlot = this;
        childImage = this.gameObject.transform.GetChild(0);
        Image pic = childImage.GetComponentInChildren<Image>();
        pic.sprite = item.icon;
        //If "Build" don't have a image, it will show nothing
        if (item.name == "Empty")
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

        buildingPos = unitSlot.buildingPos;
        Debug.Log("denne pos er: " + buildingPos);
        StartCoroutine(UnitTimeIEnumerator(loadingTime, unit, buildingPos));
    }
    public void BuildingPos(Vector3 buildingPosSend)
    {
        buildingPos = buildingPosSend;
        Debug.Log("test pos er : " + buildingPos);
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
    void Update()
    {
        Debug.Log("I update " +buildingPos);
        
        Debug.Log(i);
    }

    IEnumerator UnitTimeIEnumerator(int timer, GameObject unit, Vector3 spawnPos)
    {
        yield return new WaitForSeconds(timer);
        Instantiate(unit, spawnPos, Quaternion.identity).name = unit.name;


    }

}