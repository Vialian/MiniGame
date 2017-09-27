using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Creates new menu, where you can make own "prefabs", called build
[CreateAssetMenu(fileName = "New Build", menuName = "Inventory/Build")] //How to create new items, you can now create in project "create => Inventory => Item"
public class ChooseBuilding : ScriptableObject
{
    //The items created build will have variables of public
    new public string name = "New Item";
    public Sprite icon = null;
    public bool IsEnaled = false;
    public GameObject BuildingDummy;
    public GameObject Building;
    public int Cost;

    [HideInInspector]
    public BuildSlot buildSlot;
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
                buildSlot.ItemSelection(Building, BuildingDummy);

            }
        }
        else
        {
            Debug.Log("Nothing");
        }

    }
}
