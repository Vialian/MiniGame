using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitUI : MonoBehaviour {

    BuildSlot buildSlot;
    public GameObject[] slot;
    void Start()
    {

    


    }


    // Update is called once per frame
    void Update () {

        

        Ray castPoint = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(castPoint, out hit, Mathf.Infinity) )
        {
            foreach (var item in slot)
            {
                //fix error when empty slot in inventory
                if (hit.transform.name == item.GetComponent<BuildSlot>().item.Building.name && item.GetComponent<BuildSlot>().item.IsEnaled && item.GetComponent<BuildSlot>().item.Building != null)
                {
                    Debug.Log(".gg");
                }
                else
                {
                    //Debug.Log(hit.transform.name +" == " + item.GetComponent<BuildSlot>().item.Building.name);
                }
            }



        }
	}
}
