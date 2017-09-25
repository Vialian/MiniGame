using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Build", menuName = "Inventory/Build")] //How to create new items, you can now create in project "create => Inventory => Item"
public class ChooseBuilding : ScriptableObject
{

    new public string name = "New Item";
    public Sprite icon = null;
    public bool IsEnaled = false;
    public GameObject Building;

    [HideInInspector]
    public bool place = false;


    public virtual void Use()
    {

        //Use item
        //Something might happen
        if (name != null && IsEnaled)
        {
            Debug.Log("using " + name);
            //if (Resources.Load("Buildings/" + name, typeof(GameObject)) as GameObject == null) Debug.Log("No Assets for this gameobject");


            if ("Buildings/" + name == null) Debug.Log("No Assets for this gameobject");
            else if ("Buildings/" + name != null)
            {
                place = true;

                //Instantiate(Resources.Load(NameOfBuilding), objectPos, Quaternion.identity);
                //Instantiate(Resources.Load("Buildings/Cube"), objectPos, Quaternion.identity);
                BuildSlot buildslot = new BuildSlot();
                buildslot.ItemSelection(Building);
                Build build = new Build();
                //build.Placement(true, Building);
            }



            //GameObject instance = Instantiate(Resources.Load("Buildings/" + name, typeof(GameObject))) as GameObject; //Skal ligge i Resources mappe
        }
        else
        {
            Debug.Log("Nothing");
        }

    }
    

    //public void RemoveFromInventory()
    //{
    //    Build.instance.Remove(this);
    //}

}
