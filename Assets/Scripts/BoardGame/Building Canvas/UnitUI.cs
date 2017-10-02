using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnitUI : MonoBehaviour {

    public GameObject UnitInterface;
    BuildSlot buildSlot;
    public GameObject[] slot;
    bool isClicked;

    public Vector3 buildingPos;
    UnitSlot unitSlot;

    public int i = 5;

    void Start()
    {
        UnitInterface.SetActive(false);
    }

    void Update () {
        unitSlot = new UnitSlot();
        if(EventSystem.current.IsPointerOverGameObject())
            return;

        Ray castPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(castPoint, out hit, Mathf.Infinity) )
        {
            foreach (var item in slot)
            {
                //fix error when empty slot in inventory
                if (item.GetComponent<BuildSlot>().item.IsEnaled && item.GetComponent<BuildSlot>().item.Building != null)
                {
                    if (hit.transform.name == item.GetComponent<BuildSlot>().item.Building.name)
                    {
                        //UnitInterface.SetActive(!UnitInterface.activeSelf);
                        buildingPos = hit.transform.position;
                        UnitInterface.SetActive(true);
                        isClicked = true;
                        Debug.Log("Firsdt " +buildingPos);
                        //unitSlot.buildingPos = buildingPos;
                        //unitSlot.BuildingPos(buildingPos);
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
