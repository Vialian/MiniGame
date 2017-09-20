using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Build", menuName = "Inventory/Build")] //How to create new items, you can now create in project "create => Inventory => Item"
public class ChooseBuilding : ScriptableObject
{

    new public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        //Use item
        //Something might happen

        Debug.Log("using " + name);

    }

    public void RemoveFromInventory()
    {
        Build.instance.Remove(this);
    }

}
