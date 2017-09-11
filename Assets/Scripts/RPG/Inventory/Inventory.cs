using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    //Could use FindObjectOfType<Inventory>().Add, but it is taxing,
    //Instead i will use Singleton

    #region Singleton only one instance of class/object
    public static Inventory instance; //Singleton, makes a static variable that share all instances of a class

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found!");
            return;
        }
        instance = this; //then we set the instance to this particular component, so allways access this component, but you can only use 1 instance

    }
    #endregion
    
    public int space = 20;
    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallback;

    public List<Item> items = new List<Item>();
    public bool Add (Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not Enough room");
                return false;
            }
            items.Add(item);

            if(onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }
}