using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnitSlot : MonoBehaviour {

    #region Variables
    Transform Cost;
    //Sprite/image for building inventory
    Transform childImage;
    //reference to ChoosBuildidng
    public ChooseUnit item;
    UnitSlot unitSlot;
    UnitUI unitUI;
    #endregion
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

        Debug.Log("denne pos er på: " );
        StartCoroutine(UnitTimeIEnumerator(loadingTime, unit, new Vector3(0,0,0)));
    }
    //public void BuildingPos(GameObject buildingPosSend)
    //{
    //    buildingPos = buildingPosSend;
    //    Debug.Log("test pos er : " + buildingPos.name);
    //}
    
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

    }

    IEnumerator UnitTimeIEnumerator(int timer, GameObject unit, Vector3 spawnPos)
    {
        yield return new WaitForSeconds(timer);
        Instantiate(unit, spawnPos, Quaternion.identity).name = unit.name;
    }
}