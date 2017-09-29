﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creates new menu, where you can make own "prefabs", called build
[CreateAssetMenu(fileName = "New Build", menuName = "Inventory/Build")] //How to create new items, you can now create in project "create => Inventory => Item"
public class ChooseBuilding : ScriptableObject
{
    #region variables
    //The items created build will have variables of public
    new public string name = "New Item";
    [Header("UI interface")]
    public Sprite icon = null;
    public bool IsEnaled = false;
    [Header("Instantiated gameobjects")]
    public GameObject BuildingDummy;
    public GameObject BuildingTimer;
    public GameObject Building;
    [Header("Animations")]
    public int AnimationTime;
    [Header("Building Stats")]
    public int Cost;
    public int HP;

    [HideInInspector]
    public BuildSlot buildSlot;
    #endregion

    public virtual void Use()
    {
        //If "Build" have a name and is enabled(bool), Use item
        if (name != null && IsEnaled)
        {
            Debug.Log("using " + name);


            if ("Buildings/" + name == null) Debug.Log("No Assets for this gameobject");
            else if ("Buildings/" + name != null)
            {

                //sending to script BuildSlot, with 2 GameObject set on "Build", 
                //Building for the one in game, BuildingDummy for a temporary transparent GameObject to see where Building will be instantiate
                buildSlot.ItemSelection(Building,BuildingTimer, BuildingDummy);

            }
        }
        else
        {
            Debug.Log("Nothing");
        }

    }
}
