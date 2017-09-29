using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUI : MonoBehaviour
{
    public GameObject buildingInterface;
    void Update()
    {
        if (Input.GetButtonDown("Inventory")) //When "i" is clicked, shows UI building
        {
            buildingInterface.SetActive(!buildingInterface.activeSelf);
        }  
    }
}