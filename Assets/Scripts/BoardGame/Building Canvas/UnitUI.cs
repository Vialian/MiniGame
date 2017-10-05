using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitUI : MonoBehaviour {
    #region variables

    BuildSlot buildSlot;
    ChooseBuilding chooseBuilding;
    ChooseUnit chooseUnit;
    UnitSlot unitSlot;
    bool isClicked;
    Vector3 buildingPos;

    [Header("Static")]
    public GameObject UnitInterface;
    public GameObject[] slotUnitArray;
    public GameObject[] slot;

    //test used with delegate,
    public Transform itemsParent;   // The parent object of all the items
    UnitSlot[] slots;  // List of all the slots
    #endregion

    void Start()
    {
        UnitInterface.SetActive(false);

        //slots = itemsParent.GetComponentsInChildren<UnitSlot>();
        //unitSlot.onUnitChangedCallback += unitSlot.UIPics;

    }
    //void UpdateUI()
    //{
    //    for (int i = 0; i < slots.Length; i++)
    //    {
    //        if (i < unitSlot.unitList.Count)
    //        {
    //            slots[i].Add(unitSlot.unitList[i]);
    //        }
    //        else
    //        {
    //            slots[i].ClearSlot();
    //        }
    //    }
    //}
    void Update () {
        //If mouse if over gameobject, nothing will happen, made so when inventory is up, the mouse will interact with stuff behind 
        if(EventSystem.current.IsPointerOverGameObject())
            return;

        //Get mouse position
        Ray castPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(castPoint, out hit, Mathf.Infinity) )
        {
            //when mouse is pressed, will check the pressed object name and compare with every building names and if Isenabled == true and if gameobject is not empty 
            foreach (var item in slot)
            {
                if (item.GetComponent<BuildSlot>().item.IsEnaled && item.GetComponent<BuildSlot>().item.Building != null)
                {
                    if (hit.transform.name == item.GetComponent<BuildSlot>().item.Building.name)
                    {//get building position, and show Unit Interface
                        buildingPos = hit.transform.position;
                        //UnitSlot.instance.Add(chooseUnit);
                        UnitInterface.SetActive(true);
                        isClicked = true;
                        //Check for every slot in unit inventory and send position to BuildingPos, so every slot will send a position 
                        for (int i = 0; i < slotUnitArray.Length; i++)
                        {
                            //items.Add(item);

                            //if (onItemChangedCallback != null)
                            //    onItemChangedCallback.Invoke();
                            //__________________________________________________________________
                            //change inventory item when different buildings are clicked
                            //slotUnitArray[i].SendMessage("UIPics", hit.transform.name, SendMessageOptions.RequireReceiver);
                            //__________________________________________________________________

                            slotUnitArray[i].SendMessage("BuildingPos", buildingPos, SendMessageOptions.RequireReceiver);
                        }
                    }
                    else
                    {
                        if (isClicked == false)
                        {
                            UnitInterface.SetActive(false);
                        }
                    }
                }
            }
        }
        isClicked = false;
    }
}
