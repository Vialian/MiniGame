using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    private Dictionary<string, ChooseUnit> m_ItemMap = new Dictionary<string, ChooseUnit>();
    public List<ChooseUnit> Items;

    private void Awake()
    {
        foreach (var item in Items)
        {
            m_ItemMap.Add(item.name, item);
        }
    }

    public ChooseUnit Get(string name)
    {
        return m_ItemMap[name];
    }
}
