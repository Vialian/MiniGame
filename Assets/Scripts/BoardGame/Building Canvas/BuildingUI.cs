using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUI : MonoBehaviour
{

    //public Transform itemsParent;   // The parent object of all the items

    public GameObject buildingInterface;
    public LayerMask buildingMask;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Vector3 m = Input.mousePosition;
            //m = new Vector3(m.x, m.y, transform.position.y);
            //Vector3 p = Camera.main.ScreenToWorldPoint(m);

            //RaycastHit hit = new RaycastHit();
            //Ray ray = new Ray(new Vector3(p.x, 8, p.z), Vector3.down);
            //if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            //{
            //    Debug.Log("Hit");
            //}



            if (Input.GetButtonDown("Inventory")) //add button (i)
            {
                buildingInterface.SetActive(!buildingInterface.activeSelf);
            }
        }
     
    }

    
    //Build build;    // Our current inventory

    //BuildSlot[] slots;  // List of all the slots

    //private void Awake()
    //{
    //    inventoryUI.SetActive(!inventoryUI.activeSelf);
    //}
    //void Start()
    //{
    //build = Build.instance;
    //build.onItemChangedCallback += UpdateUI;    // Subscribe to the onItemChanged callback

    // Populate our slots array
    //    slots = itemsParent.GetComponentsInChildren<BuildSlot>();
    //}


    //void UpdateUI()
    //{
    //    for (int i = 0; i < slots.Length; i++)
    //    {
    //        if (i < build.items.Count)
    //        {
    //            slots[i].AddItem(build.items[i]);
    //        }
    //        else
    //        {
    //            slots[i].ClearSlot();
    //        }
    //    }
    //}
}