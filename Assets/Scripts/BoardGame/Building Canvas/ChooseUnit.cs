using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Build", menuName = "Inventory/Unit")] //How to create new items, you can now create in project "create => Inventory => Unit"
public class ChooseUnit : ScriptableObject {
    new public string name = "New Item";
    public Sprite icon = null;
    public bool IsEnaled;
    public GameObject unit;
    public int Cost;
    public int loadingTime;

    [HideInInspector]
    public UnitSlot unitSlot;

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
                unitSlot.unitSelection(loadingTime,unit);


            }
        }
        else
        {
            Debug.Log("Nothing");
        }

    }
}
